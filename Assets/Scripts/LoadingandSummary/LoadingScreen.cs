using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	private bool loading = true;
	public Texture loadingTexture;
	
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.isLoadingLevel){
			loading=true;
		}else{
			loading=false;
		}
	}
	
	void OnGUI(){
		if(!loadingTexture){
			Debug.LogError ("Assign Texture");
			return;
		}
		if(loading){
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), loadingTexture, ScaleMode.StretchToFill);	
		}
	}
}
