using UnityEngine;
using System.Collections;

public class MouseEdgeCameraControl : MonoBehaviour {
	public int Boundary; // distance from edge scrolling starts
	public int speed;
	 
	private int theScreenWidth;
	private int theScreenHeight;
	 
	void Start() 
	{
	    theScreenWidth = Screen.width;
	    theScreenHeight = Screen.height;

		speed = theScreenHeight/3;

		Boundary = 20;
	}
	 
	void Update() 
	{
	    if (Input.mousePosition.x > theScreenWidth - Boundary)
	    {
	    	transform.Translate(-(speed * Time.deltaTime), 0, (speed * Time.deltaTime),Space.World);
	    }
	 
	    if (Input.mousePosition.x < 0 + Boundary)
	    {
	    	transform.Translate((speed * Time.deltaTime), 0, -(speed * Time.deltaTime),Space.World);
	    }
	 
	    if (Input.mousePosition.y > theScreenHeight - Boundary)
	    {
	    	transform.Translate(-(speed * Time.deltaTime), 0, -(speed * Time.deltaTime),Space.World);
	    }
	 
	    if (Input.mousePosition.y < 0 + Boundary)
	    {
	    	transform.Translate((speed * Time.deltaTime), 0, (speed * Time.deltaTime),Space.World);
	    }
	 
	}
}