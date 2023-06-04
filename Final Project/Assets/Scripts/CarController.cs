using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
    public WheelCollider[] wheelColliders;
    public Transform[] wheelMeshes;
    public float maxMotorTorque = 100f;
    public float maxSteeringAngle = 30f;

    private float motor;
    private float steering;



    private void FixedUpdate()
    {
        // Get input for motor and steering
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        // Apply motor torque to all wheel colliders
        ApplyMotorTorque();

        // Apply steering angle to front wheel colliders
        ApplySteeringAngle();

        // Update wheel meshes rotation and position based on wheel colliders
        UpdateWheelMeshes();
    }

    private void ApplyMotorTorque()
    {
        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            wheelCollider.motorTorque = motor;
        }
    }

    private void ApplySteeringAngle()
    {
        wheelColliders[0].steerAngle = steering; // Front left wheel
        wheelColliders[1].steerAngle = steering; // Front right wheel
    }

    private void UpdateWheelMeshes()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            Quaternion rotation;
            Vector3 position;
            wheelColliders[i].GetWorldPose(out position, out rotation);
            wheelMeshes[i].position = position;
            wheelMeshes[i].rotation = rotation;
        }
    }
}