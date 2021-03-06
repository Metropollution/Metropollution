//
//Filename: KeyboardCameraControl.cs
//
 
using UnityEngine;

public class KeyboardCameraControl : MonoBehaviour
{
	public float sensitivity;

    void LateUpdate()
    {
		sensitivity = (camera.orthographicSize/15);

        if(Input.GetKey("left")){
			transform.Translate(sensitivity, 0, -sensitivity,Space.World);
		}

		if(Input.GetKey("right")){
			transform.Translate(-sensitivity, 0, sensitivity,Space.World);
		}

		if(Input.GetKey("up")){
			transform.Translate(-sensitivity, 0, -sensitivity,Space.World);
		}

		if(Input.GetKey("down")){
			transform.Translate(sensitivity, 0, sensitivity,Space.World);
		}
	}
}