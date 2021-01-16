using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagCExitTrigger : MonoBehaviour
{
   	public PinchStringBag PSBobj;
	
    void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "BagB"){
			//PSBobj.SetBagState("Move");
			other.gameObject.GetComponent<PinchStringBag>().SetBagState("Remove");
		}
	}
}
