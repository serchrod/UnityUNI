using UnityEngine;
using System.Collections;

public class SimpleFsm : FSM {
	// enumero los tipos de estados de inteligencia de artificial
	public enum FSMState
	{
		None,
		Patrol,
		Chase,
		Attack,
		Dead,
	}
	
	//el estado del maquina finita de estados
	public FSMState curState;
	
	//la velocidad del ninja
	private float curSpeed;

	
	//Hadouken
	public GameObject Bullet;
	
	//estados posibles del maquina
	private bool bDead;
	private int health;
	
	
	//Inicializa la maquina de estados 
	protected override void Initialize () 
	{    
		//se le asigna el estado de patrulla
		curState = FSMState.Patrol;
		//se la de velocidad
		curSpeed = 1.0f;
		// se inicializa el estado de muerte como falso
		bDead = false;
		//el tiempo transcurrido cmoo 0
		elapsedTime = 0.0f;
		//velocidad de disparo del ninja
		shootRate = 3.0f;
		//con la salud de 100
		health = 100;
		
		//busca las coordenadas del objetos del tipo wanadar
		pointList = GameObject.FindGameObjectsWithTag("Wandar");
		//funcion que se encarga del random de los puntos
		FindNextPoint();
		// se declara y se iguala al metodo que busca los objetos del tipo PLAYER
		GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
		playerTransform = objPlayer.transform;
		//identifica si existe el player
		if(!playerTransform)
			print("Player doesn't exist.. Please add one with Tag named 'Player'");

	    // el gameobject child del ninja enemigo
		bulletSpawnPoint = gameObject.transform.GetChild (0);
	}
	
	//manejas los estados de la maquina finita
	protected override void FSMUpdate()
	{   //hace las acciones segun el curstate conrrespondiente
		switch (curState)
		{
		case FSMState.Patrol: UpdatePatrolState(); break;
		case FSMState.Chase: UpdateChaseState(); break;
		case FSMState.Attack: UpdateAttackState(); break;
		case FSMState.Dead: UpdateDeadState(); break;
		}
		
		//el tiempo transcurrido
		elapsedTime += Time.deltaTime;
		
		//si el enemigo no tiene vida queda en estado de muerte
		if (health <= 0)
			curState = FSMState.Dead;
	}
	

	protected void UpdatePatrolState()
	{
		//mantiene el patrulleo
		if (Vector2.Distance(transform.position, destPos) <= 10.0f)
		{
			print("Reached to the destination point\ncalculating the next point");
			FindNextPoint();
		}
		        // decide si esta cerca cambia al estado de rastreo
				else if (Vector2.Distance(transform.position, playerTransform.position) <= 8.0f)
		{
			print("Switch to Chase Position");
			curState = FSMState.Chase;
		}

		// hacia adelante de forma horizontal
		transform.Translate(Vector2.right * Time.deltaTime * curSpeed);
	}
	

	protected void UpdateChaseState()
	{
		//determina la posicion del player
		destPos = playerTransform.position;
		

		//cuando esta cerca, cambia a forma de tataque
		float dist = Vector2.Distance(transform.position, playerTransform.position);
		if (dist <= 5.0f)
		{
			curState = FSMState.Attack;
		}
		//se va a patrullar si la distancia es muy lejanas
		else if (dist >= 10.0f)
		{
			curState = FSMState.Patrol;
		}
		
		// va hacia adelante
		transform.Translate(Vector2.right * Time.deltaTime * curSpeed);
	}

	protected void UpdateAttackState()
	{
		//obtiene la posicion del player
		destPos = playerTransform.position;
		
		//Chequea la distancia de los players
		float dist = Vector2.Distance(transform.position, playerTransform.position);
		if (dist >= 8.0f && dist < 10.0f)
		{
		
			//va hacia adelante 
			transform.Translate(Vector2.right * Time.deltaTime * curSpeed);
			
			curState = FSMState.Attack;
		}
		//Transition to patrol is the tank become too far
		else if (dist >= 10.0f)
		{
			curState = FSMState.Patrol;
		}        
		//llama al metodo disparar
		ShootBullet();
	}
	

	protected void UpdateDeadState()
	{
		//llama a la muerte con las propiedades fisicas
		if (!bDead)
		{
			bDead = true;
			Explode();
		}
	}
	

	private void ShootBullet()
	{
		if (elapsedTime >= shootRate)
		{
			//disparar hadouken
			Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
			elapsedTime = 0.0f;
		}
	}
	

	void OnCollisionEnter(Collision collision)
	{
		//reduce la vida
		if(collision.gameObject.tag == "Hadouken")
			health -= collision.gameObject.GetComponent<Hadouken>().damage;
	}   
	

	protected void FindNextPoint()
	{
		print("Finding next point");
		int rndIndex = Random.Range(0, pointList.Length);
		float rndRadius = 6.0f;
		
		Vector2 rndPosition = Vector2.zero;
		destPos = pointList[rndIndex].transform.position  ;
		
		//checkea si el pubnto no era el anterior
		if (IsInCurrentRange(destPos))
		{
			rndPosition = new Vector2(Random.Range(-rndRadius, rndRadius),0.0f);
			destPos = pointList[rndIndex].transform.position;
		}
		 
	}
	
		protected bool IsInCurrentRange(Vector2 pos)
	{
		float xPos = Mathf.Abs(pos.x - transform.position.x);
		float YPos = Mathf.Abs(pos.y - transform.position.y);
		
		if (xPos <= 50 && YPos <= 50)
			return true;
		
		return false;
	}
	//funcion explotar
	protected void Explode()
	{
		float rndX = Random.Range(10.0f, 30.0f);
		float rndZ = Random.Range(10.0f, 30.0f);
		for (int i = 0; i < 3; i++)
		{

			rigidbody.AddExplosionForce(10000.0f, transform.position - new Vector3(rndX, 10.0f, rndZ), 40.0f, 10.0f);
			rigidbody.velocity = transform.TransformDirection(new Vector3(rndX, 20.0f, rndZ));
		}
		
		Destroy(gameObject, 1.5f);
	}
}
