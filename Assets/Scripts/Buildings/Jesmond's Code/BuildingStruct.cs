using UnityEngine;
using System.Collections;

public class BuildingStruct : MonoBehaviour {
	// All buildings should inherit this class
	
	public int cost;
	public int populationSupport;
	public int pollutionIndex;
	public bool isConnected;
	public bool isBuilt;
	private bool flag;
	public Vector2 coordinates;
	
	public bool Build(Vector2 coord) {
		if(GameState.Instance.PlaceBuilding(this, coord)){
			coordinates = coord;
			return true;
		} else{
			return false;	
		}
	}
	
	public void Demolish() {
		if(isConnected && flag){
			GameState.Instance.population -= populationSupport;
			GameState.Instance.pollution -= pollutionIndex;
		}
	}
	// Update is called once per frame
	void Update() {
		if(isBuilt && isConnected && !flag){
			GameState.Instance.population += populationSupport;
			GameState.Instance.pollution += pollutionIndex;
			flag = true;
		}
		
		if(isBuilt && !isConnected && flag){
			GameState.Instance.population -= populationSupport;
			GameState.Instance.pollution -= pollutionIndex;
			flag = false;
		}
	}
}
