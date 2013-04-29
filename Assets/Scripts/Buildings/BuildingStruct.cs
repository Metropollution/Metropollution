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
	public string title;
	
	public virtual bool Build(Vector2 coord) {
		if(GameState.Instance.PlaceBuilding(this, coord)){
			BuildingStruct bs = GameState.Instance.grid[(int)coord.x,(int)coord.y].GetComponent<BuildingStruct>();
			bs.coordinates = coord;
			
			bs.isConnected = Connections(coord);
			return true;
		} else{
			return false;
		}
	}
	
	public bool Demolish(){
		if(isBuilt){
			if(GameState.Instance.cash >= cost/2){
				GameState.Instance.cash -= cost/2;

				GameObject feedback = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("Feedback"),
				transform.position,
				Quaternion.identity);

				feedback.GetComponent<BuildFeedback>().money = -cost/2;
				feedback.GetComponent<BuildFeedback>().moneyActivated = true;
			} else{
				GameObject feedback = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("Feedback"),
					transform.position,
					Quaternion.identity);

				feedback.GetComponent<BuildFeedback>().error = true;

				print ("Unable to demolish. Insufficient cash");

				return false;
			}
		} else{
			GameState.Instance.cash += cost;

			GameObject feedback = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("Feedback"),
				transform.position,
				Quaternion.identity);

			feedback.GetComponent<BuildFeedback>().money = cost;
			feedback.GetComponent<BuildFeedback>().moneyActivated = true;

			Transform grid = GridSpawn.GridAt(GridSelect.toArray(transform.position));
			grid.gameObject.GetComponent<GridSelect>().PalateSwap();
		}

		if(isConnected && isActivated){
			GameState.Instance.population -= populationSupport;
			GameState.Instance.pollution -= pollutionIndex;
		}

		SpecificDemolish();

		return true;
	}

	protected virtual void SpecificDemolish(){

	}

	public void CompleteBuild(){
		GameObject feedback = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("Feedback"),
				transform.position,
				Quaternion.identity);

		feedback.GetComponent<BuildFeedback>().money = -cost;
		feedback.GetComponent<BuildFeedback>().moneyActivated = true;
		isBuilt = true;
	}

	public bool Connections (Vector2 coord){
		bool flag = false;
		
		GameObject neighbour;
		
		if(coord.x > 1){
			neighbour = GameState.Instance.grid[(int)coord.x-1,(int)coord.y];
			if(neighbour){
				flag = flag || ConnectionCheck(neighbour);
			}
		} 
		
		if(coord.x < 49){
			neighbour = GameState.Instance.grid[(int)coord.x+1,(int)coord.y];
			if(neighbour){
				flag = flag || ConnectionCheck(neighbour);
			}
		}
		
		if(coord.y > 1){
			neighbour = GameState.Instance.grid[(int)coord.x,(int)coord.y-1];
			if(neighbour){
				flag = flag || ConnectionCheck(neighbour);
			}	
		}
		
		if(coord.y < 49){
			neighbour = GameState.Instance.grid[(int)coord.x,(int)coord.y+1];
			if(neighbour){
				flag = flag || ConnectionCheck(neighbour);
			}	
		}
		return flag;
	}
	
	private bool ConnectionCheck (GameObject obj){
		if(obj.GetComponent<PowerStationStruct>()){
			return true;
		} else if(obj.GetComponent<RoadStruct>()){
			RoadStruct rs = obj.GetComponent<RoadStruct>();
			return rs.isConnected;
		}
			
		return false;	
	}
}