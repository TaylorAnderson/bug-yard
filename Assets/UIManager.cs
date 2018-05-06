using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public static UIManager instance;
	public GameObject notepad;
	public GameObject cameraFrame;
	public GameObject shutter;
	// Use this for initialization
	void Start () {
		UIManager.instance = this;
		HideCameraOverlay();
	}
	
	public void HideCameraOverlay() {
		cameraFrame.SetActive(false);
		notepad.SetActive(true);
	}

	public void showCameraOverlay() {
		cameraFrame.SetActive(true);
		notepad.SetActive(false);
	}

	void Update () {
		if (GameManager.instance._viewMode == ViewMode.CAMERA) {
			if (Input.GetMouseButtonDown(1)) {
				shutter.GetComponent<DoodleStudio95.DoodleAnimator>().Play();
			}
		}
	}
}
