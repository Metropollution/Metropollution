using UnityEngine;
using System.Collections;

public class SummaryScreen : MonoBehaviour {
	
	static bool show = false;
	GUILayout displayLayout;
	GUIText cash;
	GUIText population;
	GUIText pollution;

	// Use this for initialization
	void Start () {
		InitializeVariables();
		setText();
		//show = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(show){
			DisplaySummary();	
		}
	}
	
	void InitializeVariables(){
		show = false;  
		cash = new GUIText();
		population = new GUIText();
		pollution = new GUIText();
	}
	
	void setText(){
		cash.text = GameState.Instance.cash.ToString();
		population.text = GameState.Instance.population.ToString();
		pollution.text = GameState.Instance.pollution.ToString();
	}
	
	
	void DisplaySummary(){
		//TODO
	}
	
	
}
