using UnityEngine;
using System.Collections;

/*
	Para obtener la distancia se crea un header, o un apuntador a la diferencia entre la propidad transfom.position de
	dos objetos, esa diferencia es la magnitud del header lo que nos proporciona la distancia.
*/

public class distancia : MonoBehaviour {
	protected Transform playerTransform;// Variable quealmacena la propiedad transmform del personaje.
	protected Transform anclaTransform;// Variable quealmacena la propiedad transmform del objeto ancla.
	GameObject Jugador;// Variable del GameObject del personaje.
	GameObject Ancla;// Variable del GameObject del ancla.
	protected Vector2 heading;// Variable del apuntador que contiene la magnitud de la distancia.
	protected float distanciaMagnitud;// Variable que almacena el valor en real de la magnitud.
	public int dista;// Variable que almacena el valor redondeado de la magnitud.
	public int ajustarDistancia;// Variable que corrije el valor inicial de la distancia.
	public TextMesh dis;// Variable del objeto texto que recibe la distancia.
	public distancia Distancia;

	void Awake(){
		if(Distancia==null){
			Distancia = this;
			DontDestroyOnLoad(gameObject);
		}else if(Distancia!=this){
			Destroy(gameObject);
		}
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void Update() {
		medida ();// Llamada a a funcion de medicion.
		dis.text = dista.ToString () + "m";// Retorno de la distanca al objeto de texto, formateando a String.
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void medida(){
		Jugador = GameObject.FindGameObjectWithTag("Player");//Obteniendo el GameObject del personaje.
		Ancla = GameObject.FindGameObjectWithTag("Ancla");//Obteniendo el GameObject del ancla.
		playerTransform = Jugador.transform;//Obteniendo la propiedad transform del GameObject del personaje.
		anclaTransform = Ancla.transform;//Obteniendo la propiedad transform del GameObject del ancla.
		heading = anclaTransform.position - playerTransform.position;// Calculando la magnitud de la distancia.
		distanciaMagnitud = heading.magnitude;// Asignando la magnitud a la variable que almacena la distancia.
		dista = (Mathf.RoundToInt(distanciaMagnitud)- ajustarDistancia);// Redondeando y ajustando la distancia.

	}
}
