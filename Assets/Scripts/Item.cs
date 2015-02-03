using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public int puntosIncrementar = 5;
	public AudioClip itemSoundClip;
	public float itemSoundLevel = 1f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player") {
			NotificationCenter.DefaultCenter().PostNotification(this,"ganarPuntos",puntosIncrementar);
			AudioSource.PlayClipAtPoint(itemSoundClip, Camera.main.transform.position, itemSoundLevel);
			Destroy (gameObject);
		}
	}
}
