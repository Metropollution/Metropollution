using UnityEngine;
using System.Collections;

public class WaterTower : PowerStationStruct {

	// Use this for initialization
	void Awake () {
		cost = 15;
		pollutionIndex = 10;
		title = "Water Tower";
		houseSupport = 30;
	}
}
