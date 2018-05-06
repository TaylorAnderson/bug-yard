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
			DoodleStudio95.DoodleAnimator shutterAnim = shutter.GetComponent<DoodleStudio95.DoodleAnimator>();
			if (Input.GetMouseButtonDown(0)) {
				//shutterAnim.GoToAndPlay(0);
				// shutter.GetComponent<DoodleStudio95.DoodleAnimator>().Pau();
				// shutter.GetComponent<DoodleAnimator>().Play();
				StartCoroutine(showShutter(shutterAnim));
			}
			/**if (shutterAnim.CurrentFrame == 3) {
				shutterAnim.GoToAndPause(0);
			}*/
		}
	}

	IEnumerator showShutter(DoodleAnimator shutterAnim)
	{
		shutterAnim.GoToAndPause(3);
		yield return 1000;
		shutterAnim.GoToAndPause(0);
	}

	// IEnumerator PlayShutterAnimation()
	// {
		// shutter.GetComponent<DoodleStudio95.DoodleAnimator>().speed = 0.02f;
		// shutter.GetComponent<DoodleStudio95.DoodleAnimator>().Play();
		// yield return shutter.GetComponent<DoodleStudio95.DoodleAnimator>().Playing;
		// shutter.GetComponent<DoodleStudio95.DoodleAnimator>().Stop();
	// }
}
