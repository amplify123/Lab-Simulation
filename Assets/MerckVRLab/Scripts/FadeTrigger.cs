using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTrigger : MonoBehaviour
{
    public OVRScreenFade screenFadeObj;
	
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "MainCamera"){
			//screenFadeObj.FadeOut();
		}
	}
	private void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "MainCamera"){
			//screenFadeObj.FadeIn();
		}
	}
}
