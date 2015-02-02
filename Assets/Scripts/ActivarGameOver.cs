using UnityEngine;
using System.Collections;

public class ActivarGameOver : MonoBehaviour {

	public GameObject CameraGameOver;
	public AudioClip gameOverClip;

	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeMurio");
	}
	
	void personajeMurio(Notification notificacion){
		audio.Stop ();
		audio.clip = gameOverClip;
		audio.loop = false;
		audio.Play ();
		CameraGameOver.SetActive(true);
	}

	void Update () {
	
	}
}
