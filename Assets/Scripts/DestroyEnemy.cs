using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Enemy") {
			Destroy(collision.gameObject);
		}
	}
}
