using UnityEngine;
using System.Collections;
using System.IO;
public class Control : MonoBehaviour {

	public float fuerzaSalto = 100f;
	public float fuerzaLateral = 8f;

	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.3f;
	public LayerMask mascaraSuelo;
	private bool dobleSalto = false;
	private Animator animator;
	private bool corriendo = false;
	public float velocidad = 1f;
	void Awake(){
		animator = GetComponent<Animator>();
	}

	void Start () {
		
	}
	
	void FixedUpdate(){
		if (corriendo) {
			rigidbody2D.velocity = new Vector2 (velocidad, rigidbody2D.velocity.y);
		}
		animator.SetFloat ("VelX", rigidbody2D.velocity.x);
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animator.SetBool("OnFloor", enSuelo);
		if(enSuelo){
			dobleSalto = false;
		}
	}

	// Update is called once per frame
	void Update () {
		//Flecha arriba
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (corriendo) {
			// Hacemos que salte si puede saltar
				if (enSuelo || !dobleSalto) {
					audio.Play ();
					rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, fuerzaSalto);
					if (!dobleSalto && !enSuelo) {
						dobleSalto = true;
					}
				}
			} else {
				corriendo = true;
				NotificationCenter.DefaultCenter ().PostNotification (this, "personajeCorriendo");
			}
		} else if (Input.GetMouseButtonDown (0)) {//Click Izquierdo
					if (corriendo) {
						// Hacemos que salte si puede saltar
						if (enSuelo || !dobleSalto) {
							audio.Play ();
							rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, fuerzaSalto);
							if (!dobleSalto && !enSuelo) {
								dobleSalto = true;
							}
						}
					} else {
						corriendo = true;
						NotificationCenter.DefaultCenter ().PostNotification (this, "personajeCorriendo");
					}
		} else if (Input.GetKeyDown (KeyCode.Space)) {//Tecla Espaciadora
			if (corriendo) {
			// Hacemos que salte si puede saltar
				if (enSuelo || !dobleSalto) {
					audio.Play ();
					rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, fuerzaSalto);
					if (!dobleSalto && !enSuelo) {
						dobleSalto = true;
					}
					//Activar Vibracion.
					}
			} else {
				corriendo = true;
				NotificationCenter.DefaultCenter ().PostNotification (this, "personajeCorriendo");
			}
		} else if (Input.GetKeyDown (KeyCode.JoystickButton0)) {//GamePad X
				if (corriendo) {
				// Hacemos que salte si puede saltar
					if (enSuelo || !dobleSalto) {
						audio.Play ();
						rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, fuerzaSalto);
						if (!dobleSalto && !enSuelo) {
							dobleSalto = true;
						}
						//Activar Vibracion.
					}
				} else {
					corriendo = true;
					NotificationCenter.DefaultCenter ().PostNotification (this, "personajeCorriendo");
				}
		}
		//Termina Salto

	}
	//Update
}
