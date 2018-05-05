using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Camera _camera;
	private float _cameraLerpSpeed = 0.2f;
	public Vector3 positionWander;
	public Vector3 positionCamera;

	// Use this for initialization
	void Start () {
		_camera = GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToCameraView()
	{
		StartCoroutine( Transition(positionCamera) );
		// TweenCameraTo1stPerson();
	}

	public void GoToWanderingView()
	{
		print("jkdhskfj");
		StartCoroutine( Transition(positionWander) );
		// TweenCameraTo3rdPerson();
	}

	IEnumerator Transition(Vector3 target)
	{
		float t = 0.0f;
		print(t);
		Vector3 startingPos = _camera.transform.localPosition;
		while (t < 1.0f) {
			t += Time.deltaTime * (Time.timeScale/.003f);
		}
		_camera.transform.localPosition = Vector3.Lerp(startingPos, target, t);
		yield return 0;
	}

	IEnumerator TweenCameraTo3rdPerson() {
		_camera.transform.localPosition = Vector3.MoveTowards(_camera.transform.localPosition, positionWander, .2f * Time.deltaTime);
		//  _camera.transform.localPosition = Vector3.Slerp(
		// 	_camera.transform.localPosition,
		// 	positionWander,
		// 	_cameraLerpSpeed
		// );
        yield return new WaitForSeconds(3f);
    }

	IEnumerator TweenCameraTo1stPerson() {
		_camera.transform.localPosition = Vector3.MoveTowards(_camera.transform.localPosition, positionCamera, .2f * Time.deltaTime);
		//  _camera.transform.localPosition = Vector3.Slerp(
		// 	_camera.transform.localPosition,
		// 	positionCamera,
		// 	_cameraLerpSpeed
		// );
        yield return new WaitForSeconds(3f);
    }

}
