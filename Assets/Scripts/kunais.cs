using UnityEngine;
using System.Collections;

public class kunais : MonoBehaviour {
	public int Kunais;
	public TextMesh kunaiContador;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "kunaisRecogidas");//Agrega un observador de las kunais recogidas.
	}

	void kunaisRecogidas(){
		Kunais++;
		kunaiContador.text = Kunais.ToString ();
		if (Kunais >= 5) {

		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		//kunaiContador.text = Kunais.ToString ();
	}
}
