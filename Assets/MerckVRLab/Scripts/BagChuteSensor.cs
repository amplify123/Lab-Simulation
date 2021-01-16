using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagChuteSensor : MonoBehaviour
{
    public BagStateManager BSM;
	public bool dropChuteFlag;
	
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "BagB" && !dropChuteFlag){
			other.gameObject.layer = 2;
			other.gameObject.transform.position = new Vector3(-9.4f,0.5f,1f);
			//other.gameObject.GetComponent<PinchStringBag>().SetBagState("Remove");
			int payloadNumber = other.gameObject.GetComponent<PayloadID>().payloadType;
			if (BSM.BagState == "BagState1"){
				BSM.SetPayloadID(payloadNumber);
				BSM.SetBagState("BagState2");
			}
		}
		if (other.gameObject.tag == "Payload" && dropChuteFlag){
			if (other.gameObject.GetComponent<OVRGrabbable>().isGrabbed == false){
				other.gameObject.layer = 2;
				other.gameObject.transform.position = new Vector3(-10.4f,0.5f,1f);
				Rigidbody rb1 = other.gameObject.GetComponent<Rigidbody>();
				rb1.isKinematic = true;
				//
				int payloadNumber = other.gameObject.GetComponent<PayloadID>().payloadType;
				if (BSM.BagState == "BagState1"){
					BSM.SetPayloadID(payloadNumber);
					BSM.SetBagState("BagState2");
				}
			}
		}

	}
}
