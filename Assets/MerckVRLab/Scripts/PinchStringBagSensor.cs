using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchStringBagSensor : MonoBehaviour
{
	public PinchStringBag PSBObj;
	
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Payload"){
			if (PSBObj.BagState == "Fixed"){
				PSBObj.SetBagState("Move");
				Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
				//
				//other.gameObject.transform.position = new Vector3(TSBObj.BagCenterObj.transform.position.x, TSBObj.BagCenterObj.transform.position.y, TSBObj.BagCenterObj.transform.position.z);
				other.gameObject.transform.position = new Vector3(10f,0.5f,6f);
				other.gameObject.transform.localEulerAngles= new Vector3(0f,0f,0f);
				other.gameObject.SetActive(false);
				rb.velocity = Vector3.zero;
				rb.angularVelocity = Vector3.zero;
				//
			}
		}
	}
}
