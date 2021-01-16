using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAngleStop : MonoBehaviour
{
    Rigidbody rb;
	
	// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localEulerAngles.y <= -89.0f || transform.localEulerAngles.y >= -1){
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
    }
}
