using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAngleController2 : MonoBehaviour
{
    public OVRGrabbable OVRGrabObj;
	public DoorHandleFollow HandleFollowObj;
	
	public string doorState;
	public bool initOpen;
	public GameObject jointObj;
	private Rigidbody rb;
	
	public Rigidbody handleRB;
	public Rigidbody grabRB;
	 
	public double OpenDoorAngle;
	public double CloseDoorAngle;
	public double CurrentDoorAngle;
	
	public float AnimateAngle;
	public float AnimateIncrement;
	
	// Start is called before the first frame update
    void Start()
    {
		doorState = "Closed";
		if (initOpen) {
			doorState = "Opened";
		}
		rb = jointObj.GetComponent<Rigidbody>();
    }

	public void OpenSaysMe(){
		if (doorState == "Closed"){
			doorState = "AnimateOpenNegative";
		}
	}
	
	public void CloseSaysMe(){
		if (doorState == "Opened"){
			doorState = "AnimateClosePositive";
		}
	}
	
    // Update is called once per frame
    void FixedUpdate()
    {
        switch (doorState){
			case "Locked":
			break;
			//
			case "Opened":
				CurrentDoorAngle = jointObj.transform.localEulerAngles.y;
				transform.localEulerAngles = new Vector3(0f, (float)CurrentDoorAngle, 0f);
				//
				if (CurrentDoorAngle >= (OpenDoorAngle + 5)){
					if (OVRGrabObj.isGrabbed){
						OVRGrabObj.grabbedBy.ForceRelease(OVRGrabObj);
					}
					jointObj.SetActive(false);
					CloseSaysMe();
				}
			break;
			//
			case "Closed":
				CurrentDoorAngle = jointObj.transform.localEulerAngles.y;
				transform.localEulerAngles = new Vector3(0f, (float)CurrentDoorAngle, 0f);
				//
				if (CurrentDoorAngle <= (CloseDoorAngle - 5)){
					if (OVRGrabObj.isGrabbed){
						OVRGrabObj.grabbedBy.ForceRelease(OVRGrabObj);
					}
					jointObj.SetActive(false);
					OpenSaysMe();
				}
			break;
			//
			case "AnimateOpenPositive":/*
				CurrentDoorAngle += Time.deltaTime * AnimateAngle;
				this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CurrentDoorAngle, 0f);
				if (CurrentDoorAngle >= OpenDoorAngle ){
					CurrentDoorAngle = OpenDoorAngle;
					this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)OpenDoorAngle, 0f);
					jointObj.transform.localEulerAngles = new Vector3(0f,(float)OpenDoorAngle, 0f);
					jointObj.SetActive(true);
					//HandleFollowObj.ResetPosition();
					rb.velocity = handleRB.velocity = grabRB.velocity = Vector3.zero;
					rb.angularVelocity = handleRB.angularVelocity = grabRB.angularVelocity = Vector3.zero;
					doorState = "Opened";
				}*/
			break;
			//
			case "AnimateOpenNegative":
				CurrentDoorAngle -= Time.deltaTime * AnimateAngle;
				this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CurrentDoorAngle, 0f);
				if (CurrentDoorAngle <= OpenDoorAngle ){
					CurrentDoorAngle = OpenDoorAngle;
					this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)OpenDoorAngle, 0f);
					jointObj.transform.localEulerAngles = new Vector3(0f,(float)OpenDoorAngle, 0f);
					jointObj.SetActive(true);
					//HandleFollowObj.ResetPosition();
					rb.velocity = handleRB.velocity = grabRB.velocity = Vector3.zero;
					rb.angularVelocity = handleRB.angularVelocity = grabRB.angularVelocity = Vector3.zero;
					doorState = "Opened";
				}
			break;
			//
			case "AnimateClosePositive":
				CurrentDoorAngle += Time.deltaTime * AnimateAngle;
				this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CurrentDoorAngle, 0f);
				if (CurrentDoorAngle >= CloseDoorAngle ){
					CurrentDoorAngle = CloseDoorAngle;
					this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CloseDoorAngle, 0f);
					jointObj.transform.localEulerAngles = new Vector3(0f,(float)CloseDoorAngle, 0f);
					jointObj.SetActive(true);
					//HandleFollowObj.ResetPosition();
					rb.velocity = handleRB.velocity = grabRB.velocity = Vector3.zero;
					rb.angularVelocity = handleRB.angularVelocity = grabRB.angularVelocity = Vector3.zero;
					doorState = "Closed";
				}
			break;
			//
			case "AnimateCloseNegative":/*
				CurrentDoorAngle -= Time.deltaTime * AnimateAngle;
				this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CurrentDoorAngle, 0f);
				if (CurrentDoorAngle <= CloseDoorAngle ){
					CurrentDoorAngle = CloseDoorAngle;
					this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CloseDoorAngle, 0f);
					jointObj.transform.localEulerAngles = new Vector3(0f,(float)CloseDoorAngle, 0f);
					jointObj.SetActive(true);
					//HandleFollowObj.ResetPosition();
					rb.velocity = handleRB.velocity = grabRB.velocity = Vector3.zero;
					rb.angularVelocity = handleRB.angularVelocity = grabRB.angularVelocity = Vector3.zero;
					doorState = "Closed";
				}*/
			break;			
		}
    }
}
