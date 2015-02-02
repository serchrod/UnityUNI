using UnityEngine;
using System.Collections;

public class BotonCargarScena : MonoBehaviour {

	public string nombreEscenaCargar = "GameScene";
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		Camera.main.audio.Stop ();
		audio.Play();
		Invoke ("CargarNivelJuego", audio.clip.length);
	}
	void CargarNivelJuego(){
		Application.LoadLevel (nombreEscenaCargar);
	}
}
