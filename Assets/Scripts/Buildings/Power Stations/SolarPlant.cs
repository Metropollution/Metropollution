using UnityEngine;
using System.Collections;

public class SolarPlant : PowerStationStruct {

	// Use this for initialization
	void Awake () {
		cost = 20;
		populationSupport = 0;
		pollutionIndex = 1;
		title = "Solar Plant";
		//houseSupport = 30;
	}
}
