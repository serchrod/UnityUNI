using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {
	public int puntuacion = 0;
	public TextMesh marcador;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "ganarPuntos");
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeMurio");
		actualizarMarcador ();
	}

	void personajeMurio(Notification notificacion){
		if(puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima){
			EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
			EstadoJuego.estadoJuego.Guardar();
		}
	}

	void ganarPuntos(Notification notificacion){
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion += puntosAIncrementar;
		actualizarMarcador ();
	}

	void actualizarMarcador(){
		marcador.text = puntuacion.ToString ();
	}

	void Update () {
	
	}
}
