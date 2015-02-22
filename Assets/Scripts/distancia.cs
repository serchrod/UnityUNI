using UnityEngine;
using System.Collections;

public class distancia : MonoBehaviour {
	protected Transform playerTransform;
	protected Transform anclaTransform;
	GameObject Jugador;
	GameObject Ancla;
	protected Vector2 heading;
	protected float distanciaMagnitud;
	public int dista;
	public TextMesh dis;
	void Start(){
	
	}

	void Update() {
		medida ();
		dis.text = dista.ToString () + "m";
	}

	void medida(){
		Jugador = GameObject.FindGameObjectWithTag("Player");
		Ancla = GameObject.FindGameObjectWithTag("Ancla");

		playerTransform = Jugador.transform;
		anclaTransform = Ancla.transform;
		heading = anclaTransform.position - playerTransform.position;
		distanciaMagnitud = heading.magnitude;
		dista = (Mathf.RoundToInt(distanciaMagnitud)-2);

	}
}
