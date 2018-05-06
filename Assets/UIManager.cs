using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public static UIManager instance;
	public GameObject notepad;
	public GameObject cameraFrame;
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
}
