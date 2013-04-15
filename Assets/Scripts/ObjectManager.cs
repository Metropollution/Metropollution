using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	public GameObject[] worldObjects;
	private Building placedBuilding;
	
	
	void Start () {
		placedBuilding = GetComponent<Building>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//For Buildings right now, could easily be changed to consider other types
	void OnGUI()
	{
		for(int i = 0; i < worldObjects.Length; i ++)
		{
			if(GUI.Button(new Rect(Screen.width/20, Screen.height/15 + Screen.height/12 * i, 100, 30), worldObjects[i].name ))	
			{
				placedBuilding.SetItem(worldObjects[i]);
			}
		}
	}
}
