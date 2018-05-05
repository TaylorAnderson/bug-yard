using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderCamera : CameraState {

	// Use this for initialization
	void Start () {
		
	}
	
	override public void StateEnter(CameraManager manager)
    {
		manager.yOffset = 3f;
	}
	
	override public void StateUpdate(CameraManager manager)
    {
		manager.MouseCameraX();
		manager.ThirdPersonMouseCameraY();
		manager.MouseScrollManager();
	}

	override public void StateExit(CameraManager manager)
    {

	}

}
