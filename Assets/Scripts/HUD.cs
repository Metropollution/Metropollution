using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	public GUIStyle customStyle;
	
	void OnGUI () {
		customStyle.normal.background = GUI.skin.box.normal.background;
		customStyle.normal.textColor = GUI.skin.box.normal.textColor;
		customStyle.alignment = TextAnchor.MiddleLeft;
		customStyle.fontSize = 18;
		
		GUI.Box(new Rect(25, Screen.height-60,150,40),"Cash: "+GameState.Instance.cash,customStyle);
		GUI.Box(new Rect((Screen.width/2)-75, Screen.height-60,150,40),"Population: "+GameState.Instance.population,customStyle);
		GUI.Box(new Rect(Screen.width-175, Screen.height-60,150,40),"Pollution: "+GameState.Instance.pollution,customStyle);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
