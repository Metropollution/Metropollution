using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	public GUIStyle customStyle;
	public Texture play;
	public Texture pause;
	public Texture back;
	public Texture forward;
	public Texture fastback;
	public Texture fastforward;

	private int tempPop;
	private int tempPoll;

	public static bool hideCursor;
	
	private bool isPaused = true;
	
	void OnGUI () {
		if(!GameState.Instance.gameEnd){
			customStyle.normal.textColor = Color.white;
			customStyle.alignment = TextAnchor.MiddleCenter;
			customStyle.fontSize = 17;
			
			GUI.Box(new Rect(Screen.width-191,25,170,132),"");
			GUI.Label(new Rect(Screen.width-195,25,170,30),"Cash: "+GameState.Instance.cash,customStyle);
			GUI.Label(new Rect(Screen.width-195,50,170,30),"Population: "+GameState.Instance.population,customStyle);
			GUI.Label(new Rect(Screen.width-195,75,170,30),"Pollution: "+GameState.Instance.pollution,customStyle);
			GUI.Label(new Rect(Screen.width-195,100,170,30),"Turns Passed: "+GameState.Instance.turnsPassed,customStyle);

			if(GameState.Instance.powerUsage > GameState.Instance.powerOutput){
				customStyle.normal.textColor = Color.red;
			}
			GUI.Label(new Rect(Screen.width-195,125,170,30),"Power Usage: "+GameState.Instance.powerUsage+"/"+GameState.Instance.powerOutput,customStyle);
			
			GUI.Box(new Rect(Screen.width-191,161,170,40),"");
			
			if(GUI.Button(new Rect(Screen.width-188,165,32,32),fastback)){
				if(GameState.Instance.tick < 40){
					GameState.Instance.tick *= 4;
				} else{
					GameState.Instance.tick = 0;
				}
				
				if(GameState.Instance.tick == 0){
					isPaused = true;
				}
			}
			
			if(GUI.Button(new Rect(Screen.width-155,165,32,32),back)){
				if(GameState.Instance.tick < 40){
					GameState.Instance.tick *= 2;
				} else{
					GameState.Instance.tick = 0;
				}
				
				if(GameState.Instance.tick == 0){
					isPaused = true;
				}
			}
			
			if((GUI.Button(new Rect(Screen.width-89,165,32,32),forward)) && GameState.Instance.tick > 0.2){
				GameState.Instance.tick /= 2;
			}
			if((GUI.Button(new Rect(Screen.width-56,165,32,32),fastforward)) && GameState.Instance.tick > 0.5){
				GameState.Instance.tick /= 4;
			}
			
			if(isPaused){
				if(GUI.Button(new Rect(Screen.width-122,165,32,32),play)){
					GameState.Instance.tick = 5;
					isPaused = false;
				}
			} else{
				if(GUI.Button(new Rect(Screen.width-122,165,32,32),pause)){
					GameState.Instance.tick = 0;
					isPaused = true;
				}
			}

			GUI.Box(new Rect(Screen.width-191,Screen.height-158,170,140),"");

			customStyle.fontSize = 20;
			customStyle.fontStyle = FontStyle.Bold;
			GUI.Label(new Rect(Screen.width-195,Screen.height-155,170,30),"Goal Conditions",customStyle);

			customStyle.fontSize = 17;
			customStyle.fontStyle = FontStyle.Normal;
			GUI.Label(new Rect(Screen.width-195,Screen.height-125,170,30),"Turns Limit: "+GameState.Instance.goalTurns,customStyle);
			GUI.Label(new Rect(Screen.width-195,Screen.height-100,170,30),"Cash: "+GameState.Instance.goalCash,customStyle);
			GUI.Label(new Rect(Screen.width-195,Screen.height-75,170,30),"Population: "+GameState.Instance.goalPop,customStyle);
			GUI.Label(new Rect(Screen.width-195,Screen.height-50,170,30),"Pollution: "+GameState.Instance.goalPoll,customStyle);
		}
	}

	void LateUpdate() {
		if(hideCursor){
			Screen.showCursor = false;
		} else{
			Screen.showCursor = true;
		}

		hideCursor = false;
	}
}
