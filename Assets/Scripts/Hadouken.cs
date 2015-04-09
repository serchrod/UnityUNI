using UnityEngine;
using System.Collections;

public class Hadouken : MonoBehaviour {
	// velocidad del hadouken
	public float speed= 10.5f;
	//el tiempo de vida del hadouken
    public float lifetime = 5.0f;
	void Start () {
		// destruye para que no vaije al infinito
		Destroy (gameObject, lifetime);
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Update () {
		// Transforma la posicion del hadouken multiplicando el vector de la derecha multiplicado por la velocidad y el tiempo transcurrido
		transform.position += transform.right * speed * Time.deltaTime;
	}
}
