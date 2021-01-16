using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagBExitTrigger : MonoBehaviour
{
   	public PinchStringBag PSBobj;
	
    void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "BagB" && PSBobj.BagState == "Fixed"){
			PSBobj.SetBagState("Move");
		}
	}
}
