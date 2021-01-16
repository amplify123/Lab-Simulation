using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDtoggle : MonoBehaviour
{
    public GameObject LedDisplay;
	
	void Start(){
		LedDisplay.SetActive(true);
	}
	
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Payload"){
			LedDisplay.SetActive(false);
		}
	}
	private void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Payload"){
			LedDisplay.SetActive(true);
		}
	}
}
