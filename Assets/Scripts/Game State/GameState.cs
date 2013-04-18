using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	
	public int cash;
	public int pollution;
	public int population;
	public GameObject[,] grid = new GameObject[100,100];
	public int tick;
	
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
		cash = 20;
		pollution = 0;
		population = 1;
		tick = 5;
		
		cashTick = true;
	}
	
	public bool PlaceBuilding(BuildingStruct x, Vector2 coord) {
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
	
	// Update is called once per frame
	void Update () {
		if(Time.time%tick < 0.1) { // condition for time interval
			if(cashTick){
				cash += cashFlow();
				cashTick = false;
			}
		} else{
			cashTick = true;
		}
	}
}
