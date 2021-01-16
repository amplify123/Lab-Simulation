using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAngleController : MonoBehaviour
{
    public OVRGrabbable OVRGrabObj;
	
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
			CurrentDoorAngle = this.gameObject.transform.localEulerAngles.y;
			if (OpenDoorAngle > CloseDoorAngle){
				doorState = "AnimateOpenPositive";
			}else{
				doorState = "AnimateOpenNegative";
			}
		}
	}
	
	public void CloseSaysMe(){
		if (doorState == "Opened"){
			CurrentDoorAngle = this.gameObject.transform.localEulerAngles.y;
			if (CloseDoorAngle > OpenDoorAngle){
				doorState = "AnimateClosePositive";
			}else{
				doorState = "AnimateCloseNegative";
			}
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
				CurrentDoorAngle = this.gameObject.transform.localEulerAngles.y;
				if (CloseDoorAngle > OpenDoorAngle){
					if (CurrentDoorAngle >= (OpenDoorAngle + 5)){
						if (OVRGrabObj.isGrabbed){
							OVRGrabObj.grabbedBy.ForceRelease(OVRGrabObj);
						}
						CloseSaysMe();
					}
				}else{
					if (CurrentDoorAngle <= (OpenDoorAngle - 5)){
						if (OVRGrabObj.isGrabbed){
							OVRGrabObj.grabbedBy.ForceRelease(OVRGrabObj);
						}
						CloseSaysMe();
					}
				}
			break;
			//
			case "Closed":
				CurrentDoorAngle = this.gameObject.transform.localEulerAngles.y;
				if (OpenDoorAngle < CloseDoorAngle){
					if (CurrentDoorAngle <= (CloseDoorAngle - 5)){
						if (OVRGrabObj.isGrabbed){
							OVRGrabObj.grabbedBy.ForceRelease(OVRGrabObj);
						}
						OpenSaysMe();
					}
				}else{
					if (CurrentDoorAngle >= (CloseDoorAngle + 5)){
						if (OVRGrabObj.isGrabbed){
							OVRGrabObj.grabbedBy.ForceRelease(OVRGrabObj);
						}
						OpenSaysMe();
					}
				}
			break;
			//
			case "AnimateOpenPositive":
				CurrentDoorAngle += Time.deltaTime * AnimateAngle;
				this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CurrentDoorAngle, 0f);
				if (CurrentDoorAngle >= OpenDoorAngle ){
					CurrentDoorAngle = OpenDoorAngle;
					this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)OpenDoorAngle, 0f);
					jointObj.transform.localEulerAngles = new Vector3(0f,(float)OpenDoorAngle, 0f);
					rb.velocity = handleRB.velocity = grabRB.velocity = Vector3.zero;
					rb.angularVelocity = handleRB.angularVelocity = grabRB.angularVelocity = Vector3.zero;
					doorState = "Opened";
				}
			break;
			//
			case "AnimateOpenNegative":
				CurrentDoorAngle -= Time.deltaTime * AnimateAngle;
				this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CurrentDoorAngle, 0f);
				if (CurrentDoorAngle <= OpenDoorAngle ){
					CurrentDoorAngle = OpenDoorAngle;
					this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)OpenDoorAngle, 0f);
					jointObj.transform.localEulerAngles = new Vector3(0f,(float)OpenDoorAngle, 0f);
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
					rb.velocity = handleRB.velocity = grabRB.velocity = Vector3.zero;
					rb.angularVelocity = handleRB.angularVelocity = grabRB.angularVelocity = Vector3.zero;
					doorState = "Closed";
				}
			break;
			//
			case "AnimateCloseNegative":
				CurrentDoorAngle -= Time.deltaTime * AnimateAngle;
				this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CurrentDoorAngle, 0f);
				if (CurrentDoorAngle <= CloseDoorAngle ){
					CurrentDoorAngle = CloseDoorAngle;
					this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CloseDoorAngle, 0f);
					jointObj.transform.localEulerAngles = new Vector3(0f,(float)CloseDoorAngle, 0f);
					rb.velocity = handleRB.velocity = grabRB.velocity = Vector3.zero;
					rb.angularVelocity = handleRB.angularVelocity = grabRB.angularVelocity = Vector3.zero;
					doorState = "Closed";
				}
			break;			
		}
    }
}
