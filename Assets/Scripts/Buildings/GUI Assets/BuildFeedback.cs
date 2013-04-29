using UnityEngine;
using System.Collections;

public class BuildFeedback : MonoBehaviour {
	public int money = 0;
	public bool moneyActivated = false;
	public bool error = false;
	private float countdown;
	public Texture cross;

	public GUIStyle customStyle;

	void OnGUI(){
		Vector2 screenCoord = Camera.main.WorldToViewportPoint(transform.position);

		customStyle.normal.textColor = Color.white;
		customStyle.alignment = TextAnchor.MiddleCenter;
		customStyle.fontSize = 16;
		customStyle.fontStyle = FontStyle.Bold;

		if(moneyActivated){
			GUI.Box(new Rect((screenCoord.x*Screen.width)-21.5f,Screen.height-(screenCoord.y*Screen.height)-20.0f-countdown,50,30),"");
			if(money >= 0){
				if(money != 0){
					customStyle.normal.textColor = Color.green;
				} else{
					customStyle.normal.textColor = Color.white;
				}
				GUI.Label(new Rect((screenCoord.x*Screen.width)-21.5f,Screen.height-(screenCoord.y*Screen.height)-20.0f-countdown,50,30),"$"+money,customStyle);
			} else{
				customStyle.normal.textColor = Color.red;
				GUI.Label(new Rect((screenCoord.x*Screen.width)-21.5f,Screen.height-(screenCoord.y*Screen.height)-20.0f-countdown,50,30),"-$"+(-money),customStyle);
			}
		} else if(error){
			GUI.Label(new Rect((screenCoord.x*Screen.width)-11.5f,Screen.height-(screenCoord.y*Screen.height)-20.0f-countdown,30,30),cross);
		}
	}

	void Update(){
		if(moneyActivated || error){
			countdown+=1.0f;
		}

		if(countdown > 40){
			Destroy(this.gameObject);
		}
	}
}
