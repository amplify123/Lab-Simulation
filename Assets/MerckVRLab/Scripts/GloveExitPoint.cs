using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveExitPoint : MonoBehaviour
{
	public GloveFit GloveSensor;
	public GameObject StaticHand;
    // Start is called before the first frame update
	
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "LeftHand"){
			GloveSensor.ClearLeftEntryPoints();
			//StaticHand.SetActive(true);
		}
		if (other.gameObject.tag == "RightHand"){
			GloveSensor.ClearRightEntryPoints();
			//StaticHand.SetActive(true);
		}
	}

}
