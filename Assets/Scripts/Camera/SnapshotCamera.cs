using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapshotCamera : CameraState {

	
	override public void StateEnter(CameraManager manager)
    {
		manager.yOffset = 1f;
		manager.distance =  0f;
	}

	
	
	override public void StateUpdate(CameraManager manager)
    {
		manager.ZoomScrollManager();
		manager.CheckForBugs();
	}

	override public void StateExit(CameraManager manager)
    {

	}
}
