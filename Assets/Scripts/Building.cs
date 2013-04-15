using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	
	private PlaceableObject placeableBuilding;
	private Transform currentBuilding;
	private bool placed;
	
	public LayerMask buildingLayer;
	
	private PlaceableObject lastSelection;
	
	void Start () {
	
	}
	
	void Update(){
		
	//Get current mouse position
	Vector3 mouse_position = Input.mousePosition;
	mouse_position = new Vector3(mouse_position.x,mouse_position.y,transform.position.y);
			
	//Adjust with respect to world coordinates
	Vector3 world = camera.ScreenToWorldPoint(mouse_position);
		
	//Show building while placing
		if(currentBuilding != null && !placed)
		{
			//Set Object's Position
			currentBuilding.position = new Vector3(world.x,0,world.z);
			
			if(Input.GetMouseButtonDown(0))
			{
				if(checkPlacement())
				{
					placed = true;
				}
			}
		}
		else
		{
			//For State Change GUI Pop up...not working atm
			if(Input.GetMouseButtonDown(0))
			{
				RaycastHit myHit = new RaycastHit();
				Ray myRay = new Ray(new Vector3(mouse_position.x,8,mouse_position.z),Vector3.down);
				//TODO Add building layermask to script in editor
				if(Physics.Raycast(myRay, out myHit, Mathf.Infinity,buildingLayer))
				{
					if(lastSelection != null){
					lastSelection.setSelected(false);
					}
						myHit.collider.gameObject.GetComponent<PlaceableObject>().setSelected(true);
						lastSelection = myHit.collider.gameObject.GetComponent<PlaceableObject>();
				}
				else
				{
					if(lastSelection != null){
					lastSelection.setSelected(false);
					}
				}
			}
		}
	}
	
	//Check if object is already placed at that position
	bool checkPlacement(){
		//If colliding with something, don't place
		if(placeableBuilding.obj_colliders.Count > 0){
			return false;
		}
		return true;
	}
	
	
	public void SetItem(GameObject worldObj){
		placed = false;
		currentBuilding = ((GameObject) Instantiate (worldObj)).transform;
		placeableBuilding = currentBuilding.GetComponent<PlaceableObject>();
	}
}
