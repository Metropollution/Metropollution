using UnityEngine;
using System.Collections;

public class HouseStruct : BuildingStruct {

	protected override void SpecificDemolish() {
		if(powerSymbol)
			Destroy(powerSymbol);
	}
	
	void LateUpdate () {
		if(isBuilt && !isConnected && !powerSymbol){
			GameObject lightning = GameObject.FindGameObjectWithTag("Lightning");
			
			powerSymbol = (GameObject)Instantiate(lightning,
				new Vector3(transform.position.x, 20, transform.position.z),
				Quaternion.identity);
			
			powerSymbol.transform.Rotate(new Vector3(10,10,0));
			
			if(powerSymbol == null)
				print ("error, no lightning symbol");
		}
		
		if(isConnected && powerSymbol){
			Destroy(powerSymbol);
		}
		
		if(isBuilt && isConnected && !isActivated){
			GameState.Instance.population += populationSupport;
			GameState.Instance.pollution += pollutionIndex;
			isActivated = true;
		}
		
		if(isBuilt && !isConnected && isActivated){
			GameState.Instance.population -= populationSupport;
			GameState.Instance.pollution -= pollutionIndex;
			isActivated = false;
		}
	}
}
