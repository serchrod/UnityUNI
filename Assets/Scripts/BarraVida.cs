using UnityEngine;
using System.Collections;

public class BarraVida : MonoBehaviour {
	public GUIStyle barraVida;
	public Texture2D imagenInterior;
	public Texture2D imagenExterior;
	public Texture2D marco;
	public float vidaMaxima = 160f;
	public float vidaRestante = 160f;
	public Vector2 barraPosicion = new Vector2(10, 10);
	public int alto = 10;
	public int ancho = 20;
	public GameObject character;// GameObject que se destruira cuando la vida llegue a 0.
	//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void FixedUpdate(){
		NotificationCenter.DefaultCenter().AddObserver(this,"impactado");
		if (vidaRestante <= 0) {
            Destroy(character.gameObject, 1);
		}
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void impactado(Notification notificiacion){
		vidaRestante -= 10f;
		Debug.Log ("Vida restante: " + vidaRestante);
	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void OnGUI(){
		DrawLife (barraPosicion.x, barraPosicion.y, imagenExterior, imagenInterior, vidaRestante);
		GUI.DrawTexture (new Rect(barraPosicion.x,barraPosicion.y,(marco.width - ancho),(marco.height - alto)), marco);

	}
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	void DrawLife(float x, float y, Texture2D texture, Texture2D background, float vidaRestante){
		var bgW = (background.width - ancho);
		var bgH = (background.height - alto);
		GUI.DrawTexture (new Rect (x, y, bgW, bgH), background);
		var nW = vidaRestante;
		GUI.BeginGroup (new Rect (x, y, nW, bgH));
		GUI.DrawTexture (new Rect (0, 0, bgW, bgH), texture);
		GUI.EndGroup ();

	}

}