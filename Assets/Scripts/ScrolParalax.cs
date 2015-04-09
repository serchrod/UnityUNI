using UnityEngine;
using System.Collections;
/*Script del scrollParalax el moviento del fondo.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class ScrolParalax : MonoBehaviour {
	public bool iniciarEnMovimiento = false;// Inicializacion del movimiento de los sprites.
	public float velocidad = 0f;// Velocidad del movimiento.
	private bool EnMoviento = false;
	private float tiempoInico = 0f;
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeCorriendo");
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeMurio");
		if (iniciarEnMovimiento) {
			EnMoviento = true;
		}
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void personajeMurio(){
		EnMoviento = false;
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void personajeCorriendo(){
		EnMoviento = true;
		tiempoInico = Time.time;
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Update () {
		if (EnMoviento) {
			renderer.material.mainTextureOffset = new Vector2(((Time.time - tiempoInico) * velocidad) %1, 0);
		}
	}
}
