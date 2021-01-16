using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAngleFollow : MonoBehaviour
{
    public OVRGrabbable OVRGrabObj;
	public DoorAngleController DoorControlObj;
	
	public GameObject LockAngleObj;
	public Vector3 LockAngleStart;
	public GameObject DoorObj;
	public GameObject DoorGrabObj;
	
	public string LockState;
	
    void Start()
    {
        LockAngleStart = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
		DoorGrabObj.layer = 2;
		LockState = "Locked";
    }
	
	public void ResetPosition(){
		transform.localEulerAngles = new Vector3(LockAngleStart.x, LockAngleStart.y, LockAngleStart.z);
		LockAngleObj.transform.localEulerAngles = new Vector3(LockAngleStart.x, LockAngleStart.y, LockAngleStart.z);
	}

    void FixedUpdate()
    {
        float LockAngle = LockAngleObj.transform.localEulerAngles.x;
		
		if (LockState == "Locked" && LockAngle < 357.5){
			if (OVRGrabObj.grabbedBy!=null){
				OVRGrabObj.grabbedBy.ForceRelease(OVRGrabObj);
			}
			LockAngle = 270;
			LockAngleObj.transform.localEulerAngles = new Vector3(LockAngle, LockAngleStart.y, LockAngleStart.z);
			DoorControlObj.OpenSaysMe();
			LockState = "AnimateToOpen";
		}
		if (LockState == "AnimateToOpen" && DoorControlObj.doorState == "Opened"){
			DoorGrabObj.layer = 9;
			LockState = "Opened";
		}
		if (LockState == "Opened" && LockAngle > 273){
			if (OVRGrabObj.grabbedBy!=null){
				OVRGrabObj.grabbedBy.ForceRelease(OVRGrabObj);
			}
			DoorGrabObj.layer = 2;
			DoorControlObj.CloseSaysMe();
			LockState = "AnimateToLock";
		}
		if (LockState == "AnimateToLock" && DoorControlObj.doorState == "Closed"){
			LockAngle = 359;
			LockAngleObj.transform.localEulerAngles = new Vector3(LockAngle, LockAngleStart.y, LockAngleStart.z);
			LockState = "Locked";
		}
		if (LockState == "Opened" && DoorObj.transform.localEulerAngles.y <= 1){
			LockAngle = 359;
			LockAngleObj.transform.localEulerAngles = new Vector3(LockAngle, LockAngleStart.y, LockAngleStart.z);
			DoorObj.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			DoorGrabObj.layer = 2;
			DoorControlObj.doorState = "Closed";
			LockState = "Locked";
		}
		//
		transform.localEulerAngles = new Vector3(LockAngle, LockAngleStart.y, LockAngleStart.z);
    }
	
	 void OnTriggerExit(Collider other){
		
		if (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand" ){
			Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

	}
}
