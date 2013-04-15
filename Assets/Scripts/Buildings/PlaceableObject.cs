using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Possibly extend to consider different types
public class PlaceableObject : MonoBehaviour {
	
	public List<Collider> obj_colliders = new List<Collider>();
	private bool isSelected;
	
	//Building State Changing GUI
	void OnGui(){
		if(isSelected)
		{
			if(GUI.Button(new Rect(Screen.width/20, Screen.height/15 + Screen.height/12 * 3, 100, 30), "Test State Change" ))
			{
				//TODO
				Debug.Log ("Should show on clicked building...");
			}
		}
	}
	
	//Check Rigid Body Collision
	void OnTriggerEnter(Collider col){
		if(col.tag == "Building"){
			obj_colliders.Add(col);
			Debug.Log("Added");
		}
	}
	
	void OnTriggerExit(Collider col){
		if(col.tag == "Building"){
			obj_colliders.Remove(col);
			Debug.Log("Removed");
		}
	}
	
	public void setSelected(bool selected){
		isSelected = selected;
	}
}
