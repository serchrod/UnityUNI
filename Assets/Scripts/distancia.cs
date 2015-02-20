using UnityEngine;
using System.Collections;

public class distancia : MonoBehaviour {
	public float distfinal;
	protected Transform playerTransform;
	protected Vector2 destino;


	void Update () {
		medida ();
	}

	void medida(){
		GameObject objPlayer = GameObject.FindGameObjectWithTag("Wandar");
		playerTransform = objPlayer.transform;
		destino = playerTransform.position;


		if (Vector2.Distance(transform.position, destino) != 0.0f) {
			print(transform.position.x);
		}

	}
}
