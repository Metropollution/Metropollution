using UnityEngine;
using System.Collections;

public class GridSpawn : MonoBehaviour {
	
	public Transform grid;
	private static Transform[,] gridArray = new Transform[50,50];
	public static Transform selected;

	// Use this for initialization
	void Start () {
		for(int i = 0; i<50; i++){
			for(int j = 0; j<50; j++){
				Transform x = (Transform)Instantiate(grid,new Vector3(20+40f*i,0.01f,20+40f*j),Quaternion.identity);
				x.parent = transform;

				Vector2 index = GridSelect.toArray(x.transform.position);
				gridArray[(int)index.x,(int)index.y] = x;
			}
		}
	}

	public static Transform GridAt(Vector2 index){
		if(gridArray[(int)index.x,(int)index.y]){
			return gridArray[(int)index.x,(int)index.y];
		} else{
			return null;
		}
	}
}
