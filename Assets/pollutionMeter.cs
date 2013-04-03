using UnityEngine;
using System.Collections;
 
public class pollutionMeter : MonoBehaviour {
    public float barDisplay;
    public Vector2 pos = new Vector2(20,40);
    public Vector2 size = new Vector2(60,20);
    public Texture2D empty;
    public Texture2D full;
 
    void OnGUI() {
       //draw background:
       GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
       GUI.Box(new Rect(0,0, size.x, size.y), empty);
 
       //draw fill:
       GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
       GUI.Box(new Rect(0,0, size.x, size.y), full);
       GUI.EndGroup();
       GUI.EndGroup();
    }
 
    void Update() {
       barDisplay = Time.time*0.05f;
    }
}