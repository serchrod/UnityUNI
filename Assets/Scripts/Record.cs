using UnityEngine;
using System.Collections;

public class Record : MonoBehaviour {

	public TextMesh record;
	void Start () {
		record.text = EstadoJuego.estadoJuego.puntuacionMaxima.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
