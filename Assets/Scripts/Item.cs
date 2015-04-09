using UnityEngine;
using System.Collections;
/*Script de items para acumular puntaje.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class Item : MonoBehaviour {
	public int puntosIncrementar = 5;// Puntaje del objeto.
	public AudioClip itemSoundClip;// Audio al recoger el objeto.
	public float itemSoundLevel = 1f;// Volumen del sonido.
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	// Metodo OnTriggerEnter2D para colliders 2D
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player") {// Valida que el objeto tenga etiqueta "Player".
			NotificationCenter.DefaultCenter().PostNotification(this,"ganarPuntos",puntosIncrementar);// Notifica de puntos ganados
			AudioSource.PlayClipAtPoint(itemSoundClip, Camera.main.transform.position, itemSoundLevel);// Reproduce el audio del item.
			Destroy (gameObject);// Destruye el item.
		}
	}
}
