using UnityEngine;
using System.Collections;
//interpretaremos la inteligencia artificial como una maquina de estados.
public class Boss : FSM {


	//se nombran los estados de la maquina
	public enum fsmstate{
		None,
		persecusion,
		rayo,
		espada,
		brinco,
		stands,
		retroceder,
		muerte,
	}
	Animator animador;
	//se declara la variable del mismo estado del enum
	public fsmstate estado;
	// se declara el prefabs o municion que se utilizara para el antagonista. Se utiliza publico para que editable 
	public GameObject beam;
	// se declara la variable que controlara el estado del antagonista, se recomienda utilizar una variable del tipo booleano
	//private bool muerte= false;
	// se declara unos de los atibutos mas importantes, la salud del antagonista
	private float curspeed;
	public int salud;
	public float Distancia = 0f;
	public bool Pego = false;
	public bool ataque = false;
	/* una vez declarado los atributos del antagonista se comienza a crear los estados de la maquina finita.
    sobreescribiremos el metodo que se encuentra en FSM(clase padre).
   */
	void Awake (){
		animador = GetComponent <Animator>();
	}
	
	protected override void Initialize(){
		// se asigna el primer estado, el cual es el de persecusion
		estado = fsmstate.persecusion;
		// se le asigna la velocidad
		curspeed = 6.0f;
		// se reasigna como falso debido que le  decimos al compilador que mientra este en persecusion nunca podra estar muerto
		//muerte = false;
		//es el tiempo trasncurrido, se encuentra en fsm ya que boss se hereda de esta
		elapsedTime = 0.0f;
		// la salud inicial del antagonista
		salud = 2;
		shootRate = 0.5f;
		// esta instancia busca al objeto player
		GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
		playerTransform = objPlayer.transform;
		bulletSpawnPoint = gameObject.transform.GetChild (0);
	}
	protected override void FSMUpdate()
	{   //los diferentes estados que puede tomar la inteligencia artificial con respecto a la razon
		switch (estado)
		{
		case fsmstate.persecusion: Updatepersecusion(); break;
		case fsmstate.retroceder: Updateretroceder(); break;
		case fsmstate.rayo: Updaterayo(); break;
		case fsmstate.espada: Updateespada(); break;
		case fsmstate.brinco: Updatebrinco(); break;
		case fsmstate.stands: Updatestand(); break;
		}	
		//el tiempo transcurrido
		elapsedTime += Time.deltaTime;
		if (salud <= 0) {
			Updatemuerte();
		}
	}
	
	protected void Updatepersecusion()
	{
		destPos = playerTransform.position;
		//mantiene la persecusion
		curspeed = 6.0f;
		if (Vector2.Distance(transform.position, destPos) <= 10.0f)
		{
			print("Me encuentro en estado stand y cambiare a persecusion");
			transform.Translate(Vector3.left * Time.deltaTime * curspeed);
		}
		// decide si esta cerca cambia al estado de rastreo
		if (Vector2.Distance(transform.position, playerTransform.position) <= 10.0f)
		{	
			print("cambio a modo de ataque");
			ataque = true;
			animador.SetBool ("Cerca",ataque);
			estado= fsmstate.espada;
		
			
		}
		
		//transform.Translate(Vector3.left * Time.deltaTime * curspeed);
	}
	
	protected void Updateespada(){
	
		
		transform.Translate(Vector3.right * Time.deltaTime * curspeed);
		if (Vector2.Distance(transform.position, playerTransform.position) <= 2.0f)
		{
			print("cambio a modo de retroceso");
			Pego= true;
			animador.SetBool ("Pego",Pego);
			estado= fsmstate.retroceder;
			
		}
		if (Vector2.Distance(transform.position, playerTransform.position) == 10.0f)
		{
			curspeed=0;
		}
		
		
	}
	
	protected void Updatebrinco(){
		print ("Estoy brincando");
	}
	protected void Updaterayo(){
		print ("kameha");
	}
	
	protected void Updateretroceder(){
		transform.Translate(Vector3.left * Time.deltaTime * curspeed);
		if (Vector2.Distance(transform.position, playerTransform.position)>= 10.0f)
		{
			estado = fsmstate.stands;
			ShootBullet();
		}
	
	}
	
	private float tiempo=0.5f;
	protected void Updatemuerte(){
		Destroy (gameObject, tiempo);
	}
	
	protected void Updatestand(){
		curspeed = 0;
		transform.Translate(Vector3.left * Time.deltaTime * curspeed);
		Pego = false ;
		ataque = false;
		animador.SetBool ("Cerca",ataque);
		animador.SetBool ("Pego",Pego);
		if(Vector2.Distance(transform.position, playerTransform.position) <=10.0f)
		{
			estado = fsmstate.persecusion;

		}

	}

	protected void ShootBullet ()
	{
			if (elapsedTime >= shootRate)
		{
			Instantiate (beam, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
			elapsedTime = 0.0f;
		}
	}
	
	/* detecta las colision con los distintos elementos, en este caso detectara si el Player le arroja algun objeto que inflija 
      dano
	 */
	void OnTriggerEnter2D(Collider2D collider){
		/*normalmente en los videojuegos el personaje principal cuenta con diferentes tipos de armas
 		segun la naturaleza del dano pueden quitar diferentes tipos de cantidad a la salud del antagonista
        pero llevar un control del objeto que colisiona con el antagonista disponemos a ponerle un TAG al
        prefabs o colisionador que estamos utilizando, en este caso utilizaremos el Hadouken(tecnica de Ryu)
		*/
		if(collider.tag == "Hadouken"){
			
			NotificationCenter.DefaultCenter ().PostNotification (this, "impactado");
		}
	}
}

