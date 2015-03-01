using UnityEngine;
using System.Collections;
/*Script para puntaje.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class Puntuacion : MonoBehaviour {
	public int puntuacion = 0;// Puntuacion de lapartida.
	public TextMesh marcador;// Texto que muestra la puntuacion.
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "ganarPuntos");//Agrega un observador de los puntos ganados.
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeMurio");//Agrega un observador al estado muerto.
		actualizarMarcador ();// Llama al metod que actualiza el marcador.
	}

	void personajeMurio(Notification notificacion){
		if(puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima){// Valida que la puntuacion actual se mayor que el record.
			EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;// Actualiza el valor del record con la puntuacion actual.
			EstadoJuego.estadoJuego.Guardar();// Guarda los datos.
		}
	}

	void ganarPuntos(Notification notificacion){
		int puntosAIncrementar = (int)notificacion.data;//Asigna el valor de los puntos a una variable entera.
		puntuacion += puntosAIncrementar;//Se actualiza el valor de la puntuacion.
		actualizarMarcador ();// Llama al metodo que actualiza el marcador.
	}

	void actualizarMarcador(){
		marcador.text = puntuacion.ToString ();// Muestra la puntuacion en el objeto texto.
	}

	void Update () {
	
	}
}
