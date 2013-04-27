using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	
	private BuildingStruct bs;
	private bool placed;
	
	public static Transform currentBuilding;
	public static Vector3 currentCoord;
	
	void Start () {
	
	}
	
	void Update(){
	//Show building while placing
		if(currentBuilding != null) {
			if(currentCoord != Vector3.zero){
				//Set Object's Position
				currentBuilding.position = currentCoord;
				
				if(Input.GetMouseButtonDown(0))
				{
					if(bs.Build(GridSelect.toArray(currentCoord))){
						Object.Destroy(currentBuilding.gameObject);
					}
				}
				
				if(Input.GetMouseButtonDown(1))
				{
					Object.Destroy(currentBuilding.gameObject);
				}
				
			} else if(currentCoord == Vector3.zero){
				currentBuilding.position = new Vector3(0,10000,0);
				
				if(Input.GetMouseButtonDown(0))
				{
					Object.Destroy(currentBuilding.gameObject);
				}
			}
		}
	}
		
	public void SetItem(Transform worldObj){
		currentBuilding = ((Transform) Instantiate(worldObj));
		bs = currentBuilding.GetComponent<BuildingStruct>();
	}
}
