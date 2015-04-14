using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float vel = 10f;
	public float Salto = 16f;
	public bool girar = true;
	public bool DobleSalto = false;
	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.04434872f;
	public LayerMask mascaraSuelo;
	public float VidaPersonaje = 100f;
	public GameObject Personaje;
	public bool muerte = false;
	Animator animacion;
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Start () {
		animacion=GetComponent<Animator>();
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void FixedUpdate(){
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animacion.SetBool("OnFloor", enSuelo);
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Update () {
		//Variable que toma el valor al aprimir las direccionales(derecha o izquerda)
		float mover = Input.GetAxis ("Horizontal")*vel;
		float saltar = Input.GetAxis ("Vertical")*Salto;
				
		//El valor que toma la variable mover lo multlipicamos por la velocidad para indicar cuanto se va a desplazar el personaje
		GetComponent<Rigidbody2D>().velocity = new Vector2 (mover, GetComponent<Rigidbody2D>().velocity.y);
		
		animacion.SetFloat ("VelX", Mathf.Abs (mover));
		//condicion que permite que el personaje salte
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, Salto));
			if (enSuelo || !DobleSalto) {
		    	GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, Salto);
				DobleSalto = false;
				if (!DobleSalto && !enSuelo) {
					DobleSalto = true;
				}
			}
		} else {
			if (saltar>0) {
				GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, Salto));
				if (enSuelo || !DobleSalto) {
		    		GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, Salto);
			    	DobleSalto = false;
					if (!DobleSalto && !enSuelo) {
						DobleSalto = true;
					}
				}
			}
		}
		//con estas condiciones determinamos a que lado gira el personaje
		if (mover > 0 && !girar) {
			Girar ();
		} else if (mover < 0 && girar) {
			Girar ();
		}	

	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	//funcion que permitira girar el personaje
	void Girar() {
		girar = !girar;
		Vector3 actualEscala = transform.localScale;
		actualEscala.x *= -1;
		transform.localScale = actualEscala;
	}

	void OnTriggerEnter2D(Collider2D Bug)
	{
		if (Bug.tag == "EnemyShot") 
		{
			VidaPersonaje -= 20f;
			if (VidaPersonaje <= 0f) 
			{
				muerte = true;
				animacion.SetBool ("Die", muerte);
			}
		}

		if(Bug.tag == "EnemySuperShot")
		{
			VidaPersonaje -= 50f;
			if(VidaPersonaje <= 0f)
			{
				muerte = true;
				animacion.SetBool("Die",muerte);

			}
		}

	}

}
