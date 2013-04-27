using UnityEngine;
using System.Collections;

public class HouseStruct : BuildingStruct {

	// Use this for initialization
	void Start () {
		
	}
	
	public override void Demolish() {
		if(isConnected && isActivated){
			GameState.Instance.population -= populationSupport;
			GameState.Instance.pollution -= pollutionIndex;
		}
		
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
				print ("error, no lightning");
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
