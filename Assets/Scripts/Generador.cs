using UnityEngine;
using System.Collections;
/*Script para la generacion de objetos.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class Generador : MonoBehaviour {
	public GameObject[] obj;// Arregloo de GameObjects.
	public float tiempoMin = 1.25f;// Tiempo minimo de generacion.
	public float tiempoMax = 2.5f;// Tiempo maximo de generacion.
	private bool fin = false;// Finalizar la generacion.
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeCorriendo");// Agrega un observador al estado corriendo.
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeMurio");// Agrega un observador al estado muerto.
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void personajeMurio(){
		fin = true;// Vuelva la finalizacion verdadera.
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void personajeCorriendo(){
		Generator ();// Llama al metodo generador.
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Generator(){
		if (!fin) {// Valida si no se ha finalizado la genereacion.
			//Instancia un objeto alaeatorio del arreglo de GameObject.
			Instantiate (obj[Random.Range(0,obj.Length)],transform.position, Quaternion.identity);
			Invoke ("Generator", Random.Range(tiempoMin, tiempoMax));// Vuelve a llamar al metodo Generador.
		}
	}
}
