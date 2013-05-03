using UnityEngine;
using System.Collections;

public class OilRefinery : PowerStationStruct {

	// Use this for initialization
	void Awake () {
		cost = 50;
		pollutionIndex = 50;
		title = "Oil Refinery";
		houseSupport = 50;
	}
}
