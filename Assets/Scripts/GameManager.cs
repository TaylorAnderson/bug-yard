using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewMode {

	WANDER,
	CAMERA

}

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject player;
	public ViewMode _viewMode = ViewMode.WANDER;
	public List<BugType> collectedBugs = new List<BugType>();

	// Use this for initialization
	void Start () {
		//do crimes here
		GameManager.instance = this;


	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.R)) {
			/* Go to camera mode */
			Player script = player.GetComponent<Player>();
			

			if (_viewMode == ViewMode.WANDER) {
				_viewMode = ViewMode.CAMERA;
				script.GoToCameraView();
				UIManager.instance.showCameraOverlay();
			}
			else if (_viewMode == ViewMode.CAMERA) {
				_viewMode = ViewMode.WANDER;
				script.GoToWanderingView();
				UIManager.instance.HideCameraOverlay();
			}
			
		}

		if (_viewMode == ViewMode.CAMERA && Input.GetMouseButton(0)) {
			CameraTrigger bugView = player.GetComponentInChildren<CameraTrigger>();
			foreach (BugType bug in bugView.bugsInView) {
				if (Bug.bugsCaught.IndexOf(bug) == -1) {
					print(bug.ToString() + " Caught!");
					Bug.bugsCaught.Add(bug);
				}
			}
			foreach (BugType bug in Bug.bugsCaught) {
				print(bug);
			}
			
		}

	}
}
