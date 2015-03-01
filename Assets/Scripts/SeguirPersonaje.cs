using UnityEngine;
using System.Collections;
/*Script para seguir al personaje.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class SeguirPersonaje : MonoBehaviour {
	public Transform personaje;// Propiedad Transform para le perosnaje.
	public float separacion = 6f;// Distancia entre la camara y el personaje.
	// Update is called once per frame
	void Update () {

		// Mueve al personaje.
		transform.position = new Vector3(personaje.position.x+separacion, transform.position.y, transform.position.z);
	}
}
