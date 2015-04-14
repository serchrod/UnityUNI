using UnityEngine;
using System.Collections;
/*Script para cerrar el juego.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class Salir : MonoBehaviour {
	void OnMouseDown(){
		Camera.main.GetComponent<AudioSource>().Stop ();//Detiene el audio de la camara.
		GetComponent<AudioSource>().Play();// Reproduce el audio del boton.
		// Llama al metod que carga la scena, con un delay de la longitud del clip del boton.
		Invoke ("CerrarJuego", GetComponent<AudioSource>().clip.length);
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	public void CerrarJuego(){
		Application.Quit ();//Cierra la aplicacion.
	}
}
