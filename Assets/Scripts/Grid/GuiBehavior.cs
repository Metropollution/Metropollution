using UnityEngine;
using System.Collections;

public class GuiBehavior : MonoBehaviour {
	
	public GameObject prefabBuilding;
	public bool placeBuilding;
	
	GameObject nodeSelected;
	GameObject defaultGround;

	// Use this for initialization
	void Start () {
		nodeSelected = new GameObject();
		prefabBuilding = GameObject.CreatePrimitive(PrimitiveType.Cube);
		placeBuilding = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(placeBuilding == true)
		{
			if(Input.GetMouseButtonDown(0)) 
			{
				nodeSelected = SelectGridTile();
				//prefabBuilding.transform.position = nodeSelected.transform.position;
				Instantiate(prefabBuilding, nodeSelected.transform.position,Quaternion.identity);
				Debug.Log("Object:  " + nodeSelected);
			}
		}
	}
	
	public GameObject SelectGridTile()
	{
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//LayerMask gridlayer = 1 << 8; Need to add a laterMask, but
		if(Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			Debug.Log("Object:  " + hit.collider.gameObject);
			return hit.collider.gameObject;
		}
		return null;
	}
	
	/*
		bool ClickLocation(out Vector3 point) {
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		
		RaycastHit hitInfo = new RaycastHit();
		if( Physics.Raycast( ray, out hitInfo, Mathf.Infinity ) ) {
			if( hitInfo.collider == collider ) {
				point = hitInfo.point;
				return true;
			}
		}
		point = Vector3.zero;
		return false;
	}
	
	public void SetNodeStart(GameObject n) {
		Debug.Log ("NodeStart: " + n.transform.position);
		nodeStart = n;
	}
	*/
	void OnGUI () 
	{
		if (GUI.Button (new Rect (10,10,150,100), "Build Building")) 
		{
			placeBuilding = true;
		}
		
		if (GUI.Button (new Rect (10,125,150,100), "Stop Building")) 
		{
			placeBuilding = false;
		}
	}
}
