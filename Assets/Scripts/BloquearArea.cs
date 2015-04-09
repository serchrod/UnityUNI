using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/*
 * Este script bloquea un boton de la UI.
*/
public class BloquearArea : MonoBehaviour {
	public Text textoPuntajeRestante;// Propiedad Text a modificar.
	public GameObject textoPuntaje;// GameObject del Text de puntaje.
	public int limite;// Puntaje requrido para desbloquear.
	public Button boton;// Boton a bloquear.
	int puntosAcumulados;// Variable que toma el valor de la puntuacion acumulada.
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Start(){
        textoPuntaje.SetActive(true);
        EstadoMob.EstadoMobi.Cargar();
		Bloqueo ();
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Bloqueo() {
		puntosAcumulados = EstadoMob.EstadoMobi.acumulado;
		textoPuntajeRestante.text = "Puntaje restante: " + (limite-puntosAcumulados);
		if(puntosAcumulados >= limite){
			boton.enabled = true;
			textoPuntaje.SetActive(false);
		}else{
			boton.enabled = false;
		}
	}

}
