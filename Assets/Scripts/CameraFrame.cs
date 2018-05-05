using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DoodleStudio95;
public class CameraFrame : MonoBehaviour {

	[Range(0, 1)]
	public float zoom = 0;

	public DoodleAnimator zoomBarAnim;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		zoomBarAnim.GoToAndPause(Mathf.RoundToInt(map(this.zoom, 0, 1, 0, 7)));
		
	}
	float map(float x, float fromMin, float fromMax, float toMin, float toMax){
		return toMin + ((x - fromMin) / (fromMax - fromMin)) * (toMax - toMin);
	}
}
