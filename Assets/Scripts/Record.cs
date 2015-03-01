using UnityEngine;
using System.Collections;
/*Script del record.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class Record : MonoBehaviour {

	public TextMesh record;
	void Start () {
		//Muestra en el objeto texto el record del juego.
		record.text = EstadoJuego.estadoJuego.puntuacionMaxima.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
