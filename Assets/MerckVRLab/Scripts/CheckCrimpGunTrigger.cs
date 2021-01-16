using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCrimpGunTrigger : MonoBehaviour
{
	public OVRGrabbable OVRobj;
	public GameObject ToggleObj1;
	public GameObject ToggleObj2;
	public float StartAngle1;
	public float StartAngle2;
	public float TriggerAngle1;
	public float TriggerAngle2;
	
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
			ToggleObj1.transform.localEulerAngles = new Vector3(0f, 0f, TriggerAngle1);
			ToggleObj2.transform.localEulerAngles = new Vector3(0f, -180f, TriggerAngle2);
			crimpSensor1.SetCrimpTriggerFlag();
			crimpSensor2.SetCrimpTriggerFlag();
			crimpSensor3.SetCrimpTriggerFlag();
			crimpSensor4.SetCrimpTriggerFlag();
			crimpSensor5.SetCrimpTriggerFlag();
			crimpSensor6.SetCrimpTriggerFlag();
			}else{
				ToggleObj1.transform.localEulerAngles = new Vector3(0f, 0f, StartAngle1);
				ToggleObj2.transform.localEulerAngles = new Vector3(0f, -180f, StartAngle2);
			}
		}
    }
}
