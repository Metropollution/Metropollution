using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class OptionsScreen : MonoBehaviour {
	
	public string level = "MainScene";
	private bool loading;
	private bool goal;
	public Texture loadingTexture;
	public GUIStyle customStyle;
	public GUIStyle customStyle2;

	private string turns = "100";
	private string cash = "9000";
	private string pop = "200";
	private string poll = "500";

	void Start () {
		turns = "100";
		cash = "9000";
		pop = "200";
		poll = "500";
	}

	void OnGUI () {

		if(!loading){
			//Need to add loading screen on switch
			if(goal){
				customStyle2.fontStyle = FontStyle.Bold;
				customStyle2.fontSize = 24;
				customStyle2.alignment = TextAnchor.UpperCenter;
				customStyle2.normal.textColor = Color.white;

				GUI.Box(new Rect(Screen.width/2-200, Screen.height/2-150, 400, 250),"");
				GUI.Label(new Rect(Screen.width/2-250,Screen.height/2-140,500,100),"Goal Conditions",customStyle2);

				customStyle2.alignment = TextAnchor.UpperLeft;
				customStyle2.fontStyle = FontStyle.Normal;
				customStyle2.fontSize = 18;

				GUI.Label(new Rect(Screen.width/2-180,Screen.height/2-100, 400, 50),"Number of Turns: ",customStyle2);
				turns = GUI.TextField(new Rect(Screen.width/2-10,Screen.height/2-99,190,20),turns,10);
				GUI.Label(new Rect(Screen.width/2-180,Screen.height/2-70, 400, 50),"Desired Population: ",customStyle2);
				cash = GUI.TextField(new Rect(Screen.width/2-10,Screen.height/2-69,190,20),cash,10);
				GUI.Label(new Rect(Screen.width/2-180,Screen.height/2-40, 400, 50),"Desired Income: ",customStyle2);
				pop = GUI.TextField(new Rect(Screen.width/2-10,Screen.height/2-39,190,20),pop,10);
				GUI.Label(new Rect(Screen.width/2-180,Screen.height/2-10, 400, 50),"Pollution Limit: ",customStyle2);
				poll = GUI.TextField(new Rect(Screen.width/2-10,Screen.height/2-9,190,20),poll,10);

				turns = Regex.Replace(turns,@"[^0-9]","");
				cash = Regex.Replace(cash,@"[^0-9]","");
				pop = Regex.Replace(pop,@"[^0-9]","");
				poll = Regex.Replace(poll,@"[^0-9]","");

				if(GUI.Button(new Rect(Screen.width/2-110,Screen.height/2+40,100,30),"Start")){
					int t = int.Parse(turns);
					int c = int.Parse(cash);
					int pp = int.Parse(pop);
					int pl = int.Parse(poll);

					PlayerPrefs.SetInt("turns",t);
					PlayerPrefs.SetInt("cash",c);
					PlayerPrefs.SetInt("population",pp);
					PlayerPrefs.SetInt("pollution",pl);

					loading = true;
					StartCoroutine("LoadMainLevel");
				}

				if(GUI.Button(new Rect(Screen.width/2+10,Screen.height/2+40,100,30),"Cancel")){
					goal = false;
				}
			} else{
				if(GUI.Button(new Rect(Screen.width/2-128/2,15,128,64),"Start Game")){
					goal = true;
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
