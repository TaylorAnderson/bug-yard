using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewMode {

	WANDER,
	CAMERA

}

public class GameManager : MonoBehaviour {

	public static GameManager gameManager;

	public GameObject player;
	private ViewMode _viewMode = ViewMode.WANDER;

	// Use this for initialization
	void Start () {
		//do crimes here
		GameManager.gameManager = this;
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.R)) {
			/* Go to camera mode */
			Player script = player.GetComponent<Player>();

			if (_viewMode == ViewMode.WANDER) {
				_viewMode = ViewMode.CAMERA;
				script.GoToWanderingView();
			}
			else if (_viewMode == ViewMode.CAMERA) {
				_viewMode = ViewMode.WANDER;
				script.GoToCameraView();
			}

			
		}

	}
}
