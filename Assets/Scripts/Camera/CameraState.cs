using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ICameraState
{
    void StateEnter(CameraManager manager);
    void StateUpdate(CameraManager manager);
    void StateFixedUpdate(CameraManager manager);
    void InputHandler(CameraManager manager);
    void StateExit(CameraManager manager);
}

public class CameraState : ICameraState
{

    public CameraState()
    {

    }

    virtual public void StateEnter(CameraManager manager){}
    virtual public void StateUpdate(CameraManager manager){}
    virtual public void StateFixedUpdate(CameraManager manager){}
    virtual public void StateExit(CameraManager manager){}
    virtual public void InputHandler(CameraManager manager){}

}