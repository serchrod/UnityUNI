using UnityEngine;
using System.Collections;
/*Script que actualiza los valores que se muestran en el Game Over.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class ActualizarValoresGameOver : MonoBehaviour {

	public TextMesh total;// Elemento Texto que mostrara la puntiacion alcanzada.
	public TextMesh record;// Elemento Texto que mostrara el record maximo del juego.
	public Puntuacion puntuacion;// Variable de tipo Puntuacion que almacenara la puntuacion de la partida.
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Metodo OnEneable que cuando se encuentra disponible actualiza el contenido de los elementos de tipo Texto.
	void OnEnable(){
		total.text = puntuacion.puntuacion.ToString ();// Actualiza el valor del total.
		//record.text = EstadoJuego.estadoJuego.puntuacionMaxima.ToString ();// Actualiza el valor del record.
		record.text = XmlEstado.xmlEstado.puntuacionMax.ToString();// Actualiza el valor del record.
	}
}
