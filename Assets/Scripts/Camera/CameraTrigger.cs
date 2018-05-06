using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

	public List<BugType> bugsInView = new List<BugType>();
	public GameObject starParticles;
	public Dictionary<Bug, GameObject> particleSystems = new Dictionary<Bug, GameObject>();
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//print(bugsInView.Count);
	}

	public void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Bug")) {
			var bug = other.GetComponent<Bug>();
			bugsInView.Add(bug.bugType);
			
			if (!this.particleSystems.ContainsKey(bug)) {
				var particles = Instantiate(starParticles);
				particles.transform.position = bug.transform.position;
				particles.transform.parent = bug.transform;
				this.particleSystems.Add(bug, particles);
			}
		}
	}
	public void OnTriggerExit(Collider other) {
		if (other.CompareTag("Bug")) {
			var bug = other.GetComponent<Bug>();
			bugsInView.Remove(bug.bugType);
			GameObject particle = particleSystems[bug];
			particleSystems.Remove(bug);
			Destroy(particle);
		}
	}
	
}
