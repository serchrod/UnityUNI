using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour 
{
    //Player Transform
    protected Transform playerTransform;

    // la posicion del objeto
    protected Vector2 destPos;

    //el arreglo de todo los objetos del tipo Wandar
    protected GameObject[] pointList;

    // el hadouken y velocidad de disparo
    protected float shootRate;
    protected float elapsedTime;

	//brazo de donde instancia el hadouken, se pone el get; y el set; para obtener el hadouken
    
    public Transform bulletSpawnPoint { get; set; }
	// metodos que se encuentra por herencia
    protected virtual void Initialize() { }
    protected virtual void FSMUpdate() { }
    protected virtual void FSMFixedUpdate() { }

	// Use this for initialization
	void Start () 
    {   //metodo de inicializacion
        Initialize();
	}
	
	// Update is called once per frame
	void Update () 
    {
		//manda a llamar por cuadro
        FSMUpdate();
	}

    void FixedUpdate()
    {
        FSMFixedUpdate();
    }    
}
