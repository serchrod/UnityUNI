using UnityEngine;
using System.Collections;

public class DestruirPersonaje : MonoBehaviour {
	public GameObject personaje;

	public void destruirPersonaje(){
		Destroy (personaje);
	}
}
