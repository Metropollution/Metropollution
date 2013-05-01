using UnityEngine;
using System.Collections;

public class WaterTower : PowerStationStruct {

	// Use this for initialization
	void Awake () {
		cost = 15;
		populationSupport = 0;
		pollutionIndex = 10;
		title = "Solar Plant";
		//houseSupport = 30;
	}
}
