using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAIMovement : MonoBehaviour
{

    bool isMoving = false;
    Wander2 wander;
    SteeringBasics steering;
    NearSensor nearSensor;
    CollisionAvoidance collision;
    Rigidbody rigidBody;

    float walkSpeed = 2.5f;

    protected void Awake()
    {
        base.Awake();
        wander = GetComponent<Wander2>();
        steering = GetComponent<SteeringBasics>();
        nearSensor = GetComponentInChildren<NearSensor>();
        collision = GetComponent<CollisionAvoidance>();
        rigidBody = GetComponent<Rigidbody>();

        initSpeedValues();
    }

    void initSpeedValues()
    {
        steering.maxVelocity = walkSpeed;
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector3 accel = Vector3.zero;

            if (nearSensor.targets.Count > 0)
            {
                accel = collision.getSteering(nearSensor.targets);
            }

            if (accel.magnitude < 0.005f)
            {
                accel = wander.getSteering();
            }
            steering.steer(accel);
            steering.lookWhereYoureGoing();
        }
    }

    protected void stayStanding()
    {
        //Collisions end up tipping it over
        Vector3 stayDown = transform.position;
        stayDown.y = 0;
        transform.position = stayDown;

        Vector3 stayUpright = transform.rotation.eulerAngles;
        stayUpright.x = 0;
        stayUpright.z = 0;
        transform.rotation = Quaternion.Euler(stayUpright);
    }
}
