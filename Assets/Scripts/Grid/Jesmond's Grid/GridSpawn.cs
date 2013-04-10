using UnityEngine;
using System.Collections;

public class GridSpawn : MonoBehaviour {
	
	public Transform grid;

	// Use this for initialization
	void Start () {
		for(int i = 0; i<50; i++){
			for(int j = 0; j<50; j++){
				Instantiate(grid,new Vector3(20+40f*i,0.01f,20+40f*j),Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
