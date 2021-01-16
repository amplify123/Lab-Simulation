using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAngleFollow : MonoBehaviour
{
	public GameObject DoorAngleObj;
	public Vector3 DoorAngleStart;
	
    void Start()
    {
        DoorAngleStart = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
    }
	
	public void ResetPosition(){
		transform.localEulerAngles = new Vector3(DoorAngleStart.x, DoorAngleStart.y, DoorAngleStart.z);
		DoorAngleObj.transform.localEulerAngles = new Vector3(DoorAngleStart.x, DoorAngleStart.y, DoorAngleStart.z);
	}

    void FixedUpdate()
    {
        float DoorAngle = DoorAngleObj.transform.localEulerAngles.y;
		transform.localEulerAngles = new Vector3(DoorAngleStart.x, DoorAngle, DoorAngleStart.z);
    }
	
	 void OnTriggerExit(Collider other){
		
		if (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand" ){
			Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

	}
}
