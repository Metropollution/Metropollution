using UnityEngine;
using System.Collections;

public class SummaryScreen : MonoBehaviour {
	
	static bool show = false;
	string cash = "";
	string population = "";
	string pollution = "";
	public GUIStyle customStyle;
	public GUIStyle topStyle;
	
	void setBoolTrue(){
		show = true;
	}
	
	void setBoolFalse(){
		show = false;	
	}
	
	void OnGUI(){
		
		if(show){
			
			//Grab current state values
			cash = GameState.Instance.cash.ToString();
			population = GameState.Instance.population.ToString();
			pollution = GameState.Instance.pollution.ToString();
			
			//Set up CustomGUIs
			topStyle.normal.background = GUI.skin.box.normal.background;
			topStyle.fontStyle = FontStyle.Bold;
			topStyle.fontSize = 54;
			topStyle.alignment = TextAnchor.MiddleCenter;
			topStyle.normal.textColor = Color.white;
			customStyle.normal.background = GUI.skin.box.normal.background;
			customStyle.fontStyle = FontStyle.Bold;
			customStyle.fontSize = 32;
			customStyle.alignment = TextAnchor.MiddleCenter;
			customStyle.normal.textColor = Color.white;
		
			//Left Side Display
			GUILayout.BeginArea(new Rect(0,0,Screen.width/2,80));
				GUILayout.Box("Real World Statistics", topStyle);
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(0,75,Screen.width/2,Screen.height));
				GUILayout.Box("Regional Pollution: One" + "\n" , customStyle);
				GUILayout.Box("Regional Economy: Bunches" +"\n", customStyle);
				GUILayout.Box("Regional Population: 9000" + "\n", customStyle);
			GUILayout.EndArea();
		
			//Right Side Display
			GUILayout.BeginArea(new Rect(Screen.width/2,0,Screen.width/2,80));
				GUILayout.Box("Player Summary",topStyle);
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(Screen.width/2,75,Screen.width/2,Screen.height));
				GUILayout.Box("Pollution: " + pollution + "\n",customStyle);
				GUILayout.Box("Economy: " + cash + "\n",customStyle);
				GUILayout.Box("Population: " + population + "\n",customStyle);
			GUILayout.EndArea();
			
		}

	}
	
	
}
