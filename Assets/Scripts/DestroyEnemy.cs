using UnityEngine;
using System.Collections;
/*Script para destruir un enemigo.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class DestroyEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Metodo OnCollisionEnter
	private void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Enemy") {// Valida si se ha colisionado con un objeto con la etiquta "Enemy".
			Destroy(collision.gameObject);// Destruye el objeto.
		}
	}
}
