using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, 45 *horizontalInput*Time.deltaTime);
        //transform.Rotate(Vector3.right, 100 *verticalInput*Time.deltaTime);
        
    }
}
