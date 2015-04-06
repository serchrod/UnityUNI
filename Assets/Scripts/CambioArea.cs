using UnityEngine;
using System.Collections;

public class CambioArea : MonoBehaviour {

	public void cargarNivelButton(string nombreArea){
		Camera.main.audio.Stop ();// Detiene el audio de la camara principal.
		Application.LoadLevel (nombreArea);
	}
}
