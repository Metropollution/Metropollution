using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	
	private BuildingStruct bs;
	
	public static Transform currentBuilding;
	public static Vector3 currentCoord;
	public static bool isBuilding;
	public static bool isDemolishing;

	private int cursorSizeX = 32;
	private int cursorSizeY = 32;

	public Texture2D bulldozer;

	void OnGUI() {
		if(isDemolishing){
			GUI.DrawTexture(new Rect(Input.mousePosition.x-cursorSizeX/2-13 , (Screen.height-Input.mousePosition.y)-cursorSizeY/2-9, cursorSizeX, cursorSizeY),bulldozer);
		}
	}

	void Update(){
		if(GameState.Instance.gameEnd){
			deactivate();
		}

		if(isDemolishing){
			HUD.hideCursor = HUD.hideCursor || true;
		} else{
			HUD.hideCursor = HUD.hideCursor || false;
		}
		//Show building while placing
		if(currentBuilding != null) {
			if(currentCoord != Vector3.zero){
				//Set Object's Position
				currentBuilding.position = currentCoord;
				
				if(Input.GetMouseButtonDown(0))
				{
					if(bs.Build(GridSelect.toArray(currentCoord))){
						//Destroy(currentBuilding.gameObject);
					}
				}
			} else if(currentCoord == Vector3.zero){
				currentBuilding.position = new Vector3(0,10000,0);
				
				if(Input.GetMouseButtonDown(0))
				{
					//Destroy(currentBuilding.gameObject);
				}
			}
		}

		if(Input.GetMouseButtonDown(1))
			{
				deactivate();
			}
	}

	public static void deactivate(){
		isBuilding = false;
		isDemolishing = false;

		if(currentBuilding){
			Destroy(currentBuilding.gameObject);
		}
	}

	public void SetItem(Transform worldObj){
		isBuilding = true;
		currentBuilding = ((Transform) Instantiate(worldObj));
		
		bs = currentBuilding.GetComponent<BuildingStruct>();
	}
}
