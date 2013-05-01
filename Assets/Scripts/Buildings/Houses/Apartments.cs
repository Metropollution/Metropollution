using UnityEngine;
using System.Collections;

public class Apartments : HouseStruct {
	// Use this for initialization
	void Awake () {
		cost = 30;
		populationSupport = 20;
		pollutionIndex = 30;
		title = "Apartments";
	}
}
