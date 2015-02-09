using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float velocidad=10f;
	bool girar = true;
	Animator animacion;
	// Use this for initialization
	void Start () {
		animacion=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//Variable que toma el valor al aprimir las direccionales(derecha o izquerda)
		float mover = Input.GetAxis("Horizontal");
		//El valor que toma la variable mover lo multlipicamos por la velocidad para indicar cuanto se va a desplazar el personaje
		rigidbody2D.velocity = new Vector2 (velocidad = mover, rigidbody2D.velocity.y);

		animacion.SetFloat("Velocidad",Mathf.Abs(mover));
		//condicion que permite que el personaje salte
		if(Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody2D.AddForce(new Vector2(0,230));
		}
		//con estas condiciones determinamos a que lado gira el personaje
		if (mover > 0 && !girar) {
			Girar();
			}
		else if (mover < 0 && girar){
			Girar();
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
