using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	
	public int cash;
	public int pollution;
	public int population;
	
	public static GameState MyInstance;
	public static GameState Instance {
		get {
			if (MyInstance == null) {
				MyInstance = (GameState)FindObjectOfType(typeof(GameState));
			}
			return MyInstance;
		}
	}
	
	// Use this for initialization
	void Start () {
		MyInstance = this;
		cash = 20;
		pollution = 0;
		population = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
