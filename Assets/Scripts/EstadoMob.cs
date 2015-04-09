using UnityEngine;
using System.Collections;

public class EstadoMob : MonoBehaviour {

	public int record;
	public int distanciaMax;
	public int muertesTotal;
	public int dies;
	public int acumulado;
	public static EstadoMob EstadoMobi;
	
	void Awake(){
		if(EstadoMobi==null){
			EstadoMobi = this;
			DontDestroyOnLoad(gameObject);
		}else if(EstadoMobi!=this){
			Destroy(gameObject);
		}
	}

	void Start(){
		Cargar ();
	}

	public void Guardar () {
		PlayerPrefs.SetInt ("record",record);
		PlayerPrefs.SetInt ("distanciaMax", distanciaMax);
		PlayerPrefs.SetInt ("muertesTotal", muertesTotal);
		PlayerPrefs.SetInt ("acumulado", acumulado);
	}

	public void Cargar(){
		record = PlayerPrefs.GetInt ("record");
		distanciaMax = PlayerPrefs.GetInt ("distanciaMax");
		muertesTotal = PlayerPrefs.GetInt ("muertesTotal");
		acumulado = PlayerPrefs.GetInt ("acumulado");
	}

}
