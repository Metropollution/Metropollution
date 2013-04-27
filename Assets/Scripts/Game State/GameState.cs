using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	
	public int cash;
	public int pollution;
	public int population;
	public int turnsPassed = -1;
	public GameObject[,] grid = new GameObject[50,50];
	public float tick;
	
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
		cash = 2000;
		pollution = 0;
		population = 1;
		tick = 5.0f;
		
		cashTick = true;
	}
	
	public bool PlaceBuilding(BuildingStruct x, Vector2 coord) {
		if(!(x is RoadStruct) && isWaterArray(coord)){
			print ("Cannot build on water");
			return false;
		}
		
		if(cash >= x.cost && grid[(int)coord.x,(int)coord.y] == null){
			cash -= x.cost;
			
			GameObject newObj = (GameObject)Instantiate(x.gameObject);
			newObj.AddComponent<DestroyBuilding>();
			
			BuildingStruct bs = newObj.GetComponent<BuildingStruct>();
			bs.isBuilt = true;
			
			grid[(int)coord.x,(int)coord.y] = newObj;
			
			print("Build successful");
			
			return true;
		} else{
			print("Unable to build");
			
			return false;
		}
	}
	
	//public void PlaceModel(Transform model){
	
	public void RemoveBuilding(Vector2 index){
		if(grid[(int)index.x,(int)index.y] != null){
			BuildingStruct bs = grid[(int)index.x,(int)index.y].GetComponent<BuildingStruct>();
			bs.Demolish();
			Object.Destroy(grid[(int)index.x,(int)index.y]);
		}
	}
	
	public int cashFlow () { //contains formula for how much money is generated
		return population*1;
	}
	
	public bool isWaterArray (Vector2 index){
		return isWater(new Vector3(index.x*40, 0, index.y*40));
	}
	
	public bool isWater (Vector3 coord){
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
		if(tick != 0 && Time.time%tick < 0.1) { // condition for time interval
			if(cashTick){
				cash += cashFlow();
				turnsPassed++;
				cashTick = false;
			}
		} else{
			cashTick = true;
		}
	}
}
