using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class Player : MonoBehaviour {

	public Camera _camera;
	private CameraManager m_camera_manager;
	private float _cameraLerpSpeed = 0.2f;
	public Vector3 positionWander;
	public Vector3 positionCamera;
	
	//Animation stuff
	private Vector3 lastPosition;
	public DoodleAnimationFile standAnim;
	public DoodleAnimationFile walkAnim;
	private DoodleAnimator doodleGirl;
	private DoodleAnimationFile currentAnim;

	// Use this for initialization
	void Start () {
		_camera = GetComponentInChildren<Camera>();
		m_camera_manager = GetComponentInChildren<CameraManager>();
		lastPosition = transform.position;
		doodleGirl = GetComponentInChildren<DoodleAnimator>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((lastPosition - transform.position).magnitude > 0.05) {
			if (currentAnim != walkAnim) {
				currentAnim = walkAnim;
				doodleGirl.ChangeAnimation(walkAnim);
			}
		}
		else {
			if (currentAnim != standAnim) {
				currentAnim = standAnim;
				doodleGirl.ChangeAnimation(standAnim);
			}
		}

		lastPosition = transform.position;
	}

	public void GoToCameraView()
	{
		m_camera_manager.GoToSnapshotView();
		// GetComponent<CharacterController>().enabled = false;
		GetComponentInChildren<SpriteRenderer>().enabled = false;
	}

	public void GoToWanderingView()
	{
		m_camera_manager.GoTo3rdPersonView();
		// GetComponent<CharacterController>().enabled = true;
		GetComponentInChildren<SpriteRenderer>().enabled = true;
	}

}
