using UnityEngine;
using System.Collections;

public class GridSelect : MonoBehaviour {
	
	public Material black;
	public Material white;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Use this to convert the tile coordinates into a array index between [1,99]
	public static Vector2 toArray (Vector3 coord){
		return new Vector2(coord.x/20, coord.z/20);
	}
	
	void OnMouseOver() {
		Building.currentCoord = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		
		if(Input.GetMouseButtonDown(1)){
			GameState.Instance.RemoveModel(GridSelect.toArray(transform.position));
		}
	}
	
	void OnMouseExit() {
		Building.currentCoord = Vector3.zero;
	}

	void OnMouseDown() {		
		/*
		if(renderer.material.ToString().Equals("GridMatBlack (Instance) (UnityEngine.Material)")){
			renderer.material = white;
			print (renderer.material.ToString());
		}else if(renderer.material.ToString().Equals("GridMatWhite (Instance) (UnityEngine.Material)")){
			renderer.material = black;
			print (renderer.material.ToString());
		}
		*/
	}
}
