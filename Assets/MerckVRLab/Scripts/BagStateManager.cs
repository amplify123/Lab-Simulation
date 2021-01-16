using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagStateManager : MonoBehaviour
{
    public string BagState;
	public OVRGrabbable OVRgrabObj;
	public InteractiveObjManager InteractiveObj;
	
	public GameObject BagState1Obj;
	public GameObject BagState2Obj;
	public GameObject BagState2aObj;
	public GameObject BagState2bObj;
	public GameObject BagState3Obj;
	public GameObject CrimpObj;
	
	public GameObject TwistSensor;
	public GameObject ChuteSensor;
	
	public GameObject BagStatePackObj;
	public GameObject BagFilledPrefab;
	public Transform BagStateTarget;
	
	public bool CrimpToolActive;
	public bool CutterToolActive;
	
	public bool ResetFlag;
	public bool TwistActive;
	
	public int PayloadID;
	
	// Start is called before the first frame update
    void Start()
    {
		CrimpToolActive = false;
		CutterToolActive = false;
		TwistActive = false;
		PayloadID = 1;
		//
		SetBagState("BagState1");
    }
	
	public void SetPayloadID(int idNum){
		PayloadID = idNum;
	}
	
	public void SetBagState(string stateName){
		
		switch(stateName){
			// Start
			case "BagState1":
			BagState1Obj.SetActive(true);
			BagState2Obj.SetActive(false);
			BagState2aObj.SetActive(false);
			BagState2bObj.SetActive(false);
			BagState3Obj.SetActive(false);
			CrimpObj.SetActive(false);
			TwistSensor.layer = 2;
			BagState = stateName;
			break;
			// Fill
			case "BagState2":
			BagState1Obj.SetActive(false);
			BagState2Obj.SetActive(true);
			BagState2aObj.SetActive(false);
			BagState2bObj.SetActive(false);
			BagState3Obj.SetActive(false);
			CrimpObj.SetActive(false);
			BagStatePackObj = Instantiate(BagFilledPrefab, BagStateTarget.transform.position, BagStateTarget.transform.rotation);
			BagStatePackObj.GetComponent<OVRGrabbable>().enabled = false;
			BagStatePackObj.GetComponent<PayloadID>().payloadType = PayloadID;
			BagStatePackObj.GetComponent<DoubleBagController>().SetContentType(PayloadID);
			TwistSensor.transform.localEulerAngles = new Vector3(0f, 3f, 0f);
			TwistSensor.layer = 9;
			TwistActive = true;
			BagState = stateName;
			break;
			// Twist
			case "BagState2a":
			BagState1Obj.SetActive(false);
			BagState2Obj.SetActive(false);
			BagState2aObj.SetActive(true);
			BagState2bObj.SetActive(false);
			BagState3Obj.SetActive(false);
			CrimpObj.SetActive(false);
			TwistSensor.transform.localEulerAngles = new Vector3(0f, 3f, 0f);
			BagState = stateName;
			break;
			case "BagState2b":
			BagState1Obj.SetActive(false);
			BagState2Obj.SetActive(false);
			BagState2aObj.SetActive(false);
			BagState2bObj.SetActive(true);
			BagState3Obj.SetActive(false);
			CrimpObj.SetActive(false);
			TwistSensor.transform.localEulerAngles = new Vector3(0f, 3f, 0f);
			BagState = stateName;
			break;
			case "BagState3":
			BagState1Obj.SetActive(false);
			BagState2Obj.SetActive(false);
			BagState2aObj.SetActive(false);
			BagState2bObj.SetActive(false);
			BagState3Obj.SetActive(true);
			CrimpObj.SetActive(false);
			TwistSensor.transform.localEulerAngles = new Vector3(0f, 3f, 0f);
			TwistSensor.layer = 2;
			BagState = stateName;
			break;
			// CrimpBagSensor
			case "BagState4":
			CrimpObj.SetActive(true);
			BagState = stateName;
			break;
			// Complete
			case "BagState5":
			BagState3Obj.SetActive(false);
			BagStatePackObj.GetComponent<DoubleBagController>().OnActivateBag();
			//
			if (ResetFlag){
				//InteractiveObj.ResetAllInteractive();
			}
			//
			BagState = stateName;
			SetBagState("BagState1");
			break;
		}
	}
	
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!OVRgrabObj.isGrabbed && TwistActive){
			TwistActive = false;
			TwistSensor.transform.localEulerAngles = new Vector3(0f, 3f, 0f);
		}
		// Check Twist Rotation
		if (OVRgrabObj.isGrabbed && !TwistActive && BagState == "BagState2"){
			CrimpToolActive = false;
			CutterToolActive = false;
			if (TwistSensor.transform.localEulerAngles.x > 45 || TwistSensor.transform.localEulerAngles.x < -45){
				TwistActive = true;
				SetBagState("BagState2a");
			}
		}
		if (OVRgrabObj.isGrabbed && !TwistActive && BagState == "BagState2a"){
			if (TwistSensor.transform.localEulerAngles.x > 45 || TwistSensor.transform.localEulerAngles.x < -45){
				TwistActive = true;
				SetBagState("BagState2b");
			}
		}
		if (OVRgrabObj.isGrabbed && !TwistActive && BagState == "BagState2b"){
			if (TwistSensor.transform.localEulerAngles.x > 45 || TwistSensor.transform.localEulerAngles.x < -45){
				TwistActive = true;
				SetBagState("BagState3");
			}
		}
    }
}
