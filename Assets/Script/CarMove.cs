using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    Vector3 Distance;
    bool Left;
    float ss = 0;
    // array for storing if the 3 mouse buttons are dragging
    bool[] isDragActive;

    // for remembering if a button was down in previous frame
    bool[] downInPreviousFrame;
    [SerializeField] float speed;
    [SerializeField] float MaxSteerinAngle;
    [SerializeField] WheelCollider FrontLeftColl;
    [SerializeField] WheelCollider FrontRightColl;
    [SerializeField] WheelCollider RearLeftColl;
    [SerializeField] WheelCollider RearRightColl;
    [SerializeField] Transform FrontLeftTrans;
    [SerializeField] Transform FrontRightTrans;
    [SerializeField] Transform RearLeftTrans;
    [SerializeField] Transform RearRightTrans;

    float CurrentSterrin;
    
    void Start()
    {
        isDragActive = new bool[] { false, false, false };
        downInPreviousFrame = new bool[] { false, false, false };
    }
    private void FixedUpdate()
    {
        GetInput();
    }

    void Update()
    {
        FrontLeftColl.motorTorque = speed * 2;
        FrontRightColl.motorTorque = speed * 2;
    }

    void GetInput()
    {
        for (int i = 0; i < isDragActive.Length; i++)
        {
            if (Input.GetMouseButton(i))
            {
                if (downInPreviousFrame[i])
                {
                    if (isDragActive[i])
                    {
                        OnDragging(i);
                    }
                    else
                    {
                        isDragActive[i] = true;
                        OnDraggingStart(i);
                    }
                }
                downInPreviousFrame[i] = true;
            }
            else
            {
                if (isDragActive[i])
                {
                    isDragActive[i] = false;
                    OnDraggingEnd(i);
                }
                downInPreviousFrame[i] = false;
            }
        }
    }

    public virtual void OnDraggingStart(int mouseButton)
    {
        Distance = Input.mousePosition;  
    }

    public virtual void OnDragging(int mouseButton)
    {
        if (Input.mousePosition.x > Distance.x)
        {
            Left = true;
           
         
            CurrentSterrin = MaxSteerinAngle * .5f;
            FrontRightColl.steerAngle = CurrentSterrin;
            FrontLeftColl.steerAngle = CurrentSterrin;
            UpdatingUse(FrontRightColl, FrontRightTrans);
            UpdatingUse(FrontLeftColl, FrontLeftTrans);
            UpdatingUse(RearLeftColl, RearLeftTrans);
            UpdatingUse(RearRightColl, RearRightTrans);
        }
        if (Input.mousePosition.x < Distance.x)
        {
            Left = true;
            CurrentSterrin = MaxSteerinAngle * -.5f;
            FrontRightColl.steerAngle = CurrentSterrin;
            FrontLeftColl.steerAngle = CurrentSterrin;
            UpdatingUse(FrontRightColl, FrontRightTrans);
            UpdatingUse(FrontLeftColl, FrontLeftTrans);
            UpdatingUse(RearLeftColl, RearLeftTrans);
            UpdatingUse(RearRightColl, RearRightTrans);
        }
    }

    public virtual void OnDraggingEnd(int mouseButton)
    {
        Distance = Input.mousePosition;
        Left = false;

    }

    void UpdatingUse(WheelCollider WheelCol, Transform WheelTra)
    {
        Vector3 pos;
        Quaternion rot;
        WheelCol.GetWorldPose(out pos, out rot);
        WheelTra.rotation = rot;
        WheelTra.position = pos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Left)
        {
            if (other.gameObject.tag == "Right")
            {

                for (int i = 0; i < 7; i++)
                {

                    ss += .2f;
                    CurrentSterrin = MaxSteerinAngle * ss;

                    FrontRightColl.steerAngle = CurrentSterrin;
                }

            }
            if (other.gameObject.tag == "End")
            {
                CurrentSterrin = 0;
                ss = 0;
                FrontRightColl.steerAngle = CurrentSterrin;
            }
            if (other.gameObject.tag == "Left")
            {
                CurrentSterrin = MaxSteerinAngle * -1f;
                print(CurrentSterrin);
                FrontRightColl.steerAngle = CurrentSterrin;
            }
        }
    }
}
