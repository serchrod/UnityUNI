using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*Script para cargar una escena.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class BotonCargarScena : MonoBehaviour {

	public string nombreEscenaCargar = "GameScene";// Nombre del archivo de escena.
	// Metodo OnMouseDown, cuando se presiona click.
	void OnMouseDown(){
		Camera.main.GetComponent<AudioSource>().Stop ();// Detiene el audio de la camara principal.
		GetComponent<AudioSource>().Play();// Reproduce el audio del objeto que usa el script.
		// Llama al metod que carga la scena, con un delay de la longitud del clip del boton.
		Invoke ("CargarNivelJuego", GetComponent<AudioSource>().clip.length);
	}

	void CargarNivelJuego(){
		Application.LoadLevel (nombreEscenaCargar);// Carga la escena.
	}

}
