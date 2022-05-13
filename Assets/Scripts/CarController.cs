using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform massCenter;
    
    [Header("Front Wheels")]
    [SerializeField] private FrontWheel rightFrontWheel;
    [SerializeField] private FrontWheel leftFrontWheel;

    [Header("Rear Wheels")]
    [SerializeField] private RearWheel rightRearWheel;
    [SerializeField] private RearWheel leftRearWheel;

    [Header("Values")]
    [SerializeField, Min(0f)] private float enginePower;
    [SerializeField, Range(0f, 90f)] private float maxSteerAngle;
    [SerializeField, Range(0f, 1f)] private float steeringSpeed;


    private Rigidbody body;
    private float steerAngle;

    private void Start()
    {
        body = this.GetComponent<Rigidbody>();
        body.centerOfMass = massCenter.localPosition;
    }

    private void FixedUpdate()
    {
        float torquePerWheel = Input.GetAxis("Vertical") * enginePower * 0.25f;
        rightFrontWheel.SetTorque(torquePerWheel);
        leftFrontWheel.SetTorque(torquePerWheel);
        rightRearWheel.SetTorque(torquePerWheel);
        leftRearWheel.SetTorque(torquePerWheel);

        float desiredSteerAngle = Input.GetAxis("Horizontal") * maxSteerAngle;

        steerAngle = Mathf.Lerp(steerAngle, desiredSteerAngle, steeringSpeed);
        
        rightFrontWheel.Steer(steerAngle);
        leftFrontWheel.Steer(steerAngle);
    }
}
