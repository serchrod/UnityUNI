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

	Animator animacion;
	// Use this for initialization
	void Start () {
		animacion=GetComponent<Animator>();
	}

	void FixedUpdate(){
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animacion.SetBool("OnFloor", enSuelo);
		}
	
	// Update is called once per frame
	void Update () {
				//Variable que toma el valor al aprimir las direccionales(derecha o izquerda)
				float mover = Input.GetAxis ("Horizontal")*vel;
				
				//El valor que toma la variable mover lo multlipicamos por la velocidad para indicar cuanto se va a desplazar el personaje
				rigidbody2D.velocity = new Vector2 (mover, rigidbody2D.velocity.y);
		
				animacion.SetFloat ("VelX", Mathf.Abs (mover));
				//condicion que permite que el personaje salte
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
						rigidbody2D.AddForce (new Vector2 (0, Salto));
						if (enSuelo || !DobleSalto) {
								rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, Salto);
								DobleSalto = false;
								if (!DobleSalto && !enSuelo) {
										DobleSalto = true;
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
	//funcion que permitira girar el personaje
	void Girar() {
		girar = !girar;
		Vector3 actualEscala = transform.localScale;
		actualEscala.x *= -1;
		
		transform.localScale = actualEscala;
	}
}
