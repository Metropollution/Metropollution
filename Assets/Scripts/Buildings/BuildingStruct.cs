using UnityEngine;
using System.Collections;

public class BuildingStruct : MonoBehaviour {
	// All buildings should inherit this class
	
	public int cost;
	public int populationSupport;
	public int pollutionIndex;
	public bool isConnected;
	public bool flag;
	public Vector2 coordinates;
	
	public void Build(Vector2 coord) {
		GameState.Instance.PlaceBuilding(this, coord);
		coordinates = coord;
	}
	
	// Update is called once per frame
	void Update() {
		if(isConnected && !flag){
			GameState.Instance.population += populationSupport;
			flag = true;
		}
		
		if(!isConnected && flag){
			GameState.Instance.population -=populationSupport;
			flag = false;
		}
	}
}
