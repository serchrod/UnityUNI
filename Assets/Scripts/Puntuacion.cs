using UnityEngine;
using System.Collections;
/*Script para puntaje.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class Puntuacion : MonoBehaviour {

	public int puntuacion = 0;// Puntuacion de lapartida.
	public TextMesh marcador;// Texto que muestra la puntuacion.
	public distancia Distancia;// Variable de tipo "distancia" que recibe un objeto con el script de distancia.
	
	void Start () {
		if(XmlEstado.xmlEstado.dies>0){
			XmlEstado.xmlEstado.dies -= 1;
		}
		//Agrega un observador de los puntos ganados.
		NotificationCenter.DefaultCenter ().AddObserver (this, "ganarPuntos");
		//Agrega un observador al estado muerto.
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeMurio");
	}

	void personajeMurio(Notification notificacion){
		XmlEstado.xmlEstado.dies+= 1;
		if(puntuacion > XmlEstado.xmlEstado.puntuacionMax){// Valida que la puntuacion actual se mayor que el record.
			XmlEstado.xmlEstado.puntuacionMax = puntuacion;// Actualiza el valor del record con la puntuacion actual.
			XmlEstado.xmlEstado.WriteToXml();// Guarda los datos.
		}
		if(XmlEstado.xmlEstado.dies > XmlEstado.xmlEstado.muertesTotal){
			XmlEstado.xmlEstado.muertesTotal = XmlEstado.xmlEstado.dies-1;
			XmlEstado.xmlEstado.WriteToXml();// Guarda los datos.
		}
		if(Distancia.dista > XmlEstado.xmlEstado.distanciaMax){
			XmlEstado.xmlEstado.distanciaMax = Distancia.dista;
			XmlEstado.xmlEstado.WriteToXml();// Guarda los datos.
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

	public void guardar(){
		if(puntuacion > XmlEstado.xmlEstado.puntuacionMax){// Valida que la puntuacion actual se mayor que el record.
			XmlEstado.xmlEstado.puntuacionMax = puntuacion;// Actualiza el valor del record con la puntuacion actual.
			XmlEstado.xmlEstado.WriteToXml();// Guarda los datos.
		}
		if(XmlEstado.xmlEstado.dies > XmlEstado.xmlEstado.muertesTotal){
			XmlEstado.xmlEstado.muertesTotal = XmlEstado.xmlEstado.dies-1;
			XmlEstado.xmlEstado.WriteToXml();// Guarda los datos.
		}
		if(Distancia.dista > XmlEstado.xmlEstado.distanciaMax){
			XmlEstado.xmlEstado.distanciaMax = Distancia.dista;
			XmlEstado.xmlEstado.WriteToXml();// Guarda los datos.
		}
	}
}
