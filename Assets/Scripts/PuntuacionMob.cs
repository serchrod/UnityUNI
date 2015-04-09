using UnityEngine;
using System.Collections;

public class PuntuacionMob : MonoBehaviour {

	public int puntuacion = 0;// Puntuacion de lapartida.
	public TextMesh marcador;// Texto que muestra la puntuacion.
	public distancia Distancia;// Variable de tipo "distancia" que recibe un objeto con el script de distancia.
	int acumulado;
	void Start () {
		acumulado = EstadoMob.EstadoMobi.acumulado;
        Debug.Log("Acumulado: " + acumulado);
		if(EstadoMob.EstadoMobi.dies > 1){
			EstadoMob.EstadoMobi.dies-=1;
		}
		//Agrega un observador de los puntos ganados.
		NotificationCenter.DefaultCenter ().AddObserver (this, "ganarPuntos");
		//Agrega un observador al estado muerto.
		NotificationCenter.DefaultCenter ().AddObserver (this, "personajeMurio");
	}
	
	void personajeMurio(Notification notificacion){
		EstadoMob.EstadoMobi.dies+= 1;
		if(puntuacion > EstadoMob.EstadoMobi.record){
			EstadoMob.EstadoMobi.record = puntuacion;
			EstadoMob.EstadoMobi.Guardar ();
		}
		if(Distancia.dista > EstadoMob.EstadoMobi.distanciaMax){
			EstadoMob.EstadoMobi.distanciaMax = Distancia.dista;
			EstadoMob.EstadoMobi.Guardar ();
		}
		if(EstadoMob.EstadoMobi.dies > EstadoMob.EstadoMobi.muertesTotal){
			EstadoMob.EstadoMobi.muertesTotal = EstadoMob.EstadoMobi.dies-1;
			EstadoMob.EstadoMobi.Guardar ();
		}
		//Puntaje acumulado.
        EstadoMob.EstadoMobi.acumulado = acumulado;
        EstadoMob.EstadoMobi.Guardar();
	}
	
	void ganarPuntos(Notification notificacion){
		int puntosAIncrementar = (int)notificacion.data;//Asigna el valor de los puntos a una variable entera.
		puntuacion += puntosAIncrementar;//Se actualiza el valor de la puntuacion.
		actualizarMarcador ();// Llama al metodo que actualiza el marcador.
        acumulado += puntuacion;
        Debug.Log("Actualizacion de acumulado" + acumulado);
	}
	
	void actualizarMarcador(){
		marcador.text = puntuacion.ToString ();// Muestra la puntuacion en el objeto texto.
	}
	
	public void guardar(){
		if(puntuacion > EstadoMob.EstadoMobi.record){
			EstadoMob.EstadoMobi.record = puntuacion;
			EstadoMob.EstadoMobi.Guardar ();
		}
		if(Distancia.dista > EstadoMob.EstadoMobi.distanciaMax){
			EstadoMob.EstadoMobi.distanciaMax = Distancia.dista;
			EstadoMob.EstadoMobi.Guardar ();
		}
		if(EstadoMob.EstadoMobi.dies > EstadoMob.EstadoMobi.muertesTotal){
			EstadoMob.EstadoMobi.muertesTotal = EstadoMob.EstadoMobi.dies-1;
			EstadoMob.EstadoMobi.Guardar ();
		}
        //Puntaje acumulado.
        EstadoMob.EstadoMobi.acumulado = acumulado;
        EstadoMob.EstadoMobi.Guardar();

	}
}