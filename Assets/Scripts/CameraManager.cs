using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	/* State */
	Dictionary<ViewMode, ICameraState> m_states = new Dictionary<ViewMode, ICameraState>();
	ICameraState m_current_state;

	/* Camera Movement */

	Camera cam;
	public bool isControlable;
    private Vector3 screenPoint;
    private Vector3 offset;
    public Transform target;
    public float lastDistance = 5.0f;
    public float distance = 5.0f;
    public float yOffset = 3.0f;
    public float xSpeed = 50.0f;
    public float ySpeed = 50.0f;

    public float yMinLimit = -80f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    public float zoomMin = 0f;
    public float zoomMax = 3f;

    public float smoothTime = 5f;
    public float smoothTimeDistance = 100f;

    public float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;

    float velocityX = 0.0f;
    float velocityY = 0.0f;
    float moveDirection = -1;
	
	void Start ()
	{			
		cam = GetComponent<Camera>();

		Vector3 angles = transform.eulerAngles;
        rotationYAxis = (rotationYAxis == 0) ? angles.y : rotationYAxis;
        rotationXAxis = angles.x;

        Rigidbody rigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rigidbody)
        {
            rigidbody.freezeRotation = true;
        }

		m_states[ViewMode.WANDER] = new WanderCamera();
		m_states[ViewMode.CAMERA] = new SnapshotCamera();

		SetState(ViewMode.WANDER);
	}

	void Update()
	{

		if (m_current_state != null)
			m_current_state.StateUpdate(this);

	}

	void LateUpdate()
    {
        
        if (target)
        {
            // if (Input.GetMouseButton(1) && isControlable)
            // {
                velocityX += xSpeed * Input.GetAxis("Mouse X") * 0.02f;
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
            // }
            if (Input.GetMouseButton(2) && isControlable)
            {
                Vector3 curScreenPoint = new Vector3(moveDirection*Input.mousePosition.x, moveDirection*Input.mousePosition.y, screenPoint.z);

                Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;
                target.transform.position = curPosition;
            }

            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;

            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);

            Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            Quaternion rotation = toRotation;

            float dist = Mathf.Lerp(lastDistance, distance, Time.deltaTime * smoothTimeDistance);
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -dist);
            if (GameManager.instance._viewMode == ViewMode.CAMERA) {
                negDistance *= -1;
            }
            Vector3 yOffsetV = new Vector3(0.0f, yOffset, 0);
            Vector3 position = rotation * negDistance + yOffsetV + target.position;
            lastDistance = dist;

            transform.rotation = rotation;
			// target.rotation = Quaternion.AngleAxis(transform.rotation.y, Vector3.up);
			target.rotation = Quaternion.Euler(target.rotation.eulerAngles.z, rotation.eulerAngles.y, target.rotation.eulerAngles.z);
            transform.position = position;

            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);

            screenPoint = cam.WorldToScreenPoint(target.transform.position);
            offset = target.transform.position - cam.ScreenToWorldPoint(new Vector3(moveDirection*Input.mousePosition.x, moveDirection*Input.mousePosition.y, screenPoint.z));
        }

    }

    public void MouseScrollManager()
    {
        distance -= Input.GetAxis("Mouse ScrollWheel");

        if (distance > distanceMax)
        {
            distance = distanceMax;
        }
        else if (distance < distanceMin)
        {
            distance = distanceMin;
        }
    }

    public void ZoomScrollManager()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            distance += 1f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            distance -= 1f;
        }
        if (distance > zoomMax)
        {
            distance = zoomMax;
        }
        else if (distance < zoomMin)
        {
            distance = zoomMin;
        }
    }

    public void CheckForBugs() {
        
    }

    public void GoToSnapshotView() {
        distance = 0f;
        SetState(ViewMode.CAMERA);
    }

    public void GoTo3rdPersonView() {
        distance = 5f;
        SetState(ViewMode.WANDER);
    }

    IEnumerator GoToSnapView(float startDist, float endDist = 0) {
		
		yield return new WaitForSeconds(2f);
	}

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

	public void SetState(ViewMode new_state)
    {
        if (m_states[new_state] == m_current_state) return;
		if(m_current_state != null)
        	m_current_state.StateExit(this);
		
        m_current_state = m_states[new_state];
        m_current_state.StateEnter(this);

    }

	public void MouseCameraX() {

		// rotAverageX = 0f;
 
		// rotationX += Input.GetAxis("Mouse X") * sensitivityX * Time.timeScale;

		// rotArrayX.Add(rotationX);

		// if (rotArrayX.Count >= framesOfSmoothing)
		// {
		// 	rotArrayX.RemoveAt(0);
		// }
		// for(int i = 0; i < rotArrayX.Count; i++)
		// {
		// 	rotAverageX += rotArrayX[i];
		// }
		// rotAverageX /= rotArrayX.Count;
		// rotAverageX = ClampAngle(rotAverageX, minimumX, maximumX);

		// Quaternion xQuaternion = Quaternion.AngleAxis (rotAverageX, Vector3.up);
		// target.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 18f * Time.timeScale);		

	}

	public void FirstPersonMouseCameraY() {

		// rotAverageY = 0f;
 
		// float invertFlag = 1f;
		// if( invertY )
		// {
		// 	invertFlag = -1f;
		// }
		// rotationY += Input.GetAxis("Mouse Y") * sensitivityY * invertFlag * Time.timeScale;
		
		// rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

		// rotArrayY.Add(rotationY);

		// if (rotArrayY.Count >= framesOfSmoothing)
		// {
		// 	rotArrayY.RemoveAt(0);
		// }
		// for(int j = 0; j < rotArrayY.Count; j++)
		// {
		// 	rotAverageY += rotArrayY[j];
		// }
		// rotAverageY /= rotArrayY.Count;

		// Quaternion yQuaternion = Quaternion.AngleAxis (rotAverageY, Vector3.left);
		// yQuaternion =  originalRotation * yQuaternion;
		// playerPosition.Rotate(yQuaternion.eulerAngles);

	}

	public void ThirdPersonMouseCameraY() {

		// float velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
		// transform.RotateAround(
		// 	playerPosition.position,
		// 	transform.TransformDirection(Vector3.left),
		// 	-rotY
		// );


	}
}
