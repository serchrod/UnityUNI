using UnityEngine;
using System.Collections;
/*Script que actualiza los valores que se muestran en el Game Over.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class ActualizarValoresGameOver : MonoBehaviour {
	
	public TextMesh distan;// Texto que muestra la distancia recorrida.
	public TextMesh record;// Elemento Texto que mostrara el record maximo del juego.
	public TextMesh muertes;// Texto que muestra las muertes.
	public TextMesh puntos;// Texto que muestra los puntos.
	public Puntuacion puntuacion;// Variable de tipo Puntuacion que almacenara la puntuacion de la partida.
	public distancia Distancia;

	//Metodo OnEneable que cuando se encuentra disponible actualiza el contenido de los elementos de tipo Texto.
	void OnEnable(){
		puntos.text = puntuacion.puntuacion.ToString ();// Actualiza el valor del total.
		distan.text = Distancia.dista.ToString();
		record.text = XmlEstado.xmlEstado.puntuacionMax.ToString();// Actualiza el valor del record.
		muertes.text = XmlEstado.xmlEstado.dies.ToString();// Muestra las muertes en el objeto texto.
	}
}
