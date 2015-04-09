using UnityEngine;
using System.Collections;

public class GameOverMobi : MonoBehaviour {
	public TextMesh distan;// Texto que muestra la distancia recorrida.
	public TextMesh record;// Elemento Texto que mostrara el record maximo del juego.
	public TextMesh muertes;// Texto que muestra las muertes.
	public TextMesh puntos;// Texto que muestra los puntos.
	public PuntuacionMob puntua;
	public distancia Distancia;
	//Metodo OnEneable que cuando se encuentra disponible actualiza el contenido de los elementos de tipo Texto.
	void OnEnable(){
		puntos.text = puntua.puntuacion.ToString ();// Actualiza el valor del total.
		distan.text = Distancia.dista.ToString();
		record.text = EstadoMob.EstadoMobi.record.ToString();// Actualiza el valor del record.
		muertes.text = EstadoMob.EstadoMobi.dies.ToString();// Muestra las muertes en el objeto texto.
	}
}
