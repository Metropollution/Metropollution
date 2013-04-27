using UnityEngine;
using System.Collections;

public class BuildingStruct : MonoBehaviour {
	// All buildings should inherit this class
	
	public int cost;
	public int populationSupport;
	public int pollutionIndex;
	public bool isConnected;
	public bool isBuilt = false;
	public bool isActivated = false;
	public Vector2 coordinates;
	protected GameObject powerSymbol;
	
	public virtual bool Build(Vector2 coord) {
		if(GameState.Instance.PlaceBuilding(this, coord)){
			BuildingStruct bs = GameState.Instance.grid[(int)coord.x,(int)coord.y].GetComponent<BuildingStruct>();
			bs.coordinates = coord;
			
			bs.isConnected = connections(coord);
			return true;
		} else{
			return false;	
		}
	}
	
	public virtual void Demolish(){
		
	}
	
	public bool connections (Vector2 coord){
		bool flag = false;
		
		GameObject neighbour;
		
		if(coord.x > 1){
			neighbour = GameState.Instance.grid[(int)coord.x-1,(int)coord.y];
			if(neighbour){
				flag = flag || connectionCheck(neighbour);
			}
		} 
		
		if(coord.x < 49){
			neighbour = GameState.Instance.grid[(int)coord.x+1,(int)coord.y];
			if(neighbour){
				flag = flag || connectionCheck(neighbour);
			}
		}
		
		if(coord.y > 1){
			neighbour = GameState.Instance.grid[(int)coord.x,(int)coord.y-1];
			if(neighbour){
				flag = flag || connectionCheck(neighbour);
			}	
		}
		
		if(coord.y < 49){
			neighbour = GameState.Instance.grid[(int)coord.x,(int)coord.y+1];
			if(neighbour){
				flag = flag || connectionCheck(neighbour);
			}	
		}
		return flag;
	}
	
	private bool connectionCheck (GameObject obj){
		if(obj.GetComponent<PowerStationStruct>()){
			return true;
		} else if(obj.GetComponent<RoadStruct>()){
			RoadStruct rs = obj.GetComponent<RoadStruct>();
			return rs.isConnected;
		}
			
		return false;	
	}
}
