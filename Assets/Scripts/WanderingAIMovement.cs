using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAIMovement : MonoBehaviour
{

    public bool isMoving = false;
    Wander2 wander; //Picks where to go
    SteeringBasics steering;    //Drives it around
    NearSensor nearSensor;  //Collision sensor
    CollisionAvoidance collision;   //Collosion reaction bot

    float walkSpeed = 2.5f;

    private void Awake()
    {
        wander = GetComponent<Wander2>();
        steering = GetComponent<SteeringBasics>();
        nearSensor = GetComponentInChildren<NearSensor>();
        collision = GetComponent<CollisionAvoidance>();

        initSpeedValues();
    }

    void initSpeedValues()
    {
        steering.maxVelocity = walkSpeed;   //Give it speeeeed
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector3 accel = Vector3.zero;

            if (nearSensor.targets.Count > 0)   //If collision
            {
                accel = collision.getSteering(nearSensor.targets);  //Steer away
            }

            if (accel.magnitude < 0.005f)   //If not moving fast enough, pick somewhere
            {
                accel = wander.getSteering();
            }
            steering.steer(accel);  //move
            steering.lookWhereYoureGoing();
        }
    }

    //Doesn't work half the time
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
