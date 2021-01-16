using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchStringBag : MonoBehaviour
{
	public GameObject FixedObj;
	public GameObject OpenObj;
	public GameObject ClosedObj;
	
	public GameObject ContentObj;
	
	public OVRGrabbable OVRObj;
	public Rigidbody rb;
	
	public string BagState;
	private bool GrabActive;
	
	// Start is called before the first frame update
    void Start()
    {
		GrabActive = false;
		//OVRObj.enabled = false;
		SetBagState("Fixed");
    }

	public void SetBagState(string stateName){	
		Debug.Log("SetBagState - " + stateName);
		switch(stateName){
			case "Reset":
				BagState = "Fixed";
			break;
			case "Fixed":
				rb.isKinematic = true;
				rb.useGravity = false;
				FixedObj.SetActive(true);
				OpenObj.SetActive(false);
				ClosedObj.SetActive(false);
				ContentObj.SetActive(false);
				//OVRObj.enabled = false;
				BagState = stateName;
			break;	
			case "Move":
				ContentObj.SetActive(true);
				FixedObj.SetActive(true);
				OpenObj.SetActive(false);
				ClosedObj.SetActive(false);
				OVRObj.enabled = true;
				BagState = stateName;
			break;			
			case "Open":
				//OVRObj.enabled = true;
				gameObject.layer = 9;
				ContentObj.SetActive(false);
				FixedObj.SetActive(false);
				OpenObj.SetActive(true);
				ClosedObj.SetActive(false);
				BagState = stateName;
			break;
			case "Close":
				ContentObj.SetActive(false);
				FixedObj.SetActive(false);
				OpenObj.SetActive(false);
				ClosedObj.SetActive(true);
				BagState = stateName;
			break;
			case "Remove":
				BagState = stateName;
			break;
		}
	}
	
	private void OnTriggerExit(Collider other){
		/*
		if (other.gameObject.tag == "LeftHand" && BagState == "OpenWait"){
			SetBagState("Closed");
		}
		if (other.gameObject.tag == "RightHand" && BagState == "OpenWait"){
			SetBagState("Closed");
		}
		*/
	}
	
	
    // Update is called once per frame
    void FixedUpdate()
    {
		if (OVRObj.isGrabbed){
			if (BagState == "Move"){
				SetBagState("Open");
			}
			if (BagState == "Remove"){
				//this.gameObject.SetActive(false);
			}
			GrabActive = true;
		}else{
			if(GrabActive){
				if (BagState == "Open"){
					rb.isKinematic = false;
					rb.useGravity = true;
					SetBagState("Close");
				}else{
					if (BagState == "Close"){
						rb.isKinematic = false;
						rb.useGravity = true;
					}
				}
				if (BagState == "Remove"){
					this.transform.position = new Vector3(10f,0.5f,6f);
				}
				GrabActive = false;
			}
			if (BagState == "Move"){
				//OVRObj.enabled = true;
				gameObject.layer = 9;
			}
		}
 
    }
}
