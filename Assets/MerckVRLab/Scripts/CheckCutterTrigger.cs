using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCutterTrigger : MonoBehaviour
{
	public OVRGrabbable OVRobj;
	public GameObject ToggleObj;
	public float StartAngle;
	public float TriggerAngle;

	public CrimpBagSensor crimpSensor1;
	public CrimpBagSensor crimpSensor2;
	public CrimpBagSensor crimpSensor3;
	public CrimpBagSensor crimpSensor4;
	public CrimpBagSensor crimpSensor5;
	public CrimpBagSensor crimpSensor6;
	
    void FixedUpdate()
    {
        if (OVRobj.grabbedBy!=null){
			if (OVRobj.grabbedBy.m_trigger > 0.5){
			ToggleObj.transform.localEulerAngles = new Vector3(-180f, 0f, TriggerAngle);
			crimpSensor1.SetCutterTriggerFlag();
			crimpSensor2.SetCutterTriggerFlag();
			crimpSensor3.SetCutterTriggerFlag();
			crimpSensor4.SetCutterTriggerFlag();
			crimpSensor5.SetCutterTriggerFlag();
			crimpSensor6.SetCutterTriggerFlag();
			}else{
				ToggleObj.transform.localEulerAngles = new Vector3(-180f, 0f, StartAngle);
			}
		}
		
    }
	
	
}
