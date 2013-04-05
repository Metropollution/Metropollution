
using UnityEngine;
using System.Collections;

public class NodeClick : MonoBehaviour {
	
	private Transform gridTileLocation;
	private bool occupied;
	
	void Start(){
		occupied = false;
		gridTileLocation = null;
	}
	
	public void toggleOccupied(){
		occupied = !occupied;	
	}
	
	public bool getBool(){
		return occupied;	
	}
	
	public Transform getTransform(){
		return gridTileLocation;
	}
	
	public void setTransform(Transform x){
		gridTileLocation = x;	
	}
	
}
