using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActualizarValoresMain : MonoBehaviour {
	public GameObject record;
	public GameObject distan;
	public GameObject muertes;
	//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	public Text Record;
	public Text Distan;
	public Text Muertes;
	//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	string rec;
	string dis;
	string muer;


	// Use this for initialization
	void Start () {
		rec = EstadoMob.EstadoMobi.record.ToString();
		dis = EstadoMob.EstadoMobi.distanciaMax.ToString();
		muer = EstadoMob.EstadoMobi.muertesTotal.ToString();
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		//rec = XmlEstado.xmlEstado.puntuacionMax.ToString ();
		//dis = XmlEstado.xmlEstado.distanciaMax.ToString ();
		//muer = XmlEstado.xmlEstado.muertesTotal.ToString ();
		Distan = distan.GetComponent<Text> ();
		Distan.text = dis;
		Record = record.GetComponent<Text> ();
		Record.text = rec;// Actualiza el valor del record.
		Muertes = muertes.GetComponent<Text>();
		Muertes.text = muer;// Muestra las muertes en el objeto texto.
	}

}
