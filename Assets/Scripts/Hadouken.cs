using UnityEngine;
using System.Collections;

public class Hadouken : MonoBehaviour {
	// Se declara con anterioridad el tipo de gameobject o prefabs a ocupar
	public GameObject Explosion;
	// velocidad del hadouken
	public float speed= 10.5f;
	//el tiempo de vida del hadouken
	public float lifetime= 20.0f;
	//el dao que causa el hadouken
	public int damage=50;


	void Start () {
		// destruye para que no vaije al infinito
		Destroy (gameObject, lifetime);
	}
	

	void Update () {
		// transforma la posicion del hadouken multiplicando el vector de la derecha multiplicado por la velocidad y el tiempo transcurrido
		transform.position += transform.right * speed * Time.deltaTime;
	}
	//el script que llama a la colision
	void OnCollisionEnter(Collision collision)
	{
		ContactPoint contact = collision.contacts[0];
		Instantiate(Explosion, contact.point, 
		            Quaternion.identity);
		Destroy(gameObject);
	}
}
