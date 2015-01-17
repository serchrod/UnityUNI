using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {

	public GameObject[] obj;
	public float tiempoMin = 1.25f;
	public float tiempoMax = 2.5f;
	private bool fin = false;
	// Use this for initialization
	void Start () {
		//Generator();
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeCorriendo");
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeMurio");
	}
	void personajeMurio(){
		fin = true;
	}
	void personajeCorriendo(){
		Generator ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Generator(){
		if (!fin) {
			Instantiate (obj[Random.Range(0,obj.Length)],transform.position, Quaternion.identity);
			Invoke ("Generator", Random.Range(tiempoMin, tiempoMax));
		}
	}
}
