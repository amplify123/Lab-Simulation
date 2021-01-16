using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
	public string doorState;
	public GameObject[] OpenDoorFollowObjs;
	public GameObject[] CloseDoorFollowObjs;
	
	public double OpenDoorAngle;
	public double CloseDoorAngle;
	public double CurrentDoorAngle;
	
	public float AnimateAngle;
	public float AnimateIncrement;
	
	public bool FumeHoodClose;
	public bool QuitApplicationBool;
	
	public int doorTimer;
	public float doorOpenedTime;
	
	public bool setTimer;
	
	void Start(){
		doorState = "Closed";
		doorTimer = 0;
	}
	
	public void OpenSaysMe(){
		if (doorState == "Closed"){
			CurrentDoorAngle = this.gameObject.transform.localEulerAngles.y;
			if (OpenDoorAngle > CloseDoorAngle){
				doorTimer = 0;
				doorState = "AnimateOpenPositive";
			}else{
				doorTimer = 0;
				doorState = "AnimateOpenNegative";
			}
			//
			OpenDoorFollow();
			if (!FumeHoodClose){
				CloseDoorFollow();
			}
		}
	}
	
	public void OpenFollowed(){
		if (doorState == "Closed"){
			CurrentDoorAngle = this.gameObject.transform.localEulerAngles.y;
			if (OpenDoorAngle > CloseDoorAngle){
				doorState = "AnimateOpenPositive";
			}else{
				doorState = "AnimateOpenNegative";
			}
		}
	}
	
	public void CloseSaysMe(){
		if (doorState == "Opened"){
			CurrentDoorAngle = this.gameObject.transform.localEulerAngles.y;
			if (CloseDoorAngle > OpenDoorAngle){
				doorState = "AnimateClosePositive";
			}else{
				doorState = "AnimateCloseNegative";
			}
			if (FumeHoodClose){
				CloseDoorFollow();
			}
		}
	}
	
	public void OpenDoorFollow(){
		for (int i=0; i < OpenDoorFollowObjs.Length; i++){
			OpenDoorFollowObjs[i].GetComponent<DoorController>().OpenFollowed();
		}
	}
	
	public void CloseDoorFollow(){
		for (int i=0; i < CloseDoorFollowObjs.Length; i++){
			CloseDoorFollowObjs[i].GetComponent<DoorController>().CloseSaysMe();
		}
	}
	
	void FixedUpdate(){
		
		switch (doorState){
			case "Locked":
			break;
			case "Opened":
				if (setTimer){
					doorTimer++;
					if (doorTimer > 60f * doorOpenedTime){
						CloseSaysMe();
					}
				}			
			break;
			case "Closed":
			break;
			case "AnimateOpenPositive":
				this.gameObject.layer = 5;
				CurrentDoorAngle += Time.deltaTime * AnimateAngle;
				this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CurrentDoorAngle, 0f);
				if (CurrentDoorAngle >= OpenDoorAngle ){
					CurrentDoorAngle = OpenDoorAngle;
					this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)OpenDoorAngle, 0f);
					this.gameObject.layer = 16;
					doorState = "Opened";
					if (QuitApplicationBool){
						Application.Quit();
					}
				}
			break;
			case "AnimateOpenNegative":
				this.gameObject.layer = 5;
				CurrentDoorAngle -= Time.deltaTime * AnimateAngle;
				this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CurrentDoorAngle, 0f);
				if (CurrentDoorAngle <= OpenDoorAngle ){
					CurrentDoorAngle = OpenDoorAngle;
					this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)OpenDoorAngle, 0f);
					this.gameObject.layer = 16;
					doorState = "Opened";
					if (QuitApplicationBool){
						Application.Quit();
					}
				}
			break;
			case "AnimateClosePositive":
				this.gameObject.layer = 5;
				CurrentDoorAngle += Time.deltaTime * AnimateIncrement;
				this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CurrentDoorAngle, 0f);
				if (CurrentDoorAngle >= CloseDoorAngle ){
					CurrentDoorAngle = CloseDoorAngle;
					this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CloseDoorAngle, 0f);
					this.gameObject.layer = 16;
					doorState = "Closed";
				}
			break;
			case "AnimateCloseNegative":
				this.gameObject.layer = 5;
				CurrentDoorAngle -= Time.deltaTime * AnimateIncrement;
				this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CurrentDoorAngle, 0f);
				if (CurrentDoorAngle <= CloseDoorAngle ){
					CurrentDoorAngle = CloseDoorAngle;
					this.gameObject.transform.localEulerAngles = new Vector3(0f,(float)CloseDoorAngle, 0f);
					this.gameObject.layer = 16;
					doorState = "Closed";
				}
			break;			
		}
		
	}
	
}
