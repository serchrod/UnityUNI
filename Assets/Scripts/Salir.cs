﻿using UnityEngine;
using System.Collections;

public class Salir : MonoBehaviour {

	// Use this for initialization
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
		Application.Quit ();
	}
}
