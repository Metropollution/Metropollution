using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	
	public int cash;
	public int pollution;
	public int population;
	public GameObject[,] grid = new GameObject[100,100];
	public Transform[,] models = new Transform[100,100];
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
			
			GameObject newObj = new GameObject();
			newObj.AddComponent(x.GetType());
			grid[(int)coord.x,(int)coord.y] = newObj;
			
			print("Build successful");
			
			return true;
		} else{
			print("Unable to build");
			
			return false;
		}
	}
	
	public void PlaceModel(Transform model){
		Transform newModel = (Transform)Instantiate(model);
		
		newModel.gameObject.AddComponent<DestroyBuilding>();
		Vector2 index = GridSelect.toArray(model.transform.position);
		models[(int)index.x,(int)index.y] = newModel;
	}
	
	public void RemoveModel(Vector2 index){
		print (models[(int)index.x,(int)index.y]);
		if(models[(int)index.x,(int)index.y] != null){
			Object.Destroy(models[(int)index.x,(int)index.y].gameObject);
			
			BuildingStruct bs = grid[(int)index.x,(int)index.y].GetComponent<BuildingStruct>();
			bs.Demolish();
			grid[(int)index.x,(int)index.y] = null;
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
