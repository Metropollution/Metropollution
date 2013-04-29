using UnityEngine;
using System.Collections;

public class TrunkRoad : RoadStruct {

	// Use this for initialization
	void Awake() {
		cost = 1;
		populationSupport = 0;
		pollutionIndex = 1;
		title = "Trunk Road";
	}
}
