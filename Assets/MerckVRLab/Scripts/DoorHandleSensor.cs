using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandleSensor : MonoBehaviour
{
    public DoorController DoorControlObj;
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "RightHand" || other.gameObject.tag == "LeftHand" || other.gameObject.tag == "Hands"){
			if (DoorControlObj.doorState == "Closed"){
				DoorControlObj.OpenSaysMe();
			}
			if (DoorControlObj.doorState == "Opened"){
				DoorControlObj.CloseSaysMe();
			}
		}
	}
	
}
