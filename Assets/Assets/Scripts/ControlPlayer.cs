using UnityEngine;
using System.Collections;

public class ControlPlayer : MonoBehaviour {
	public float fuerzaSalto = 100f;

	public bool OnFloor = true;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.05f;
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
	
	// Update is called once per frame
	void FixedUpdate(){
		if (corriendo) {
			rigidbody2D.velocity = new Vector2 (velocidad, rigidbody2D.velocity.y);
		}
		animator.SetFloat ("VelX", rigidbody2D.velocity.x);
		OnFloor = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animator.SetBool("OnFloor", OnFloor);
		if(OnFloor){
			dobleSalto = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Flecha arriba
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			if(corriendo){
				// Hacemos que salte si puede saltar
				if(OnFloor || !dobleSalto){
					audio.Play();
					rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);
					if(!dobleSalto && !OnFloor){
						dobleSalto = true;
					}
				}
			}else{
				corriendo = true;
				NotificationCenter.DefaultCenter().PostNotification(this,"personajeCorriendo");
			}
		}else if(Input.GetMouseButtonDown(0)){//Click Izquierdo
			if(corriendo){
				// Hacemos que salte si puede saltar
				if(OnFloor || !dobleSalto){
					audio.Play();
					rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);
					if(!dobleSalto && !OnFloor){
						dobleSalto = true;
					}
				}
			}else{
				corriendo = true;
				NotificationCenter.DefaultCenter().PostNotification(this,"personajeCorriendo");
			}
		}else if(Input.GetKeyDown(KeyCode.Space)){//GamePad X
			if(corriendo){
				// Hacemos que salte si puede saltar
				if(OnFloor || !dobleSalto){
					audio.Play();
					rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);
					if(!dobleSalto && !OnFloor){
						dobleSalto = true;
					}
					//Activar Vibracion.
				}
			}else{
				corriendo = true;
				NotificationCenter.DefaultCenter().PostNotification(this,"personajeCorriendo");
			}
		}
	}
}
