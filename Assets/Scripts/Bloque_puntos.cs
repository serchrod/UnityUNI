using UnityEngine;
using System.Collections;

public class Bloque_puntos : MonoBehaviour {
	private bool haColisionadoJugador = false;
	public int puntosIncrementar = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (!haColisionadoJugador && collision.gameObject.tag == "Player") {
			GameObject obj = collision.contacts[0].collider.gameObject;
			if(obj.name == "PataInferiorDerechaB" || obj.name == "PataInferiorIzquierdaB"){
				haColisionadoJugador = true;
				NotificationCenter.DefaultCenter().PostNotification(this,"ganarPuntos",puntosIncrementar);
			}
		}

	}
}
