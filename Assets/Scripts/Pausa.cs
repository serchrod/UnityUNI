using UnityEngine;
using System.Collections;

public class Pausa : MonoBehaviour {
	bool pausa = false;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if ((!pausa) && Input.GetKeyDown ( KeyCode.P)) {
			Time.timeScale = 0;
			audio.Pause();// Detiene el audio de la camara principal.
			pausa = true;
		}else if ((pausa) && Input.GetKeyDown ( KeyCode.P)){
			Time.timeScale = 1;
			audio.Play();// Reproduce el audio del objeto que usa el script.
			pausa = false;
		}
	}
}
