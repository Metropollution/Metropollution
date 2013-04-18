using UnityEngine;
using System.Collections;

public class DestroyBuilding : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void onMouseOver (){
		if(Input.GetMouseButtonDown(1)){
			GameState.Instance.RemoveModel(GridSelect.toArray(transform.position));
		}
	}
}
