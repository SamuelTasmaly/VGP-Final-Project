using UnityEngine;
using System.Collections;


public class CarController : MonoBehaviour
{
    public WheelCollider[] wheelColliders;
    public Transform[] wheelMeshes;
    public float motorForce = 1000f;
    public float reverseForce = 500f;
    public float brakingForce = 2000f;
    public float steeringForce = 500f;

    private Rigidbody carRigidbody;

    private void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float motor = 0f;
        float braking = 0f;

        if (verticalInput > 0f)
        {
            motor = verticalInput * motorForce;
        }
        else if (verticalInput < 0f)
        {
            motor = verticalInput * reverseForce;
        }
        else
        {
            braking = Input.GetKey(KeyCode.Space) ? brakingForce : 0f;
        }

        float steering = Input.GetAxis("Horizontal") * steeringForce;

        ApplyMotorTorque(motor - braking);
        ApplySteering(steering);

        UpdateWheelMeshes();
    }

    private void ApplyMotorTorque(float torque)
    {
        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            wheelCollider.motorTorque = torque;
        }
    }

    private void ApplySteering(float steering)
    {
        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            wheelCollider.steerAngle = steering;
        }
    }

    private void UpdateWheelMeshes()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            Quaternion wheelRotation;
            Vector3 wheelPosition;
            wheelColliders[i].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelMeshes[i].position = wheelPosition;
            wheelMeshes[i].rotation = wheelRotation;
        }
    }
}