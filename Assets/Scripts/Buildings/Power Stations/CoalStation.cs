using UnityEngine;
using System.Collections;

public class CoalStation : PowerStationStruct {

	// Use this for initialization
	void Awake () {
		cost = 20;
		pollutionIndex = 50;
		title = "Coal Station";
		houseSupport = 30;
	}
}
