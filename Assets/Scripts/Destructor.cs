using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otro){
		if (otro.tag == "Player") {
			NotificationCenter.DefaultCenter().PostNotification(this,"personajeMurio");
			GameObject personaje = GameObject.Find("Personaje");
			personaje.SetActive(false);
		} else {
			Destroy (otro.gameObject);
		}
	}
}
