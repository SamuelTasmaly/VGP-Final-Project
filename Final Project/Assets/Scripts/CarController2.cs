using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController2 : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    public float motorForce = 500f;
    public float brakeForce = 1000f;
    public float reverseForce = 200f;
    public float maxSteerAngle = 30f;

    private Rigidbody carRigidbody;
    private float horizontalInput;
    private float verticalInput;
    private bool isHandbrake;
    private bool isReversing;

    private void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isHandbrake = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        HandleHandbrake();
        UpdateWheelPoses();
    }

    private void HandleMotor()
    {
        float motorTorque = 0f;

        if (!isReversing && verticalInput < 0f)
        {
            isReversing = true;
            motorTorque = -reverseForce;
            ApplyBrakes();
        }
        else if (isReversing && verticalInput > 0f)
        {
            isReversing = false;
            motorTorque = 0f;
            ApplyBrakes();
        }
        else if (!isReversing)
        {
            motorTorque = verticalInput * motorForce;
        }
        else
        {
            motorTorque = -verticalInput * reverseForce;
        }

        frontLeftWheel.motorTorque = motorTorque;
        frontRightWheel.motorTorque = motorTorque;
    }

    private void HandleSteering()
    {
        float steerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheel.steerAngle = steerAngle;
        frontRightWheel.steerAngle = steerAngle;
    }

    private void HandleHandbrake()
    {
        if (isHandbrake)
        {
            ApplyBrakes();
        }
        else
        {
            rearLeftWheel.brakeTorque = 0f;
            rearRightWheel.brakeTorque = 0f;
        }
    }

    private void ApplyBrakes()
    {
        if (carRigidbody.velocity.magnitude > 0.1f)
        {
            rearLeftWheel.brakeTorque = brakeForce;
            rearRightWheel.brakeTorque = brakeForce;
        }
        else
        {
            rearLeftWheel.brakeTorque = 0f;
            rearRightWheel.brakeTorque = 0f;
        }
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontLeftWheel);
        UpdateWheelPose(frontRightWheel);
        UpdateWheelPose(rearLeftWheel);
        UpdateWheelPose(rearRightWheel);
    }

    private void UpdateWheelPose(WheelCollider wheelCollider)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);
        // Apply the position and rotation to the visual representation of the wheel
        // (e.g., a separate mesh or sprite for each wheel)
    }
}