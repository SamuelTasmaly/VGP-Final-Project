using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5000;
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(transform.forward * verticalInput * speed * Time.deltaTime);
    }
}
