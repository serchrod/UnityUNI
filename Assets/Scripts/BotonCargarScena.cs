using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*Script para cargar una escena.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class BotonCargarScena : MonoBehaviour {

	public string nombreEscenaCargar = "GameScene";// Nombre del archivo de escena.

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	// Metodo OnMouseDown, cuando se presiona click.
	void OnMouseDown(){
		Camera.main.audio.Stop ();// Detiene el audio de la camara principal.
		audio.Play();// Reproduce el audio del objeto que usa el script.
		// Llama al metod que carga la scena, con un delay de la longitud del clip del boton.
		Invoke ("CargarNivelJuego", audio.clip.length);
	}

	void CargarNivelJuego(){
		Application.LoadLevel (nombreEscenaCargar);// Carga la escena.
	}

}
