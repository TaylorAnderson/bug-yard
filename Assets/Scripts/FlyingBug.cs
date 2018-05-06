using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBug : WanderingAIMovement {

	public float jumpStrength = 25f;
	public float ceilingHeight = 50f;
	public float lowerHeight = 20f;
	protected override Vector3 getDirection(Vector3 accel)
	{
		accel = base.getDirection(accel);

		int rng = Random.Range(0, 100);
		Vector3 currentPos = this.transform.position;
		if (currentPos.y < lowerHeight || (rng > 50 && currentPos.y < ceilingHeight)) {
			//always jump
			accel.y += jumpStrength;
		}
		
		return accel;

	}
}
