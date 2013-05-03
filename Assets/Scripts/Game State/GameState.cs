using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	
	public int cash;
	public int pollution;
	public int population;
	public int turnsPassed;
	public GameObject[,] grid = new GameObject[50,50];
	public float tick;

	public int goalCash;
	public int goalPop;
	public int goalPoll;
	public int goalTurns;

	public int powerUsage;
	public int powerOutput;

	public bool gameEnd = false;

	private ArrayList tempBuildStack = new ArrayList();
	private ArrayList powerStack = new ArrayList();
	private bool cashTick;
	
	public static GameState MyInstance;

	public static GameState Instance {
		get {
			if (MyInstance == null) {
				MyInstance = (GameState)FindObjectOfType(typeof(GameState));
			}
			return MyInstance;
		}
	}
	
	// Use this for initialization
	void Start () {
		MyInstance = this;
		cash = 100;
		pollution = 0;
		population = 1;
		tick = 0f;
		turnsPassed = 0;
		
		cashTick = true;

		goalTurns = PlayerPrefs.GetInt("turns");
		goalCash = PlayerPrefs.GetInt("cash");
		goalPop = PlayerPrefs.GetInt("population");
		goalPoll = PlayerPrefs.GetInt("pollution");
	}
	
	public bool PlaceBuilding(BuildingStruct x, Vector2 coord) {
		if(x is WaterTower && !IsWaterArray(coord)){
			print ("Must place on water");

			GameObject feedback = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("Feedback"),
				x.gameObject.transform.position,
				Quaternion.identity);

			feedback.GetComponent<BuildFeedback>().error = true;

			return false;
		}

		if(!(x is RoadStruct || x is WaterTower)&& IsWaterArray(coord)){
			print ("Cannot build on water");

			GameObject feedback = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("Feedback"),
				x.gameObject.transform.position,
				Quaternion.identity);

			feedback.GetComponent<BuildFeedback>().error = true;

			return false;
		}
		
		if(cash >= x.cost && grid[(int)coord.x,(int)coord.y] == null){
			cash -= x.cost;
			
			GameObject newObj = (GameObject)Instantiate(x.gameObject);
			
			BuildingStruct bs = newObj.GetComponent<BuildingStruct>();

			if(tick == 0){
				tempBuildStack.Add(newObj);

				Transform g = GridSpawn.GridAt(GridSelect.toArray(newObj.transform.position));
				g.gameObject.GetComponent<GridSelect>().PalateSwap();
				g.gameObject.GetComponent<GridSelect>().SetTemp(true);
			} else{
				bs.CompleteBuild();
			}

			if(bs is PowerStationStruct){
				powerStack.Add(newObj);
			}

			grid[(int)coord.x,(int)coord.y] = newObj;
			
			print("Build successful");

			return true;
		} else{
			print("Unable to build");

			GameObject feedback = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("Feedback"),
				x.gameObject.transform.position,
				Quaternion.identity);

			feedback.GetComponent<BuildFeedback>().error = true;

			return false;
		}
	}
	
	//public void PlaceModel(Transform model){
	
	public void RemoveBuilding(Vector2 index){
		if(grid[(int)index.x,(int)index.y] != null){
			BuildingStruct bs = grid[(int)index.x,(int)index.y].GetComponent<BuildingStruct>();

			if(bs.Demolish()){
				if(bs is PowerStationStruct){
					powerStack.Remove(grid[(int)index.x,(int)index.y]);
				}

				if(bs is HouseStruct){
					foreach(GameObject x in powerStack){
						PowerStationStruct pss = x.GetComponent<PowerStationStruct>();
						pss.setConnection(GridSelect.toArray(x.transform.position),false);
						pss.isConnected = false;
					}
				}

				GridSpawn.GridAt(index).GetComponent<GridSelect>().SetToBlack();
				tempBuildStack.Remove(grid[(int)index.x,(int)index.y]);
				Destroy(grid[(int)index.x,(int)index.y]);
			}
		}
	}
	
	public int CashFlow () { //contains formula for how much money is generated
		return population*1;
	}
	
	public bool IsWaterArray (Vector2 index){
		return IsWater(new Vector3(index.x*40, 0, index.y*40));
	}
	
	public bool IsWater (Vector3 coord){
		Vector3 TS = new Vector3(2000,600,2000); // terrain size
		Vector2 AS = new Vector2(30,30); // control texture size
		 
		TS = Terrain.activeTerrain.terrainData.size;
		AS.x = Terrain.activeTerrain.terrainData.alphamapWidth;
		AS.y = Terrain.activeTerrain.terrainData.alphamapHeight;
		 
		 
		// Lookup texture we are standing on:
		int AX = (int)((coord.x/TS.x)*AS.x+0.5f);
		int AY = (int)((coord.z/TS.z)*AS.y+0.5f);
		float[,,] TerrCntrl = Terrain.activeTerrain.terrainData.GetAlphamaps(AX, AY,1 ,1);

		float c1=TerrCntrl[0,0,1];
		if(c1>0.3f){
			return true;
		} else{
			return false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(turnsPassed >= goalTurns){
			tick = 0;
			gameEnd = true;
			GetComponent<SummaryScreen>().setBoolTrue();
		}

		if(tick != 0 && Time.time%tick < 0.1) { // condition for time interval
			if(cashTick){
				cash += CashFlow();
				turnsPassed++;
				cashTick = false;
			}
		} else{
			cashTick = true;
		}

		if(tempBuildStack.Count > 0 && tick != 0){
			foreach(GameObject i in tempBuildStack){
				i.GetComponent<BuildingStruct>().CompleteBuild();

				Transform grid = GridSpawn.GridAt(GridSelect.toArray(i.transform.position));
				grid.gameObject.GetComponent<GridSelect>().SetTemp(false);
				grid.gameObject.GetComponent<GridSelect>().PalateSwap();
			}
			tempBuildStack.Clear();
		}
	}
}
