using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieStringBag : MonoBehaviour
{
    public Transform LeftTieLookObj;
	public Transform LeftTieFocusObj;
	public OVRGrabbable LeftOVGGrabObj;
	
	public Transform RightTieLookObj;
	public Transform RightTieFocusObj;
	public OVRGrabbable RightOVGGrabObj;
	
	public GameObject FixedObj;
	public GameObject OpenObj;
	public GameObject ClosedObj;
	public GameObject TieStringObj;
	
	public GameObject BagCenterObj;
	public GameObject ContentObj;
	
	private bool LeftGrabActive;
	private bool RightGrabActive;
	
	private float LeftDist;
	private float RightDist;
	
	private Vector3 LeftTieStartPosition;
	private Vector3 RightTieStartPosition;
	
	public string BagState;
	
	// Start is called before the first frame update
    void Start()
    {
        LeftGrabActive = false;
		RightGrabActive = false;
		//
		LeftTieStartPosition = new Vector3(LeftTieFocusObj.transform.localPosition.x, LeftTieFocusObj.transform.localPosition.y, LeftTieFocusObj.transform.localPosition.z);
		RightTieStartPosition = new Vector3(RightTieFocusObj.transform.localPosition.x, RightTieFocusObj.transform.localPosition.y, RightTieFocusObj.transform.localPosition.z);
		//
		ResetLeftTie();
		SetBagState("Fixed");
    }
	
	public void SetBagState(string stateName){	
		switch(stateName){
			case "Reset":
				BagState = "Fixed";
			break;
			case "Fixed":
				FixedObj.SetActive(true);
				OpenObj.SetActive(false);
				ClosedObj.SetActive(false);
				TieStringObj.SetActive(false);
				ContentObj.SetActive(false);
				BagState = stateName;
			break;		
			case "Open":
				ContentObj.SetActive(true);
				TieStringObj.SetActive(true);
				FixedObj.SetActive(false);
				OpenObj.SetActive(true);
				ClosedObj.SetActive(false);
				BagState = stateName;
			break;
			case "Tied":
				OpenObj.SetActive(false);
				ClosedObj.SetActive(true);
				BagState = stateName;
			break;
			case "Closed":
				TieStringObj.SetActive(false);
				FixedObj.SetActive(false);
				OpenObj.SetActive(false);
				ClosedObj.SetActive(true);
				BagState = stateName;
			break;
		}
	}
	
	void ResetLeftTie(){
		LeftTieFocusObj.transform.localPosition = new Vector3(LeftTieStartPosition.x, LeftTieStartPosition.y, LeftTieStartPosition.z);
		UpdateLeftTieLength();
	}
	
	void ResetRightTie(){
		RightTieFocusObj.transform.localPosition = new Vector3(RightTieStartPosition.x, RightTieStartPosition.y, RightTieStartPosition.z);
		UpdateRightTieLength();
	}

	void UpdateLeftTieLength(){
		LeftDist = Vector3.Distance(LeftTieLookObj.transform.localPosition, LeftTieFocusObj.localPosition);
		LeftTieLookObj.transform.LookAt(LeftTieFocusObj);
		LeftTieLookObj.transform.localScale = new Vector3(1f, 1f, LeftDist);
	}
	void UpdateRightTieLength(){
		RightDist = Vector3.Distance(RightTieLookObj.transform.localPosition, RightTieFocusObj.localPosition);
		RightTieLookObj.transform.LookAt(RightTieFocusObj);
		RightTieLookObj.transform.localScale = new Vector3(1f, 1f, RightDist/2f);
	}

	void FixedUpdate()
    {
        if (LeftOVGGrabObj.isGrabbed){
			LeftGrabActive = true;
			UpdateLeftTieLength();
		}
		//
		if (RightOVGGrabObj.isGrabbed){
			RightGrabActive = true;
			UpdateRightTieLength();
		}
		//
		if (!LeftOVGGrabObj.isGrabbed && LeftGrabActive == true){
			ResetLeftTie();
			LeftGrabActive = false;
		}
		//
		if (!RightOVGGrabObj.isGrabbed && RightGrabActive == true){
			ResetRightTie();
			RightGrabActive = false;
		}
		//
		if (LeftGrabActive){
			if (LeftDist > 0.225f){
				SetBagState("Tied");
			}
		}
		//
		if (!LeftGrabActive && !RightGrabActive && BagState == "Tied"){
			SetBagState("Closed");
		}
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
