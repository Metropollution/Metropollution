using UnityEngine;
using System.Collections;

public class HouseStruct : BuildingStruct {

	public bool isPowered;

	public override bool Build(Vector2 coord) {
		if(GameState.Instance.PlaceBuilding(this, coord)){
			BuildingStruct bs = GameState.Instance.grid[(int)coord.x,(int)coord.y].GetComponent<BuildingStruct>();
			bs.coordinates = coord;
			
			bs.isConnected = Connections(coord);

			return true;
		} else{
			return false;
		}
	}

	protected override void SpecificDemolish() {
		if(powerSymbol)
			Destroy(powerSymbol);
	}
	
	void Update () {
		if(isBuilt && !isPowered && !powerSymbol){
			GameObject lightning = GameObject.FindGameObjectWithTag("Lightning");
			
			powerSymbol = (GameObject)Instantiate(lightning,
				new Vector3(transform.position.x, 10000, transform.position.z),
				Quaternion.identity);
			
			powerSymbol.transform.Rotate(new Vector3(10,10,0));
			
			if(powerSymbol == null)
				print ("error, no lightning symbol");
		}
		
		if(isPowered && powerSymbol){
			Destroy(powerSymbol);
		}
		
		if(isBuilt && isConnected && !isActivated){
			GameState.Instance.powerUsage++;
			isActivated = true;
		}

		if(isBuilt && isActivated && !isPowered && GameState.Instance.powerOutput >= GameState.Instance.powerUsage){
			GameState.Instance.population += populationSupport;
			GameState.Instance.pollution += pollutionIndex;
			isPowered = true;
		}

		if(isBuilt && !isConnected && isActivated){
			if(isPowered){
				GameState.Instance.population -= populationSupport;
				GameState.Instance.pollution -= pollutionIndex;
				isPowered = false;
			}
			GameState.Instance.powerUsage--;
			isActivated = false;
		}
	}
}
