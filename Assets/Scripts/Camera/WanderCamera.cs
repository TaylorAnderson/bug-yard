using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderCamera : CameraState {

	// Use this for initialization
	void Start () {
		
	}
	
	override public void StateEnter(CameraManager manager)
    {

	}
	
	override public void StateUpdate(CameraManager manager)
    {
		manager.MouseCameraX();
		manager.ThirdPersonMouseCameraY();
	}

	override public void StateExit(CameraManager manager)
    {

	}

}
