using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	public Transform[] worldObjects;
	private ArrayList powerObjects = new ArrayList();
	private ArrayList roadObjects = new ArrayList();
	private ArrayList buildingObjects = new ArrayList();

	private SubMenu buildMenu;
	private bool options;
	
	void Start () {
		foreach(Transform i in worldObjects){
			if(i.GetComponent<PowerStationStruct>()){
				powerObjects.Add(i);
			}

			if(i.GetComponent<RoadStruct>()){
				roadObjects.Add(i);
			}

			if(i.GetComponent<HouseStruct>()){
				buildingObjects.Add(i);
			}

			if(i.GetComponent<Apartments>()){
				i.Rotate(new Vector3(450,0,0));
			}
		}

		buildMenu = GetComponent<SubMenu>();
	}

	public ArrayList getPowerObjects(){
		return powerObjects;
	}

	public ArrayList getRoadObjects(){
		return roadObjects;
	}

	public ArrayList getBuildingObjects(){
		return buildingObjects;
	}

	private void CollapseSubMenu(){
		buildMenu.topMenu = false;
		buildMenu.objects = new ArrayList();
		buildMenu.PurgeTemp();
	}

	void OnGUI(){
		if(!GameState.Instance.gameEnd){
			if(Building.isBuilding || Building.isDemolishing){
				if(GUI.Button(new Rect(25,25,100,30),"Cancel")){
					Building.deactivate();
				}
			} else{
				if(options){
					if(GUI.Button(new Rect(25,25,100,30),"Back to Game")){
						options = false;
					}

					if(GUI.Button(new Rect(25,65,100,30),"Main Menu")){
						Application.LoadLevel("StartUpScene");
					}
					if(GUI.Button (new Rect(25,105,100,30),"Quit Game")){
						Application.Quit();
					}
				} else{
					if(GUI.Button(new Rect(25,25,100,30),"Build")){
						buildMenu.topMenu = true;
					}

					if(GUI.Button(new Rect(25,65,100,30),"Demolish")){
						CollapseSubMenu();
						Building.deactivate();
						Building.isDemolishing = true;
					}
					if(GUI.Button (new Rect(25,105,100,30),"Options")){
						options = true;
					}
				}
			}
	
			if(Input.GetMouseButtonDown(1)){
				CollapseSubMenu();
				options = false;
			}
		}
	}

	void Update(){
		if(Input.GetKeyDown("escape")){
			Building.deactivate();
			options = !options;
		}
	}

	/*
	//For Buildings right now, could easily be changed to consider other types
	void OnGUI()
	{
		for(int i = 0; i < worldObjects.Length; i ++)
		{
			if(GUI.Button(new Rect(Screen.width/20, Screen.height/15 + Screen.height/12 * i, 100, 30), worldObjects[i].name ))	
			{
				placeBuilding.SetItem(worldObjects[i]);
			}
		}
	}
	*/
}