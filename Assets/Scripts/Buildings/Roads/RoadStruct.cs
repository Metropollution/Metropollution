using UnityEngine;
using System.Collections;

public class RoadStruct : BuildingStruct {
	public override bool Build(Vector2 coord) {
		if(GameState.Instance.PlaceBuilding(this, coord)){
			BuildingStruct bs = GameState.Instance.grid[(int)coord.x,(int)coord.y].GetComponent<BuildingStruct>();
			bs.coordinates = coord;
			
			bs.isConnected = connections(coord);
			setConnection(coord, bs.isConnected);
			
			return true;
		} else{
			return false;	
		}
	}
	
	public override void Demolish() {
		if(isConnected && isActivated){
			GameState.Instance.population -= populationSupport;
			GameState.Instance.pollution -= pollutionIndex;
		}
		
		setConnection(GridSelect.toArray(transform.position), false);
	}
	
	public void setConnection(Vector2 coord, bool conn){
		GameObject neighbour;
		
		if(coord.x > 1){
			neighbour = GameState.Instance.grid[(int)coord.x-1,(int)coord.y];
			if(neighbour){
				neighbour.GetComponent<BuildingStruct>().isConnected = conn;
			}
		}
		
		if(coord.x < 49){
			neighbour = GameState.Instance.grid[(int)coord.x+1,(int)coord.y];
			if(neighbour){
				neighbour.GetComponent<BuildingStruct>().isConnected = conn;
			}
		}
		
		if(coord.y > 1){
			neighbour = GameState.Instance.grid[(int)coord.x,(int)coord.y-1];
			if(neighbour){
				neighbour.GetComponent<BuildingStruct>().isConnected = conn;
			}
		}
		
		if(coord.y < 49){
			neighbour = GameState.Instance.grid[(int)coord.x,(int)coord.y+1];
			if(neighbour){
				neighbour.GetComponent<BuildingStruct>().isConnected = conn;
			}
		}
	}
	
	void Update() {
		if(isBuilt && isConnected && !isActivated){
			GameState.Instance.population += populationSupport;
			GameState.Instance.pollution += pollutionIndex;
			
			setConnection(GridSelect.toArray(transform.position),true);
			
			isActivated = true;
		}
		
		if(isBuilt && !isConnected && isActivated){
			GameState.Instance.population -= populationSupport;
			GameState.Instance.pollution -= pollutionIndex;
			
			setConnection(GridSelect.toArray(transform.position),false);
			
			isActivated = false;
		}
	}
}
