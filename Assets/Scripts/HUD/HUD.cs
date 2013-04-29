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
	
	private bool isPaused = false;
	
	private
	
	void OnGUI () {
		customStyle.normal.textColor = Color.white;
		customStyle.alignment = TextAnchor.MiddleCenter;
		customStyle.fontSize = 17;
		
		GUI.Box(new Rect(Screen.width-191,25,170,107),"");
		GUI.Label(new Rect(Screen.width-195,25,170,30),"Cash: "+GameState.Instance.cash,customStyle);
		GUI.Label(new Rect(Screen.width-195,50,170,30),"Population: "+GameState.Instance.population,customStyle);
		GUI.Label(new Rect(Screen.width-195,75,170,30),"Pollution: "+GameState.Instance.pollution,customStyle);
		GUI.Label(new Rect(Screen.width-195,100,170,30),"Turns Passed: "+GameState.Instance.turnsPassed,customStyle);
		
		GUI.Box(new Rect(Screen.width-191,136,170,40),"");
		
		if(GUI.Button(new Rect(Screen.width-188,140,32,32),fastback)){
			if(GameState.Instance.tick < 40){
				GameState.Instance.tick *= 4;
			} else{
				GameState.Instance.tick = 0;
			}
			
			if(GameState.Instance.tick == 0){
				isPaused = true;
			}
		}
		
		if(GUI.Button(new Rect(Screen.width-155,140,32,32),back)){
			if(GameState.Instance.tick < 40){
				GameState.Instance.tick *= 2;
			} else{
				GameState.Instance.tick = 0;
			}
			
			if(GameState.Instance.tick == 0){
				isPaused = true;
			}
		}
		
		if((GUI.Button(new Rect(Screen.width-89,140,32,32),forward)) && GameState.Instance.tick > 0.2){
			GameState.Instance.tick /= 2;
		}
		if((GUI.Button(new Rect(Screen.width-56,140 ,32,32),fastforward)) && GameState.Instance.tick > 0.2){
			GameState.Instance.tick /= 4;
		}
		
		if(isPaused){
			if(GUI.Button(new Rect(Screen.width-122,140,32,32),play)){
				GameState.Instance.tick = 5;
				isPaused = false;
			}
		} else{
			if(GUI.Button(new Rect(Screen.width-122,140,32,32),pause)){
				GameState.Instance.tick = 0;
				isPaused = true;
			}
		}
	}
}
