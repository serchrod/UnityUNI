using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BloquearArea : MonoBehaviour {
	public Text textoPuntajeRestante;
	public GameObject textoPuntaje;
	public int limite;
	public Button boton;
	int limiteP;

	void Start(){
		textoPuntaje.SetActive(true);
		Bloqueo ();
	}

	void Bloqueo() {
		//Para escritorio
		//limiteP = XmlEstado.xmlEstado.puntuacionMax;
		//Para Mobi
		limiteP = EstadoMob.EstadoMobi.record;
		textoPuntajeRestante.text = "Puntaje restante: " + (limite-limiteP);
		if(limiteP >= limite){
			boton.enabled = true;
			textoPuntaje.SetActive(false);
		}else{
			boton.enabled = false;
		}
	}

}
