using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidController : MonoBehaviour
{
   	public OVRGrabbable OVRObj;
	
	public bool GrabActive;
	public Vector3 startPosition;
	private Rigidbody rb;
	
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;
	public float zMin;
	public float zMax;
	
	// Start is called before the first frame update
    void Start()
    {
        startPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
	    rb = this.GetComponent<Rigidbody>();
		GrabActive = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (OVRObj.isGrabbed){
			GrabActive = true;
		}else{
			if(GrabActive == true){
				GrabActive = false;
				if (!OnBoundaryCheck()){
					RestorePosition();
				}
			}
			if (rb.velocity.y != 0){
				if (!OnBoundaryCheck()){
					RestorePosition();
				}
			}
		}
    }
	
	bool OnBoundaryCheck(){ 
		bool boundaryCheck = false;
		if (transform.localPosition.x > xMin && transform.localPosition.x < xMax && transform.localPosition.y > yMin && transform.localPosition.y < yMax && transform.localPosition.z > zMin && transform.localPosition.z < zMax){
			boundaryCheck = true;
		}
		return boundaryCheck;	
	}
	
	public void RestorePosition(){
		this.transform.localPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z);
		this.transform.localEulerAngles = new Vector3(-90f, 0f, -180f);
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}
}
