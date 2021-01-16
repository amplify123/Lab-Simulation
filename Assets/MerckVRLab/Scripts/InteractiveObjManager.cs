using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjManager : MonoBehaviour
{
	public GameObject FlaskObj;
	public GameObject ReactObj;
	
	public Vector3 FlaskStartPos;
	public Vector3 ReactStartPos;
	public Vector3 FlaskStartRot;
	public Vector3 ReactStartRot;
	
	public LidController LidControllerObj;
	
	public LargeDoorFollow largeDoorHandleFollow;
		
	public SlideDoorFollow SlideDoor1Follow;
	public SlideDoorFollow SlideDoor2Follow;
	public SlideDoorFollow SlideDoor3Follow;
	public SlideDoorFollow SlideDoor4Follow;
	public SlideDoorFollow SlideDoor5Follow;
	public SlideDoorFollow SlideDoor6Follow;
	
    public DoorAngleFollow Door1AngleFollow;
	public DoorAngleFollow Door2AngleFollow;
	public DoorAngleFollow Door3AngleFollow;
	public DoorAngleFollow Door4AngleFollow;
	
	void Start(){
		FlaskStartPos = new Vector3(FlaskObj.transform.position.x, FlaskObj.transform.position.y, FlaskObj.transform.position.z);
		FlaskStartRot = new Vector3(-90f, 0f, 0f);
		ReactStartPos = new Vector3(ReactObj.transform.position.x, ReactObj.transform.position.y, ReactObj.transform.position.z);
		ReactStartRot = new Vector3(-90f, 0f, 180f);
	}
	public void ResetFlasks(){
		FlaskObj.transform.position = new Vector3(FlaskStartPos.x, FlaskStartPos.y, FlaskStartPos.z );
		FlaskObj.transform.localEulerAngles = new Vector3(FlaskStartRot.x, FlaskStartRot.y, FlaskStartRot.z );
		Rigidbody rb1 = FlaskObj.GetComponent<Rigidbody>();
		rb1.velocity = Vector3.zero;
		rb1.angularVelocity = Vector3.zero;
		rb1.isKinematic = false;
		FlaskObj.gameObject.layer = 9;
		//
		ReactObj.transform.position = new Vector3(ReactStartPos.x, ReactStartPos.y, ReactStartPos.z );
		ReactObj.transform.localEulerAngles = new Vector3(ReactStartRot.x, ReactStartRot.y, ReactStartRot.z );
		Rigidbody rb2 = ReactObj.GetComponent<Rigidbody>();
		rb2.velocity = Vector3.zero;
		rb2.angularVelocity = Vector3.zero;
		rb2.isKinematic = false;
		ReactObj.gameObject.layer = 9;
	}
	
	public void ResetAllInteractive(){
		ResetFlasks();
		//
		LidControllerObj.RestorePosition();
		largeDoorHandleFollow.ResetPosition();
		SlideDoor1Follow.ResetPosition();
		SlideDoor2Follow.ResetPosition();
		SlideDoor3Follow.ResetPosition();
		SlideDoor4Follow.ResetPosition();
		SlideDoor5Follow.ResetPosition();
		SlideDoor6Follow.ResetPosition();
		Door1AngleFollow.ResetPosition();
		Door2AngleFollow.ResetPosition();
		Door3AngleFollow.ResetPosition();
		Door4AngleFollow.ResetPosition();
	}
	
}
