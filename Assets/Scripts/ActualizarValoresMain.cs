using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
 * Este script muestra los distintos puntajes del juego en una UI de Unity. 
*/ 
public class ActualizarValoresMain : MonoBehaviour {
	public Text Record;// Variable de tipo Text de la UI.
	public Text Distan;// Variable de tipo Text de la UI.
	public Text Muertes;// Variable de tipo Text de la UI.
	public Text Acumulado;// Variable de tipo Text de la UI.
	//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	string rec;
	string dis;
	string muer;
	string acum;

	// Use this for initialization
	void Start () {
		rec = EstadoMob.EstadoMobi.record.ToString();
		dis = EstadoMob.EstadoMobi.distanciaMax.ToString();
		muer = EstadoMob.EstadoMobi.muertesTotal.ToString();
		acum = EstadoMob.EstadoMobi.acumulado.ToString();
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		Distan.text = dis;// Actualiza el valor de la distancia recorrida.
		Record.text = rec;// Actualiza el valor del record.
		Muertes.text = muer;// Actualiza el valor del maximo de muertes por partida.
		Acumulado.text = acum;// Actualiza el valor del puntaje acumulado.
	}

}
