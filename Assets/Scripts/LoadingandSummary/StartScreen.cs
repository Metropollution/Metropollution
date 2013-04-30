using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {
	
	public float timer = 1.5f;
	public string level = "StartUpScene";

	// Use this for initialization
	void Start () {
		StartCoroutine("DisplayScreen");
	}
	
	// Update is called once per frame
	IEnumerator DisplayScreen() {
		yield return new WaitForSeconds(timer);
		Application.LoadLevel(level);
	}
}