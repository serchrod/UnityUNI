using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject Bullet;
	private Transform bulletspawnpoint;
	//Curso del personaje
	private float curspeed, targetspeed;
	protected float shootrate=0.2f;
	protected float elapsedtime;
	public int counter=3;
	private Animator animator;
	public bool hadouken = false;

	void Awake(){
		animator = GetComponent<Animator>();
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Start () {
		// es el vertice de donde salen los hadouken
		bulletspawnpoint = gameObject.transform.GetChild (0);
		/*se hace referencia al child del gameobject, se pone como 0 ya que se toma como el primero de el game
        si existiera otro se pone como (1)
		 */
    }
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void FixedUpdate(){
		animator.SetBool("hadouken", hadouken);
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Update () {
		updateWeapon ();
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	protected void updateWeapon(){
		if (Input.GetKey(KeyCode.X)){
			hadouken = true;
			elapsedtime += Time.deltaTime;
			if (elapsedtime >= shootrate){
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
		}else if (Input.GetKey(KeyCode.JoystickButton2)){
			hadouken = true;
			elapsedtime += Time.deltaTime;
			if (elapsedtime >= shootrate){
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