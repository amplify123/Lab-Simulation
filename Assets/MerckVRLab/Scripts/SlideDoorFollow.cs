using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoorFollow : MonoBehaviour
{
	Vector3 SlideDoorStartPosition;
	
	public GameObject HandleObj;
	public OVRGrabbable OVGgrabobj;
	
	public float deltaX;
	public float startX;
	public float endX;
	
	public GameObject priorDoor;
	public GameObject nextDoor;
	
	public GameObject priorPanel;
	public GameObject nextPanel;
	
	public float priorDeltaX;
	public float nextDeltaX;
	
	private bool GrabActive;
	
	// Start is called before the first frame update
    void Start()
    {
        SlideDoorStartPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
		GrabActive = false;
    }
	
	public void ResetPosition(){
		this.transform.localPosition = new Vector3(SlideDoorStartPosition.x, SlideDoorStartPosition.y, SlideDoorStartPosition.z);
		ResetHandle();
	}
	
	private void OnTriggerEnter(Collider other){
		/*
		if (other.gameObject == priorDoor){
			this.transform.localPosition = new Vector3(priorPanel.transform.localPosition.x + priorDeltaX, this.transform.localPosition.y, this.transform.localPosition.z );
			HandleObj.transform.localPosition = new Vector3(this.transform.localPosition.x - deltaX, 0f, 0f);
		}
		//
		if (other.gameObject == nextDoor){
			this.transform.localPosition = new Vector3(nextPanel.transform.localPosition.x + nextDeltaX, this.transform.localPosition.y, this.transform.localPosition.z );		
			HandleObj.transform.localPosition = new Vector3(this.transform.localPosition.x - deltaX, 0f, 0f);
		}
		*/
	}

	
	public void ResetHandle(){
		HandleObj.transform.localPosition = new Vector3(this.transform.localPosition.x - deltaX, HandleObj.transform.localPosition.y, HandleObj.transform.localPosition.z);
	}

    // Update is called once per frame
    void Update(){
		
		if (OVGgrabobj.isGrabbed){
			GrabActive = true;
			if (HandleObj.transform.localPosition.x + deltaX < endX && HandleObj.transform.localPosition.x + deltaX > startX){
				this.transform.localPosition = new Vector3(HandleObj.transform.localPosition.x + deltaX, SlideDoorStartPosition.y, SlideDoorStartPosition.z);
			}else{
				if (HandleObj.transform.localPosition.x + deltaX > endX){
					this.transform.localPosition = new Vector3(endX, SlideDoorStartPosition.y, SlideDoorStartPosition.z);
				}
				if (HandleObj.transform.localPosition.x + deltaX < startX){
					this.transform.localPosition = new Vector3(startX, SlideDoorStartPosition.y, SlideDoorStartPosition.z);
				}
			}
		}else{
			if(GrabActive){
			   HandleObj.transform.localEulerAngles = new Vector3(0f,0f,0f);
			   HandleObj.transform.localPosition = new Vector3(this.transform.localPosition.x - deltaX, 0f, 0f);
			   GrabActive = false;
			   //
			   priorPanel.GetComponent<SlideDoorFollow>().ResetHandle();
			   nextPanel.GetComponent<SlideDoorFollow>().ResetHandle();
			}
		}
    }
}
