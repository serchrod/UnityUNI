using UnityEngine;
using System.Collections;

public class Recoge : MonoBehaviour {
	public int daño = 1;
	public AudioClip itemSoundClip;// Audio al recoger el objeto.
	public float itemSoundLevel = 1f;// Volumen del sonido.
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player") {// Valida que el objeto tenga etiqueta "Player".
			NotificationCenter.DefaultCenter().PostNotification(this,"kunaisRecogidas", daño);// Notifica de puntos ganados
			AudioSource.PlayClipAtPoint(itemSoundClip, Camera.main.transform.position, itemSoundLevel);// Reproduce el audio del item.
			Destroy (gameObject);// Destruye el item.
		}
	}
}
