using UnityEngine;
using System.Collections;

public class IAEnemigo : MonoBehaviour{

	public float targetspeed=1f,curspeed;
	private int counterframe=0;
	public Transform wandar;
	protected Vector2 destPos;
	protected Transform PlayerTransform;
	
	
	
	void Start () {
		
	}
	
	
	void Update () {
		FSM ();
		
	}
	void FSM(){
		
		curspeed = Mathf.Lerp (curspeed, targetspeed, 7.0f * Time.deltaTime);
		transform.Translate (-Vector2.right * Time.deltaTime * curspeed);
		
		
	}
}
