using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBug : WanderingAIMovement {

	public float jumpStrength = 100f;
	public float ceilingHeight = 20f;
	public float lowerHeight = 5f;
	public int rngJump = 20;
	protected override Vector3 getDirection(Vector3 accel)
	{
		accel = base.getDirection(accel);

		int rng = Random.Range(0, 100);
		Vector3 currentPos = this.transform.position;
		if (currentPos.y < lowerHeight || (rng < rngJump && currentPos.y < ceilingHeight)) {
			//always jump
			accel.y += jumpStrength;
		}
		
		return accel;

	}
}
