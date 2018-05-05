using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook3rdPerson : MonoBehaviour {

	public float turnSpeed = 4.0f;
	public Transform player;

	private Vector3 offset;

	void Start () {
		offset = new Vector3(player.position.x, player.position.y + 8.0f, player.position.z + 7.0f);
	}

	void LateUpdate()
	{
		// offset = Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * turnSpeed, Vector3.left) * offset;
		// transform.localPosition = player.position + offset; 
		// transform.RotateAround(player.position, Vector3.up, Input.GetAxis("Mouse Y") * .2f);
	}
}
