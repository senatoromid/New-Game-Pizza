using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheel : MonoBehaviour
{
    public WheelCollider TargetWheel;
    Vector3 WheelPos = new Vector3();
    Quaternion WheelRot = new Quaternion();

    // Update is called once per frame
    void Update()
    {
        TargetWheel.GetWorldPose(out WheelPos, out WheelRot);
       // WheelRot = new Quaternion(0, -90, 0, 0);
        transform.position = WheelPos;
        transform.rotation = WheelRot;
        print(WheelPos + "ss" + WheelRot);
        
    }
}
