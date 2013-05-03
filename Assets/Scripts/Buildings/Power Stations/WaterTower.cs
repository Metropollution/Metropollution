using UnityEngine;
using System.Collections;

public class WaterTower : PowerStationStruct {

	// Use this for initialization
	void Awake () {
		cost = 15;
		pollutionIndex = 5;
		title = "Hydro Plant";
		houseSupport = 10;
	}
}
