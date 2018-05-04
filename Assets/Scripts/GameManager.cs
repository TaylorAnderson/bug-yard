using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ViewModes {

	WANDER,
	ZOOM

}

public class GameManager : MonoBehaviour {



	// Use this for initialization
	void Start () {
		//do crimes here
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown("space"))
            print("space key was pressed");

	}
}
