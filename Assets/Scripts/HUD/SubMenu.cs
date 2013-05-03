using UnityEngine;
using System.Collections;

public class SubMenu : MonoBehaviour {

	public ArrayList objects = new ArrayList();
	public bool topMenu;
	private ObjectManager om;
	private Building placeBuilding;
	private bool firstClick = false;
	private ArrayList temp = new ArrayList();
	public GUIStyle customStyle;

	void Start() {
		om = GetComponent<ObjectManager>();
		placeBuilding = GetComponent<Building>();

		customStyle.normal.textColor = Color.white;
		customStyle.fontSize = 16;
		customStyle.fontStyle = FontStyle.Bold;
	}

	public void PurgeTemp(){
		foreach(GameObject i in temp){
			Destroy(i);
		}
	}

	void OnGUI() {
		if(topMenu){
			GUI.Box(new Rect(130, 25, 110,145),"");

			if(GUI.Button(new Rect(135,30,100,30),"Buildings")){
				objects = new ArrayList(om.getBuildingObjects());
				topMenu = false;
				firstClick = true;
			}

			if(GUI.Button(new Rect(135,65,100,30),"Power Stations")){
				objects = new ArrayList(om.getPowerObjects());
				topMenu = false;
				firstClick = true;
			}

			if(GUI.Button(new Rect(135,100,100,30),"Roads")){
				objects = new ArrayList(om.getRoadObjects());
				topMenu = false;
				firstClick = true;
			}

			if(GUI.Button(new Rect(135,135,100,30),"Cancel")){
				topMenu = false;
				objects = new ArrayList();
			}
		} else if(objects.Count != 0){
			if(firstClick && !Input.GetMouseButtonDown(0)){
				firstClick = false;
			} else{
				GUI.Box(new Rect(130, 25,110,25+(objects.Count+1)*30),"");

				PurgeTemp();

				for(int i = 0; i<objects.Count; i++){
					Transform x = (Transform)objects[i];
					GameObject obj = (GameObject)Instantiate(x.gameObject,
						new Vector3(10000,10000,10000),
						Quaternion.identity);
					obj.transform.parent = transform;

					temp.Add(obj);

					BuildingStruct bs = obj.GetComponent<BuildingStruct>();

					Rect r = new Rect(135,30+i*35,100,30);

					if(GUI.Button(new Rect(135,30+i*35,100,30),bs.title)){
						placeBuilding.SetItem(obj.transform);
						objects = new ArrayList();
					}

					Vector3 mp = Input.mousePosition;

					if(r.Contains(new Vector3(mp.x,Screen.height-mp.y,mp.z))){
						GUI.Box(new Rect(245,25,110,90),"");
						GUI.Label(new Rect(250,30,100,20),bs.title,customStyle);
						GUI.Label(new Rect(250,50,100,20),"Cost: "+bs.cost);
						if(bs is PowerStationStruct){
							PowerStationStruct pss = (PowerStationStruct)bs;
							GUI.Label(new Rect(250,70,100,20),"Power Output: "+pss.houseSupport);
						}else{
							GUI.Label(new Rect(250,70,100,20),"Population: "+bs.populationSupport);
						}
						GUI.Label(new Rect(250,90,100,20),"Pollution: "+bs.pollutionIndex);

					}
				}
	
				if(GUI.Button(new Rect(135,30+objects.Count*35,100,30),"Back")){
					PurgeTemp();

					objects = new ArrayList();
					topMenu = true;
				}
			}
		}
	}
}
