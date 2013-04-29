using UnityEngine;
using System.Collections;

public class PowerIconBlink : MonoBehaviour {
	private bool isOnScreen = true;
	private int translate = 10000;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("Translate",0,1.0f);
	}
	
	private void Translate() {
		if(isOnScreen){
			transform.Translate(new Vector3(0,translate,0));
		}else{
			transform.Translate(new Vector3(0,-translate,0));
		}
		isOnScreen = !isOnScreen;
	}
}
