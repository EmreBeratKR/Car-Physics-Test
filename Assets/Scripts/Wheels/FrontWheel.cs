using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWheel : Wheel
{
    public void Steer(float angle)
    {
        wheelCollider.steerAngle = angle;
        wheelModel.localEulerAngles = Vector3.up * angle;
    }
}
