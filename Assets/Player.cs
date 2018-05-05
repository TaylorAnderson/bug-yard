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
		StartCoroutine( LerpToPosition(.3f, positionCamera) );
	}

	public void GoToWanderingView()
	{
		StartCoroutine( LerpToPosition(.3f, positionWander) );
	}
	 IEnumerator LerpToPosition(float lerpSpeed, Vector3 newPosition, bool useRelativeSpeed = false)
     {    
        //  if (useRelativeSpeed)
        //  {
        //      float totalDistance = farRight.position.x - farLeft.position.x;
        //      float diff = transform.position.x - farLeft.position.x;
        //      float multiplier = diff / totalDistance;
        //      lerpSpeed *= multiplier;
        //  }
 
         float t = 0.0f;
         Vector3 startingPos = _camera.transform.localPosition;
         while (t < 1.0f)
         {
             t += Time.deltaTime * (Time.timeScale / lerpSpeed);
 
             _camera.transform.localPosition = Vector3.Lerp(startingPos, newPosition, t);
             yield return 0;
         }    
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
