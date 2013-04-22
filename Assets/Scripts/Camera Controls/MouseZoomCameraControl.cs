using UnityEngine;
using System.Collections;

public class MouseZoomCameraControl : MonoBehaviour {
	public int sensitivity = 10;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			camera.orthographicSize=camera.orthographicSize-sensitivity;
			
			if(camera.transform.position.y>100){
				//camera.transform.Translate(0,-sensitivity,0,Space.World);	
			}
		}
		
		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
        	camera.orthographicSize=camera.orthographicSize+sensitivity;
			
			if(camera.transform.position.y<280){
				//camera.transform.Translate(0,sensitivity,0,Space.World);	
			}
		}
		
		camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, 100, 280 );
	}
}
