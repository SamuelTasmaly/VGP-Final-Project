using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5000;
    public float turnSpeed = 45.0f;
    public Vector3 com;
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        //playerRb.centerOfMass = com;
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        //float verticalInput = Input.GetAxis("Vertical");
        //playerRb.AddForce(transform.forward * verticalInput * speed * Time.deltaTime);
        //float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.up, turnSpeed *horizontalInput*Time.deltaTime);
        //
        float forward = Input.GetAxis ("Vertical") * speed;
		GetComponent<Rigidbody>().AddRelativeForce (0, 0, forward);
		float turn = Input.GetAxis ("Horizontal") * turnSpeed;
		this.transform.Rotate (0, turn, 0);
        
    }
}
