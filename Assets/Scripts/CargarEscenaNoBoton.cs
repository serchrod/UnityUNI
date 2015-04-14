using UnityEngine;
using System.Collections;
/*Script para cargar una escena precionando una tecla.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class CargarEscenaNoBoton : MonoBehaviour {

	public string Escena;// Nombre del archivo de la esena.
	void Update () {
		if(Input.GetKeyDown(KeyCode.JoystickButton1)){// Valida input desde joistick.
			Camera.main.GetComponent<AudioSource>().Stop ();// Detiene el audio de la camara.
			GetComponent<AudioSource>().Play();// Reproduce el audio del boton.
			// Llama al metod que carga la scena, con un delay de la longitud del clip del boton.
			Invoke ("EscenaActu", GetComponent<AudioSource>().clip.length);
		}else if ((Input.GetKeyDown(KeyCode.KeypadEnter))||(Input.GetKeyDown(KeyCode.Return))){
			Camera.main.GetComponent<AudioSource>().Stop ();// Detiene el audio de la camara.
			GetComponent<AudioSource>().Play();// Reproduce el audio del boton.
			// Llama al metod que carga la scena, con un delay de la longitud del clip del boton.
			Invoke ("EscenaActu", GetComponent<AudioSource>().clip.length);
		}
	}
	// Metodo EscenaActu carga una escena.
	void EscenaActu(){
		Application.LoadLevel (Escena);// Carga la escena.
	}
}
