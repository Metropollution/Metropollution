using UnityEngine;
using System.Collections;

public class GridSelect : MonoBehaviour {
	
	public Material black;
	public Material white;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Use this to convert the tile coordinates into a array index between [1,99]
	Vector2 toArray (){
		return new Vector2(transform.position.x/20, transform.position.z/20);
	}
	
	void OnMouseDown() {
		if(renderer.material.ToString().Equals("GridMatBlack (Instance) (UnityEngine.Material)")){
			renderer.material = white;
			print (renderer.material.ToString());
		}else if(renderer.material.ToString().Equals("GridMatWhite (Instance) (UnityEngine.Material)")){
			renderer.material = black;
			print (renderer.material.ToString());
		}
		print (transform.position.x/20+", "+transform.position.z/20);
	}
}
