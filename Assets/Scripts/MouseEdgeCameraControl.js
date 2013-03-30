#pragma strict
 
public var Boundary : int = 50; // distance from edge scrolling starts
public var speed : int = 5;
 
private var theScreenWidth : int;
private var theScreenHeight : int;
 
function Start() 
{
    theScreenWidth = Screen.width;
    theScreenHeight = Screen.height;
}
 
function Update() 
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
    	transform.Translate(-(speed * Time.deltaTime), 0, (speed * Time.deltaTime),Space.World);
    }
 
    if (Input.mousePosition.y < 0 + Boundary)
    {
    	transform.Translate((speed * Time.deltaTime), 0, (speed * Time.deltaTime),Space.World);
    }
 
}