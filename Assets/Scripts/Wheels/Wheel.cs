using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class Wheel : MonoBehaviour
{
    [SerializeField] protected Transform wheelModel;
    protected WheelCollider wheelCollider;

    private Vector3 position;
    private Quaternion rotation;


    private void Start()
    {
        wheelCollider = this.GetComponent<WheelCollider>();
    }

    public void SetTorque(float torque)
    {
        wheelCollider.motorTorque = torque;
        wheelCollider.GetWorldPose(out position, out rotation);
        wheelModel.transform.position = position;
    }
}
