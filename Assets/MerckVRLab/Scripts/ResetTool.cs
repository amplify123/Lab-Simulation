using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTool : MonoBehaviour
{
    public Vector3 ToolStartPos;
	public Vector3 ToolStartRot;
	
	public OVRGrabbable OVRGrabObj;
	private bool GrabActive;
	
	public float Xmin;
	public float Xmax;
	public float Ymin;
	public float Ymax;
	public float Zmin;
	public float Zmax;
	
	public bool insideIsolator;
	
	// Start is called before the first frame update
    void Start()
    {
        ToolStartPos = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
		ToolStartRot = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
		GrabActive = false;
	}

	public void RestorePosition(){
		this.transform.localPosition = new Vector3(ToolStartPos.x, ToolStartPos.y, ToolStartPos.z );
		this.transform.localEulerAngles = new Vector3(ToolStartRot.x, ToolStartRot.y, ToolStartRot.z );
		//
		Rigidbody rb = this.GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}
	
	bool OnBoundaryCheck(){ 
		bool boundaryCheck = false;
		if (transform.localPosition.x > Xmin && transform.localPosition.x < Xmax && transform.localPosition.y > Ymin && transform.localPosition.y < Ymax && transform.localPosition.z > Zmin && transform.localPosition.z < Zmax){
			boundaryCheck = true;
		}
		return boundaryCheck;	
	}
		
    // Update is called once per frame
    void FixedUpdate()
    {
		if (OVRGrabObj.isGrabbed){
			GrabActive = true;
		}else{
			if(GrabActive == true){
				GrabActive = false;
				if (!OnBoundaryCheck() && insideIsolator){
					RestorePosition();
				}
			}
		}
    }
}
