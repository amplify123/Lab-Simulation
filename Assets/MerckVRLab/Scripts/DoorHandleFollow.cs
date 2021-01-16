using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandleFollow : MonoBehaviour
{
    public Transform targetObj;
	
	public GameObject HandleObj;
	public GameObject PushObj;
	public GameObject ContainerObj;
	public OVRGrabbable OVGgrabobj;
	
	Rigidbody rb;
	
	private bool GrabActive;
	Vector3 HandleStartPosition;
	
	// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		HandleStartPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
		GrabActive = false;
    }

	public void ResetPosition(){
		HandleObj.transform.localEulerAngles = new Vector3(0f,0f,0f);
		HandleObj.transform.localPosition = new Vector3(HandleStartPosition.x, HandleStartPosition.y, HandleStartPosition.z);
		this.transform.localPosition = new Vector3(HandleStartPosition.x, HandleStartPosition.y, HandleStartPosition.z);
	}
	
    // Update is called once per frame
    void FixedUpdate()
    {
        if (OVGgrabobj.isGrabbed){
			GrabActive = true;
			rb.MovePosition(targetObj.position);
		}else{
			if(GrabActive){
			   ResetPosition();
			   //
			   Rigidbody rbHandle = HandleObj.GetComponent<Rigidbody>();
			   rb.velocity = rbHandle.velocity = Vector3.zero;
			   rb.angularVelocity = rbHandle.angularVelocity = Vector3.zero;
			   Rigidbody pushHandle = PushObj.GetComponent<Rigidbody>();
			   pushHandle.velocity = Vector3.zero;
			   pushHandle.angularVelocity = Vector3.zero;
			   //
			   /*
			   Rigidbody rbContainder = ContainerObj.GetComponent<Rigidbody>();
			   rbContainder.velocity = Vector3.zero;
			   rbContainder.angularVelocity = Vector3.zero;
			   //
			   float currentDoorAngle = ContainerObj.transform.localEulerAngles.y;
			   if (currentDoorAngle > 0.01f){
					currentDoorAngle = 0f;
			   }
			   ContainerObj.transform.localEulerAngles = new Vector3(0f,currentDoorAngle,0f);
			   */
			   //
			   GrabActive = false;
			}
		}
    }
	
}
