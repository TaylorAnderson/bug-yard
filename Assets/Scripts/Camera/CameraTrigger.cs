using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

	public List<BugType> bugsInView = new List<BugType>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		print(bugsInView.Count);
	}
	public void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Bug")) {
			var bug = other.GetComponent<Bug>();
			bugsInView.Add(bug.bugType);
		}
	}
	public void OnTriggerExit(Collider other) {
		if (other.CompareTag("Bug")) {
			var bug = other.GetComponent<Bug>();
			bugsInView.Remove(bug.bugType);
		}
	}
}
