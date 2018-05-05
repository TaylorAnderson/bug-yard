using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public static UIManager instance;
	public GameObject cameraFrame;
	// Use this for initialization
	void Start () {
		UIManager.instance = this;
	}
	
	public void HideCameraOverlay() {
		cameraFrame.SetActive(false);
	}

	public void showCameraOverlay() {
		cameraFrame.SetActive(true);
	}
}
