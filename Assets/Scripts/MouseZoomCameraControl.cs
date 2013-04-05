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
		}
		
		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
        	camera.orthographicSize=camera.orthographicSize+sensitivity;
		}
		
		camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, 100, 300 );
	}
}
