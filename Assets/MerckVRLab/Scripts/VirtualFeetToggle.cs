using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualFeetToggle : MonoBehaviour
{
	public GameObject feet;
	public GameObject target;
	bool feetVisible;
	
	void Start()
    {
		feetVisible = false;
	}
	
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand"){
			if (!feetVisible){
				feetVisible = true;
				feet.GetComponent<MeshRenderer>().enabled = true;
				target.GetComponent<MeshRenderer>().enabled = true;
			}else{
				feetVisible = false;
				feet.GetComponent<MeshRenderer>().enabled = false;
				target.GetComponent<MeshRenderer>().enabled = false;
			}
		}
	}

}
