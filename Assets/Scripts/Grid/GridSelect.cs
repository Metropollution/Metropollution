using UnityEngine;
using System.Collections;

public class GridSelect : MonoBehaviour {
	
	public Material black;
	public Material white;
	private bool isSelected;
	
	// Use this to convert the tile coordinates into a array index between [1,99]
	public static Vector2 toArray (Vector3 coord){
		return new Vector2(coord.x/40-0.5f, coord.z/40-0.5f);
	}
	
	void OnMouseOver() {
		Building.currentCoord = new Vector3(transform.position.x,transform.position.y,transform.position.z);
	}
	
	void OnMouseExit() {
		Building.currentCoord = Vector3.zero;
	}

	void OnMouseDown() {
		if(Building.isDemolishing){
			GameState.Instance.RemoveBuilding(GridSelect.toArray(transform.position));
		}
	}

	public void PalateSwap() {
		if(renderer.material.ToString().Equals("GridMatBlack (Instance) (UnityEngine.Material)")){
			renderer.material = white;
		}else if(renderer.material.ToString().Equals("GridMatWhite (Instance) (UnityEngine.Material)")){
			renderer.material = black;
		}
	}
}
