using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAutos : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private bool isBreaking;

    [SerializeField] private float breakForce;
    [SerializeField] private float motorForce;

    [SerializeField] private WheelCollider FrontLeftWheelc;
    [SerializeField] private WheelCollider FrontRightWheelc;
    [SerializeField] private WheelCollider RearLeftWheelc;
    [SerializeField] private WheelCollider ReartRightWheelc;

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
        FrontLeftWheelc.motorTorque = verticalInput * motorForce;
        FrontRightWheelc.motorTorque = verticalInput * motorForce;
    }

    private void HandleSteering()
    {
        
    }

    private void UpdateWheels()
    {
        
    }
}
