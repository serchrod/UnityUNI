using UnityEngine;
using System.Collections;
/*Script que activa la camara de Game Over.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class ActivarGameOver : MonoBehaviour {

	public GameObject CamaraGameOver;// GameObject de la camara que se quiere llamar.
	public GameObject botonPausa;
	public AudioClip gameOverClip;// AudioClip del audio que se quiere llamar.

	void Start () {
		/*
		 * Se crea un observador del estado "personajeMurio" 
		*/
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeMurio");
	}
	//Metodo con Notification como parametro que se llama cuando el personaje muere..
	void personajeMurio(Notification notificacion){
		audio.Stop ();// Se detiene el audio del area.
		audio.clip = gameOverClip;// Se camabia el audio por el audio del Game Over.
		audio.loop = false;// La repeticion del audio se desactiva.
		audio.Play ();// Se reproduce la pista actualizada
		//CamaraMain.SetActive (false);
		botonPausa.SetActive (false);
		CamaraGameOver.SetActive(true);// Se activa la camara del Game Over.
	}

	void Update () {
	
	}
}
