using UnityEngine;
using System.Collections;

public class BasicHouse : HouseStruct {
	// Use this for initialization
	void Awake () {
		cost = 5;
		populationSupport = 1;
		pollutionIndex = 10;
		title = "Small House";
	}
}
