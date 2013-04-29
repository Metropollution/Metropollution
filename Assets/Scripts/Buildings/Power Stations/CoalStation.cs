using UnityEngine;
using System.Collections;

public class CoalStation : PowerStationStruct {

	// Use this for initialization
	void Awake () {
		cost = 20;
		populationSupport = 0;
		pollutionIndex = 20;
		title = "Coal Station";
		//houseSupport = 30;
	}
}
