using UnityEngine;
using System.Collections;

public class kunais : MonoBehaviour {
	public int Kunais;
	public TextMesh kunaiContador;
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "kunaisRecogidas");//Agrega un observador de las kunais recogidas.
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void kunaisRecogidas(){
		Kunais++;
		kunaiContador.text = Kunais.ToString ();
		if (Kunais >= 5) {

		}
	}                                
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void OnEnable(){
		//kunaiContador.text = Kunais.ToString ();
	}
}
