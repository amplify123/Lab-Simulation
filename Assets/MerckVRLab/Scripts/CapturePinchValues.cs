using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;

public class CapturePinchValues : MonoBehaviour
{
    public float LeftPinchValue;
	public float RightPinchValue;
	
	public Hand LeftHandObj;
	public Hand RightHandObj;
	
	public PinchStringBag PSBobj;
	
	private void OnTriggerEnter(Collider other){
		
		if (other.gameObject.tag == "LeftHand" && PSBobj.BagState == "OpenWait"){
			PSBobj.SetBagState("Closed");
		}
		if (other.gameObject.tag == "RightHand" && PSBobj.BagState == "OpenWait"){
			PSBobj.SetBagState("Closed");
		}
	}
	
	private void OnTriggerExit(Collider other){
		
		if (other.gameObject.tag == "LeftHand" ){
			PSBobj.SetBagState("Closed");
		}
		if (other.gameObject.tag == "RightHand"){
			PSBobj.SetBagState("Closed");
		}
	}
	

}
