using UnityEngine;
using System.Collections;

public class MouseEdgeCameraControl : MonoBehaviour {
	public int Boundary; // distance from edge scrolling starts
	public int speed;

	public Texture up;
	public Texture right;
	public Texture down;
	public Texture left;
	public Texture ur;
	public Texture dr;
	public Texture dl;
	public Texture ul;

	private int theScreenWidth;
	private int theScreenHeight;
	private int directionBitmask;

	private int cursorSizeX = 32;  // set to width of your cursor texture
	private int cursorSizeY = 32;  // set to height of your cursor texture
	 
	void Start() 
	{
	    theScreenWidth = Screen.width;
	    theScreenHeight = Screen.height;

		speed = theScreenHeight/3;

		Boundary = 20;
	}

	void OnGUI() {
		if(directionBitmask == 1){
			GUI.DrawTexture(new Rect(Input.mousePosition.x-cursorSizeX , (Screen.height-Input.mousePosition.y)-cursorSizeY/2, cursorSizeX, cursorSizeY),right);
		}

		if(directionBitmask == 2){
			GUI.DrawTexture(new Rect(Input.mousePosition.x , (Screen.height-Input.mousePosition.y)-cursorSizeY/2, cursorSizeX, cursorSizeY),left);
		}

		if(directionBitmask == 4){
			GUI.DrawTexture(new Rect(Input.mousePosition.x-cursorSizeX/2 , (Screen.height-Input.mousePosition.y), cursorSizeX, cursorSizeY),up);
		}

		if(directionBitmask == 8){
			GUI.DrawTexture(new Rect(Input.mousePosition.x-cursorSizeX/2 , (Screen.height-Input.mousePosition.y)-cursorSizeY, cursorSizeX, cursorSizeY),down);
		}

		if(directionBitmask == 5){
			GUI.DrawTexture(new Rect(Input.mousePosition.x-cursorSizeX , (Screen.height-Input.mousePosition.y), cursorSizeX, cursorSizeY),ur);
		}

		if(directionBitmask == 6){
			GUI.DrawTexture(new Rect(Input.mousePosition.x , (Screen.height-Input.mousePosition.y), cursorSizeX, cursorSizeY),ul);
		}

		if(directionBitmask == 9){
			GUI.DrawTexture(new Rect(Input.mousePosition.x-cursorSizeX , (Screen.height-Input.mousePosition.y)-cursorSizeY, cursorSizeX, cursorSizeY),dr);
		}

		if(directionBitmask == 10){
			GUI.DrawTexture(new Rect(Input.mousePosition.x , (Screen.height-Input.mousePosition.y)-cursorSizeY, cursorSizeX, cursorSizeY),dl);
		}
	}
	 
	void Update()
	{
		if(directionBitmask != 0){
			HUD.hideCursor = HUD.hideCursor || true;
		} else{
			HUD.hideCursor = HUD.hideCursor || false;
		}

		directionBitmask = 0;

	    if (Input.mousePosition.x > theScreenWidth - Boundary)
	    {
	    	transform.Translate(-(speed * Time.deltaTime), 0, (speed * Time.deltaTime),Space.World);
			directionBitmask += 1;
	    }
	 
	    if (Input.mousePosition.x < 0 + Boundary)
	    {
	    	transform.Translate((speed * Time.deltaTime), 0, -(speed * Time.deltaTime),Space.World);
			directionBitmask += 2;
	    }
	 
	    if (Input.mousePosition.y > theScreenHeight - Boundary)
	    {
	    	transform.Translate(-(speed * Time.deltaTime), 0, -(speed * Time.deltaTime),Space.World);
			directionBitmask += 4;
	    }
	 
	    if (Input.mousePosition.y < 0 + Boundary)
	    {
	    	transform.Translate((speed * Time.deltaTime), 0, (speed * Time.deltaTime),Space.World);
			directionBitmask += 8;
	    }
	 
	}
}