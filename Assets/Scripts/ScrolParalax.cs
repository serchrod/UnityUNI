using UnityEngine;
using System.Collections;

public class ScrolParalax : MonoBehaviour {
	public bool iniciarEnMovimiento = false;
	public float velocidad = 0f;
	private bool EnMoviento = false;
	private float tiempoInico = 0f;
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeCorriendo");
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeMurio");
		if (iniciarEnMovimiento) {
			EnMoviento = true;
		}
	}
	void personajeMurio(){
		EnMoviento = false;
	}
	void personajeCorriendo(){
		EnMoviento = true;
		tiempoInico = Time.time;
	}
	// Update is called once per frame
	void Update () {
		if (EnMoviento) {
			renderer.material.mainTextureOffset = new Vector2(((Time.time - tiempoInico) * velocidad) %1, 0);
		}
	}
}
