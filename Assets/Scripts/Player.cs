using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Camera _camera;
	private CameraManager m_camera_manager;
	private float _cameraLerpSpeed = 0.2f;
	public Vector3 positionWander;
	public Vector3 positionCamera;

	// Use this for initialization
	void Start () {
		_camera = GetComponentInChildren<Camera>();
		m_camera_manager = GetComponentInChildren<CameraManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToCameraView()
	{
		m_camera_manager.GoToSnapshotView();
		GetComponent<CharacterController>().enabled = false;
		GetComponentInChildren<SpriteRenderer>().enabled = false;
	}

	public void GoToWanderingView()
	{
		m_camera_manager.GoTo3rdPersonView();
		GetComponent<CharacterController>().enabled = true;
		GetComponentInChildren<SpriteRenderer>().enabled = true;
	}

}
