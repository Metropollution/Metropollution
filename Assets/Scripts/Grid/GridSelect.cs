using UnityEngine;
using System.Collections;

public class GridSelect : MonoBehaviour {
	
	public Material black;
	public Material white;
	private bool temp;
	private bool selected;
	public GUIStyle customStyle;
	
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
		} else{
			if(GridSpawn.selected != transform){
				if(GridSpawn.selected){
					GridSpawn.selected.GetComponent<GridSelect>().Deselect();
				}
				GridSpawn.selected = transform;
			}

			Vector2 index = toArray(transform.position);
			if(GameState.Instance.grid[(int)index.x,(int)index.y]){
				selected = true;
				renderer.material = white;
			} else{
				Deselect();
			}
		}
	}

	public void Deselect(){
		if(!temp && renderer.material.ToString().Equals("GridMatWhite (Instance) (UnityEngine.Material)")){
			renderer.material = black;
		}
		selected = false;
		GridSpawn.selected = null;
	}

	public void SetTemp(bool flag) {
		temp = flag;
	}

	public void SetToBlack() {
		temp = false;
		Deselect();
	}

	public void PalateSwap() {
		if(!temp){
			if(renderer.material.ToString().Equals("GridMatBlack (Instance) (UnityEngine.Material)")){
				renderer.material = white;
			}else if(renderer.material.ToString().Equals("GridMatWhite (Instance) (UnityEngine.Material)")){
				renderer.material = black;
			}
		}
	}

	void Update(){
		if(Input.GetMouseButtonDown(1)){
			Deselect();
		}
	}

	void OnGUI() {
		if(selected){
			Vector2 index = toArray(transform.position);

			BuildingStruct bs = GameState.Instance.grid[(int)index.x,(int)index.y].GetComponent<BuildingStruct>();
			customStyle.normal.textColor = Color.white;
			customStyle.fontSize = 16;
			customStyle.fontStyle = FontStyle.Bold;
			customStyle.alignment = TextAnchor.MiddleCenter;

			GUI.Box(new Rect(Screen.width/2-110/2,Screen.height-115,110,90),"");
			GUI.Label(new Rect(Screen.width/2-100/2,Screen.height-110,100,20),bs.title,customStyle);

			customStyle.fontStyle = FontStyle.Normal;
			customStyle.fontSize = 13;
			GUI.Label(new Rect(Screen.width/2-100/2,Screen.height-90,100,20),"Cost: "+bs.cost,customStyle);
			GUI.Label(new Rect(Screen.width/2-100/2,Screen.height-70,100,20),"Population: "+bs.populationSupport,customStyle);
			GUI.Label(new Rect(Screen.width/2-100/2,Screen.height-50,100,20),"Pollution: "+bs.pollutionIndex,customStyle);
		}
	}
}
