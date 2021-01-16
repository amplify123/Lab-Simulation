using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBagController : MonoBehaviour
{
    public OVRGrabbable OVRObj;
	public Rigidbody rb;
	
	public GameObject bagObj;
	bool GrabActive;
	bool kinoActive;
	
	public GameObject payloadObj1;
	public GameObject payloadObj2;
	public GameObject payloadObj3;
	
	// Start is called before the first frame update
    void Start()
    {
		gameObject.layer = 2;
		rb.isKinematic = true;
		bagObj.SetActive(false);
		GrabActive = false;
		kinoActive = false;
    }

	public void SetContentType(int idNum){
		payloadObj1.SetActive(false);
		payloadObj2.SetActive(false);
		payloadObj3.SetActive(false);
		switch(idNum){
			case 1:
			payloadObj1.SetActive(true);
			break;
			case 2:
			payloadObj2.SetActive(true);
			break;
			case 3:
			payloadObj3.SetActive(true);
			break;
		}
	}
	
	public void OnActivateBag(){
		gameObject.layer = 9;
		bagObj.SetActive(true);
		GrabActive = true;
	}
    // Update is called once per frame
    void FixedUpdate()
    {
        if (OVRObj.isGrabbed && GrabActive){
			kinoActive = true;
		}
		if (kinoActive && !OVRObj.isGrabbed){
			rb.isKinematic = false;
		}
    }
}
