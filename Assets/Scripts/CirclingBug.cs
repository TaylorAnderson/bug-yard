using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingBug : Bug {

	// Use this for initialization

	public Vector2 initialTransform;
	private float currentAngle = 7;
	private int spinPointChangeInterval = 1;
	private float spinPointChangeTimer = 0;

	private Vector2 spinPoint;

	private Vector3 oldPos;

	void Start () {
		this.spinPoint = this.transform.position + Vector3.left*2;
		this.spinPointChangeTimer = this.spinPointChangeInterval;
	}
	
	// Update is called once per frame
	void Update () {
		var delta = this.transform.position - oldPos;
		this.oldPos = this.transform.position;
		this.spinPointChangeTimer+= Time.deltaTime;
		if (spinPointChangeTimer > spinPointChangeInterval) {
			this.spinPointChangeTimer -= this.spinPointChangeInterval;
			this.spinPoint = this.spinPoint + Random.insideUnitCircle;
			this.currentAngle = Mathf.Clamp(5 - Vector2.Distance(transform.position, spinPoint), 1, 5);
		}
		this.transform.RotateAround(this.spinPoint, Vector3.forward, currentAngle);
		
		//this.transform.eulerAngles = Vector3.forward * Vector3.Angle(spinPoint, transform.position);



	}
}
