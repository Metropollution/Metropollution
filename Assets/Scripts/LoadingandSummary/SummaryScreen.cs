using UnityEngine;
using System.Collections;

public class SummaryScreen : MonoBehaviour {
	
	static bool show = false;
	GameObject gameState;
	GUILayout displayLayout;
	GUIText cash;
	GUIText population;
	GUIText pollution;

	// Use this for initialization
	void Start () {
		gameState = new GameObject();
		InitializeVariables();
		setText();
		show = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(show){
			DisplaySummary();	
		}
	}
	
	void InitializeVariables(){
		gameState = GetComponent<GameState>();
		show = false;  
		cash = new GUIText();
		population = new GUIText();
		pollution = new GUIText();
	}
	
	void setText(){
		cash.text = GameState.MyInstance.cash.ToString();
		population.text = GameState.MyInstance.pollution.ToString();
		pollution.text = GameState.MyInstance.pollution.ToString();
	}
	
	
	void DisplaySummary(){
		//TODO
	}
	
	
}
