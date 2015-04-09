using UnityEngine;
using System.Collections;
/*Script para destruir cualquier objeto.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class Destructor : MonoBehaviour {
	// Metodo OnTriggerEnter2D para colliders 2D
	void OnTriggerEnter2D(Collider2D otro){
		if (otro.tag == "Player") {// Valida que el objeto tenga etiqueta "Player".
			NotificationCenter.DefaultCenter().PostNotification(this,"personajeMurio");// Envia la notificacion de muerte.
			// Asigna al GameObject personaje el personaje en la escena.
			GameObject personaje = GameObject.Find("Personaje");
			personaje.SetActive(false);// Desactiva el personaje de la escena.
		} else {
			Destroy (otro.gameObject);// Si no es el personaje lo que colisiona lo destruye.
		}
	}
}
