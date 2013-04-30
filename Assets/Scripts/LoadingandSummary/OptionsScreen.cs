using UnityEngine;
using System.Collections;

public class OptionsScreen : MonoBehaviour {
	
	public string level = "MainScene";
	private bool loading;
	public Texture loadingTexture;

	void OnGUI () {
		
		//Need to add loading screen on switch
		if(GUI.Button(new Rect(Screen.width-772,15,128,64),"Start Game")){
			loading = true;
			StartCoroutine("LoadMainLevel");
		}
		
		else if (GUI.Button(new Rect(Screen.width-772,90,128,64),"Load Game")){
			//StartCoroutine("LoadSave");
		}
		else if (GUI.Button(new Rect(Screen.width-772,165,128,64),"Settings")){
			//Not Implemented 
			//Possibly set size of map/etc here...
		}
		else if (GUI.Button(new Rect(Screen.width-772,240,128,64),"Exit Game")){
			Application.Quit();
		}
}
	
	void LoadMainLevel() {
		if(loading){
			Application.LoadLevel(level);
		}
	}
}
