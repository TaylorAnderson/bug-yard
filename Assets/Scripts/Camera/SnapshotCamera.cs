using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapshotCamera : CameraState {

	// Use this for initialization
	void Start () {
		
	}

	override public void StateEnter(CameraManager manager)
    {

	}
	
	override public void StateUpdate(CameraManager manager)
    {
		manager.MouseCameraX();
		manager.FirstPersonMouseCameraY();
	}

	override public void StateExit(CameraManager manager)
    {

	}
}
