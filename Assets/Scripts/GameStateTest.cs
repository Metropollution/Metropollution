using UnityEngine;
using System.Collections;

public class GameStateTest : MonoBehaviour {
	void OnGUI() {
		GUI.Box(new Rect(10,10,100,25),"Cash: "+GameState.Instance.cash);
		
		if(GUI.Button(new Rect(10,50,100,25),"Increment cash")){
			GameState.Instance.cash++;	
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
