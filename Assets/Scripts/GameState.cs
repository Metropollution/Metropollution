using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	
	public int cash;
	public int pollution;
	public int population;
	public BuildingStruct[,] grid;
	public int gridSize;
	public int tick;
	
	private bool cashTick;
	
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
		population = 1;
		tick = 5;
		
		cashTick = true;
		
		grid = new BuildingStruct[gridSize,gridSize];
	}
	
	public bool PlaceBuilding(BuildingStruct x, Vector2 coord) {
		if(cash >= x.cost){
			cash -= x.cost;
			pollution += x.pollutionIndex;
			grid[(int)coord.x,(int)coord.y] = x;
			
			print("Build successful");
			
			return true;
		} else{
			print("Insufficient Cash");
			
			return false;
		}
	}
	
	public int cashFlow () { //contains formula for how much money is generated
		return population*20;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time%tick < 0.1) { // condition for time interval
			if(cashTick){
				cash += cashFlow();
				cashTick = false;
			}
		} else{
			cashTick = true;
		}
	}
}
