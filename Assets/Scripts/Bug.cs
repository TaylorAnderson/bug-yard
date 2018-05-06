using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BugType {
	ANT,
	LADYBUG,
	HORN_BEETLE,
	BUTTERFLY,
	GRASSHOPPER,
	GROUND_BEETLE,
	CENTIPEDE,
	BEE
}
public class Bug : MonoBehaviour {

	public static List<BugType> bugsCaught = new List<BugType>();
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
