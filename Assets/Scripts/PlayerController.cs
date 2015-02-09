using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject Bullet;
	private Transform bulletspawnpoint;
	//Curso del personaje
	private float curspeed, targetspeed;
	//Velocidad de movimiento del personaje
	private float Maxfowardspeed= 1, Maxbackwardspeed= -1;
	//velocidad de disparo
	protected float shootrate=0.2f;
	protected float elapsedtime;
	private bool hadouken;
	private Animator animator;

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
		animator.SetBool ("hadouken", hadouken);
	}

	void Update () {
		updateweapon ();
	}
	
	protected void updateweapon()
	{
		if (Input.GetKey(KeyCode.LeftAlt)){
			elapsedtime += Time.deltaTime;
			hadouken = true;
			if (elapsedtime >= shootrate)
			{
				// resetea el  tiempo transcurrido
				elapsedtime = 0.0f;
				//instancia la bala
				Instantiate(Bullet, bulletspawnpoint.position, 
				            bulletspawnpoint.rotation);
			}
		}else if(Input.GetKey(KeyCode.JoystickButton1)){
			elapsedtime += Time.deltaTime;
			hadouken = true;
			if (elapsedtime >= shootrate)
			{
				// resetea el  tiempo transcurrido
				elapsedtime = 0.0f;
				//instancia la bala
				Instantiate(Bullet, bulletspawnpoint.position, 
				            bulletspawnpoint.rotation);
			}
		}else{
			hadouken = false;
		}
	}
}
