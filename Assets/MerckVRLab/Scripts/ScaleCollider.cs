using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCollider : MonoBehaviour
{
    public Transform scaleTargetPos;
	public GameObject scaleDisplay;
	public GameObject scaleObject;
	
	void Start(){
		scaleDisplay.SetActive(false);
	}
	
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Payload"){
			//other.gameObject.transform.position = new Vector3(scaleTargetPos.position.x,scaleTargetPos.position.y,scaleTargetPos.position.z);
			scaleObject = other.gameObject;
			//
			ScaleDisplayOn();
		}
	}
	
	private void OnTriggerExit(Collider other){
		if (other.gameObject == scaleObject){
			scaleObject = null;
			//
			ScaleDisplayOff();
		}
	}
	
	private void ScaleDisplayOn(){
		scaleDisplay.SetActive(true);
	}
			
	private void ScaleDisplayOff(){
		scaleDisplay.SetActive(false);
	}
}
