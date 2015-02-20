using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otro){
		if (otro.tag == "Enemy") {
			//NotificationCenter.DefaultCenter().PostNotification(this,"personajeMurio");
			GameObject enemigo = GameObject.Find("EnemigoAzul");
			enemigo.SetActive(false);
		}else if(otro.tag == "Enemy"){
			GameObject enemigo = GameObject.Find("EnemigoNaranja");
			enemigo.SetActive(false);
		}else if(otro.tag == "Enemy"){
			GameObject enemigo = GameObject.Find("EnemigoRojo");
			enemigo.SetActive(false);
		}else {
			//Destroy (otro.gameObject);
		}
	}
}
