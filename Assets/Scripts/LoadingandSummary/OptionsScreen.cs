using UnityEngine;
using System.Collections;

public class OptionsScreen : MonoBehaviour {
	
	public string level = "MainScene";
	private bool loading;
	public Texture loadingTexture;
	public GUIStyle customStyle;

	void OnGUI () {

		if(!loading){
			//Need to add loading screen on switch
			if(GUI.Button(new Rect(Screen.width/2-128/2,15,128,64),"Start Game")){
				loading = true;
				StartCoroutine("LoadMainLevel");
			}
			
			else if (GUI.Button(new Rect(Screen.width/2-128/2,90,128,64),"Load Game")){
				//StartCoroutine("LoadSave");
			}
			else if (GUI.Button(new Rect(Screen.width/2-128/2,165,128,64),"Settings")){
				//Not Implemented 
				//Possibly set size of map/etc here...
			}
			else if (GUI.Button(new Rect(Screen.width/2-128/2,240,128,64),"Exit Game")){
				Application.Quit();
			}
		} else{
			customStyle.normal.background = GUI.skin.box.normal.background;
			customStyle.fontStyle = FontStyle.Bold;
			customStyle.fontSize = 32;
			customStyle.alignment = TextAnchor.MiddleCenter;
			customStyle.normal.textColor = Color.white;


			GUI.Box(new Rect(-10,-10,Screen.width+20,Screen.height+20),"Loading...Please Wait",customStyle);

		}
}
	
	void LoadMainLevel() {
		if(loading){
			Application.LoadLevel(level);
		}
	}
}
