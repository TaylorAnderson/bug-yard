using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class UIManager : MonoBehaviour {

	public static UIManager instance;
	public GameObject notepad;
	public GameObject cameraFrame;
	public GameObject shutter;
	public GameObject cameraZoomIndicator;
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
			if (Input.GetMouseButtonDown(0)) {
				shutter.GetComponent<DoodleStudio95.DoodleAnimator>().GoToAndPause(-1);
				shutter.GetComponent<DoodleStudio95.DoodleAnimator>().Play();
				// shutter.GetComponent<DoodleStudio95.DoodleAnimator>().Pau();
				// shutter.GetComponent<DoodleAnimator>().Play();
			}
		}
	}

	// IEnumerator PlayShutterAnimation()
	// {
		// shutter.GetComponent<DoodleStudio95.DoodleAnimator>().speed = 0.02f;
		// shutter.GetComponent<DoodleStudio95.DoodleAnimator>().Play();
		// yield return shutter.GetComponent<DoodleStudio95.DoodleAnimator>().Playing;
		// shutter.GetComponent<DoodleStudio95.DoodleAnimator>().Stop();
	// }
}
