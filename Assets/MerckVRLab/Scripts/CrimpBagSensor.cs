using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrimpBagSensor : MonoBehaviour
{
     public BagStateManager BSM;
	 public bool CrimpTriggerFlag;
	 public bool CutterTriggerFlag;
	 
	 void Start(){
		 CrimpTriggerFlag = false;
		 CutterTriggerFlag = false;
	 }
	 
	 public void SetCrimpTriggerFlag(){
		 if (CrimpTriggerFlag){
			if (BSM.BagState == "BagState3"){
				BSM.SetBagState("BagState4");
			}
		}
	 }
	 
	 public void SetCutterTriggerFlag(){
		 if (CutterTriggerFlag){
			if (BSM.BagState == "BagState4"){
				BSM.SetBagState("BagState5");
			}
		}
	 }
	 
     private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Crimper"){
			CrimpTriggerFlag = true;
		}
		if (other.gameObject.tag == "Cutter"){
			CutterTriggerFlag = true;
		}
	}
	
	private void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Crimper"){
			CrimpTriggerFlag = false;
		}
		if (other.gameObject.tag == "Cutter"){
			CutterTriggerFlag = false;
		}
	}
}
