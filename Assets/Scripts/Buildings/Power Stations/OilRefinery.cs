using UnityEngine;
using System.Collections;

public class OilRefinery : PowerStationStruct {

	// Use this for initialization
	void Awake () {
		cost = 10;
		populationSupport = 0;
		pollutionIndex = 20;
		title = "Oil Refinery";
		//houseSupport = 30;
	}
}
