using UnityEngine;
using System.Collections;

public class Apartments : HouseStruct {
	// Use this for initialization
	void Awake () {
		cost = 100;
		populationSupport = 20;
		pollutionIndex = 50;
		title = "Apartments";
	}
}
