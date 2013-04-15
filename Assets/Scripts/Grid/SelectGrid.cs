using UnityEngine;
using System.Collections;

public class SelectGrid : MonoBehaviour {

public GameObject prefabBuilding;
	
	GameObject nodeSelected;

	// Use this for initialization
	void Start () {
		nodeSelected = new GameObject();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			nodeSelected = SelectGridTile();
			Debug.Log("Object:  " + nodeSelected);
		}
	}
	
	//Use a Ray to select the grid
	public GameObject SelectGridTile(){
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//LayerMask gridlayer = 1 << 8; **Need to add a laterMask, but wasn't working with -- so I'll come back to it
		if(Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			Debug.Log("Object:  " + hit.collider.gameObject);
			return hit.collider.gameObject;
		}
		return null;
	}
	
	//To play around with later to click for building placement
	void OnGUI () {
		if (GUI.Button (new Rect (10,10,150,100), "Build Building")) {
			if(nodeSelected!=null){
				GameObject building = (GameObject) Instantiate(prefabBuilding);
				Debug.Log ("You clicked the button!");
			}
		}
	}
}
