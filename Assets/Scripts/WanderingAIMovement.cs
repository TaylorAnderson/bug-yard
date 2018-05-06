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

    protected void Awake()
    {
        wander = GetComponent<Wander2>();
        steering = GetComponent<SteeringBasics>();
        nearSensor = GetComponentInChildren<NearSensor>();
        collision = GetComponent<CollisionAvoidance>();
    }

    protected void Update()
    {
        if (isMoving)
        {
            Vector3 accel = getDirection(Vector3.zero);

            steering.steer(accel);  //move
            steering.lookWhereYoureGoing();
        }
    }

    virtual protected Vector3 getDirection(Vector3 accel) 
    {
        if (nearSensor.targets.Count > 0)   //If collision
        {
            accel = collision.getSteering(nearSensor.targets);  //Steer away
        }

        if (accel.magnitude < 0.005f)   //If not moving fast enough, pick somewhere
        {
            accel = wander.getSteering();
        }

        return accel;
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
