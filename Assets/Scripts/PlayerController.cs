using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject Bullet;
	private Transform bulletspawnpoint;
	//Curso del personaje
	private float curspeed, targetspeed;
	//Velocidad de movimiento del personaje
	//private float Maxfowardspeed= 1, Maxbackwardspeed= -1;
	//private int Jump=10, stand=0;
	//velocidad de disparo
	protected float shootrate=0.2f;
	protected float elapsedtime;
	public int counter=3;
	private Animator animator;
	public bool hadouken = false;

	void Awake(){
		animator = GetComponent<Animator>();
	}

	void Start () {
		// es el vertice de donde salen los hadouken
		bulletspawnpoint = gameObject.transform.GetChild (0);
		/*se hace referencia al child del gameobject, se pone como 0 ya que se toma como el primero de el game
        si existiera otro se pone como (1)
		 */
}


	void FixedUpdate(){
		animator.SetBool("hadouken", hadouken);
	}
	void Update () {
		updateweapon ();
			//updatecontrol ();
	
	}

	/*protected void updatecontrol(){
		if (Input.GetKey (KeyCode.RightArrow)) {
						targetspeed = Maxfowardspeed;
				} else if (Input.GetKey (KeyCode.LeftArrow)) {
						targetspeed = Maxbackwardspeed;
						
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			targetspeed = Jump;
			//transforma la fuerza del salto y lo lleva hacia arriba
			transform.Translate(Vector2.up * Time.deltaTime * curspeed);
	    }
		if (Input.GetKey (KeyCode.DownArrow)) {
			targetspeed=stand;
		}

		// por formula de la propiedad del objeto LERP, calcula la velocidad de movimiento
		curspeed = Mathf.Lerp(curspeed, targetspeed, 7.0f * Time.deltaTime);
		//traslada el objeto multiplicando su propia distancia que es obtenidad por el vector2.right
		transform.Translate(Vector2.right * Time.deltaTime * curspeed);
	}*/
	protected void updateweapon()
	{
		if (Input.GetKey(KeyCode.X))
		{
			hadouken = true;
			elapsedtime += Time.deltaTime;
			if (elapsedtime >= shootrate)
			{
				// resetea el  tiempo transcurrido
				elapsedtime = 0.0f;
				//instancia la bala
				if(counter>0){
					counter-=1;
				Instantiate(Bullet, bulletspawnpoint.position, 
				            bulletspawnpoint.rotation);
					print (counter);

			}
		}
		}else if (Input.GetKey(KeyCode.JoystickButton2))
		{
			hadouken = true;
			elapsedtime += Time.deltaTime;
			if (elapsedtime >= shootrate)
			{
				// resetea el  tiempo transcurrido
				elapsedtime = 0.0f;
				//instancia la bala
				if(counter>0){
					counter-=1;
					Instantiate(Bullet, bulletspawnpoint.position, 
					            bulletspawnpoint.rotation);
					print (counter);
					
				}
			}
		}else {
			hadouken = false;
		}
 }
}