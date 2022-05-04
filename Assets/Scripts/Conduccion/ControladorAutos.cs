using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAutos : MonoBehaviour
{

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private float currentSteerAngle;
    private float currentBreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerInAngle;

    [SerializeField] private WheelCollider frontLeftWheelc;
    [SerializeField] private WheelCollider frontRightWheelc;
    [SerializeField] private WheelCollider rearLeftWheelc;
    [SerializeField] private WheelCollider rearRightWheelc;

    [SerializeField] private Transform frontLeftWheelt;
    [SerializeField] private Transform frontRightWheelt;
    [SerializeField] private Transform rearLeftWheelt;
    [SerializeField] private Transform rearRightWheelt;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelc.motorTorque = verticalInput * motorForce;
        frontRightWheelc.motorTorque = verticalInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        frontRightWheelc.brakeTorque = currentBreakForce;
        frontLeftWheelc.brakeTorque = currentBreakForce;
        rearLeftWheelc.brakeTorque = currentBreakForce;
        rearRightWheelc.brakeTorque = currentBreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerInAngle * horizontalInput;
        frontLeftWheelc.steerAngle = currentSteerAngle;
        frontRightWheelc.steerAngle = currentSteerAngle;
        rearLeftWheelc.steerAngle = steerAngle;
        rearRightWheelc.steerAngle = steerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelc, frontLeftWheelt);
        UpdateSingleWheel(frontRightWheelc, frontRightWheelt);
        UpdateSingleWheel(rearLeftWheelc, rearLeftWheelt);
        UpdateSingleWheel(rearRightWheelc, rearRightWheelt);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
