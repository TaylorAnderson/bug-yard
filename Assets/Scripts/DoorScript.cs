using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
Door requires a trigger collider in front and it sticks out a bit so that the player can walk into it
 */
public class DoorScript : MonoBehaviour {

	static List<BugType> totalBugList;

	// Use this for initialization
	void Start () {
		totalBugList = new List<BugType>();
		totalBugList.Add(BugType.ANT);
		totalBugList.Add(BugType.BEE);
		totalBugList.Add(BugType.BUTTERFLY);
		totalBugList.Add(BugType.CENTIPEDE);
		totalBugList.Add(BugType.GRASSHOPPER);
		totalBugList.Add(BugType.GROUND_BEETLE);
		totalBugList.Add(BugType.HORN_BEETLE);
		totalBugList.Add(BugType.LADYBUG);
	}

	void OnTriggerEnter(Collider other) {
        string otherTag = other.transform.tag.ToLower();
		if (otherTag == "player") {
			if (checkIfAllBugsCaught()) 
			{
				SceneManager.LoadSceneAsync("EndScene");
			}
		}
	}

	static bool checkIfAllBugsCaught() {
		foreach (BugType bugtype in totalBugList) {
			if (Bug.bugsCaught.IndexOf(bugtype) == -1) {
				Debug.Log("Not every bug is found");
				return false;
			}
		}
		return true;
	}
}
