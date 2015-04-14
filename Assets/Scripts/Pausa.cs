using UnityEngine;
using System.Collections;

public class Pausa : MonoBehaviour {
	bool pausa = false;
	public GameObject menuPausa;
	public AudioClip click;
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Start () {
		Time.timeScale = 1;
		menuPausa.SetActive (false);
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Update () {
			if ((!pausa) && Input.GetKeyDown ( KeyCode.P)) {
				Time.timeScale = 0;
				GetComponent<AudioSource>().Pause();// Detiene el audio de la camara principal.
				pausa = true;
				menuPausa.SetActive(pausa);
			}else if ((pausa) && Input.GetKeyDown ( KeyCode.P)){
				Time.timeScale = 1;
				GetComponent<AudioSource>().Play();// Reproduce el audio del objeto que usa el script.
				pausa = false;
				menuPausa.SetActive(pausa);
			}else if ((pausa) && Input.GetKeyDown ( KeyCode.Escape)){
				Time.timeScale = 1;
				GetComponent<AudioSource>().Play();// Reproduce el audio del objeto que usa el script.
				pausa = false;
				menuPausa.SetActive(pausa);
			}
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	public void Pausar(){
		if (!pausa) {
			Time.timeScale = 0;
			GetComponent<AudioSource>().Pause();// Detiene el audio de la camara principal.
			pausa = true;
			menuPausa.SetActive(pausa);
		}else if (pausa){
			Time.timeScale = 1;
			GetComponent<AudioSource>().Play();// Reproduce el audio del objeto que usa el script.
			pausa = false;
			menuPausa.SetActive(pausa);
		}
	}
}
