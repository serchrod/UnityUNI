using UnityEngine;
using System.Collections;

public class CargarEscenaNoBoton : MonoBehaviour {

	public string Escena;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.JoystickButton1)){
			Camera.main.audio.Stop ();
			audio.Play();
			Invoke ("EscenaActu", audio.clip.length);
		}else if ((Input.GetKeyDown(KeyCode.KeypadEnter))||(Input.GetKeyDown(KeyCode.Return))){
			Camera.main.audio.Stop ();
			audio.Play();
			Invoke ("EscenaActu", audio.clip.length);
		}
	}
	void EscenaActu(){
		Application.LoadLevel (Escena);
	}
}
