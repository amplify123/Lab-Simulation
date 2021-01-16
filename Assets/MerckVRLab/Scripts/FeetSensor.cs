using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetSensor : MonoBehaviour
{
	public CapsuleFollow capsuleObj;
	
    private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Feet"){
			capsuleObj.SetFollowToggle(false);
		}
	}
	
	private void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Feet"){
			capsuleObj.SetFollowToggle(true);
		}
	}
}
