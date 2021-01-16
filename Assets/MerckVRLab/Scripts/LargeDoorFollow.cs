using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDoorFollow : MonoBehaviour
{
    Vector3 DoorStartPosition;
	public GameObject HandleObj;
	public OVRGrabbable OVGgrabobj;
	
	private bool GrabActive;
	
	// Start is called before the first frame update
    void Start()
    {
        DoorStartPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
		Debug.Log("HOJ : "+ HandleObj.transform.localPosition.y);
		Debug.Log("DSZ : "+ DoorStartPosition.y);
		GrabActive = false;
    }
	
	public void ResetHandle(){
		HandleObj.transform.localPosition = new Vector3(HandleObj.transform.localPosition.x, this.transform.localPosition.y - 12.6f, HandleObj.transform.localPosition.z);
	}
	
	public void ResetPosition(){
		this.transform.localPosition = new Vector3(DoorStartPosition.x, DoorStartPosition.y, DoorStartPosition.z);
		ResetHandle();
	}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("HOJ : "+ HandleObj.transform.localPosition.y);
		//Debug.Log("DSZ : "+ DoorStartPosition.y);
		if (OVGgrabobj.isGrabbed){
			GrabActive = true;
			if (HandleObj.transform.localPosition.y + 13.34f < 32.5f && HandleObj.transform.localPosition.y + 13.34f > 14.2f){
				this.transform.localPosition = new Vector3(DoorStartPosition.x, HandleObj.transform.localPosition.y + 13.34f, DoorStartPosition.z);
			}else{
				if (HandleObj.transform.localPosition.y + 13.34f > 32.5f){
					this.transform.localPosition = new Vector3(DoorStartPosition.x, 32.5f, DoorStartPosition.z);
				}
				if (HandleObj.transform.localPosition.y + 13.34f < 14.2){
					this.transform.localPosition = new Vector3(DoorStartPosition.x, 14.2f, DoorStartPosition.z);
				}
			}
		}else{
			if(GrabActive){
			   HandleObj.transform.localEulerAngles= new Vector3(0f,0f,0f);
			   HandleObj.transform.localPosition = new Vector3(HandleObj.transform.localPosition.x, this.transform.localPosition.y - 12.6f, HandleObj.transform.localPosition.z);
			   GrabActive = false;
			}
		}
    }
}
