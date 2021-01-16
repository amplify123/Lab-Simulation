using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveFit : MonoBehaviour
{
    public Transform LeftLookObj;
	public Transform LeftFocusObj;
	public GameObject LeftSocketObj;
	public GameObject LeftLimbObj;
	public GameObject LeftHandObj;
	
	public Transform RightLookObj;
	public Transform RightFocusObj;
	public GameObject RightSocketObj;
	public GameObject RightLimbObj;
	public GameObject RightHandObj;
	
	public GloveEntryPoint EntryPoint1;
	public GloveEntryPoint EntryPoint2;
	public GloveEntryPoint EntryPoint3;
	public GloveEntryPoint EntryPoint4;
	public GloveEntryPoint EntryPoint5;
	public GloveEntryPoint EntryPoint6;
	public GloveEntryPoint EntryPoint7;
	
	public Transform SensorObj;
	
	private float LeftDist;
	private float RightDist;
	
	private bool LeftGloveFit;
	private bool RightGloveFit;
	
	private string currentLeftGloveName;
	private string currentRightGloveName;
	
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "LeftHand"){
			float LeftGlovePosX = GetGloveLeftPosX();
			if (LeftGlovePosX != -500f && CheckStaticHandStatus(LeftGlovePosX)){
				LeftLookObj.position = new Vector3(LeftGlovePosX, LeftLookObj.position.y, LeftLookObj.position.z );
				//var limbRenderer = LimbObj.GetComponent<Renderer>();
				var LeftHandRenderer = LeftHandObj.GetComponent<Renderer>();
				Color LeftGloveColor = new Color(0.8980392f, 0.8588235f, 0.6666667f);
				//limbRenderer.material.SetColor("_Color", Color.yellow);
				LeftHandRenderer.material.SetColor("_Color", LeftGloveColor);
				LeftSocketObj.SetActive(true);
				TurnOffStaticHand(LeftGlovePosX);
				LeftGloveFit = true;
			}else{
				LeftHandObj.SetActive(false);
			}
		}
		//
		if (other.gameObject.tag == "RightHand"){
			float RightGlovePosX = GetGloveRightPosX();
			if (RightGlovePosX != -500f && CheckStaticHandStatus(RightGlovePosX)){
				RightLookObj.position = new Vector3(RightGlovePosX, RightLookObj.position.y, RightLookObj.position.z);
				//var limbRenderer = LimbObj.GetComponent<Renderer>();
				var RightHandRenderer = RightHandObj.GetComponent<Renderer>();
				Color RightGloveColor = new Color(0.8980392f, 0.8588235f, 0.6666667f);
				//limbRenderer.material.SetColor("_Color", Color.yellow);
				RightHandRenderer.material.SetColor("_Color", RightGloveColor);
				RightSocketObj.SetActive(true);
				TurnOffStaticHand(RightGlovePosX);
				RightGloveFit = true;
			}else{
				RightHandObj.SetActive(false);
			}
		}
	}
	
	private bool CheckStaticHandStatus(float Xpos){
		bool staticHandStatus = false;
		if (Xpos == EntryPoint1.GetRightEntryPosX()){
			if (EntryPoint1.StaticHand.activeSelf == true){
				staticHandStatus = true;
			}
		}
		if (Xpos == EntryPoint2.GetRightEntryPosX()){
			if (EntryPoint2.StaticHand.activeSelf == true){
				staticHandStatus = true;
			}
		}
		if (Xpos == EntryPoint3.GetRightEntryPosX()){
			if (EntryPoint3.StaticHand.activeSelf == true){
				staticHandStatus = true;
			}
		}
		if (Xpos == EntryPoint4.GetRightEntryPosX()){
			if (EntryPoint4.StaticHand.activeSelf == true){
				staticHandStatus = true;
			}
		}
		if (Xpos == EntryPoint5.GetRightEntryPosX()){
			if (EntryPoint5.StaticHand.activeSelf == true){
				staticHandStatus = true;
			}
		}
		if (Xpos == EntryPoint6.GetRightEntryPosX()){
			if (EntryPoint6.StaticHand.activeSelf == true){
				staticHandStatus = true;
			}
		}
		if (Xpos == EntryPoint7.GetRightEntryPosX()){
			if (EntryPoint7.StaticHand.activeSelf == true){
				staticHandStatus = true;
			}
		}
		return staticHandStatus;
	}
	
	private float GetGloveLeftPosX(){
		float glovePosX = -500f;
		if (EntryPoint1.LeftHandEnterBool){
			glovePosX = EntryPoint1.GetLeftEntryPosX();
		}
		if (EntryPoint2.LeftHandEnterBool){
			glovePosX = EntryPoint2.GetLeftEntryPosX();
		}
		if (EntryPoint3.LeftHandEnterBool){
			glovePosX = EntryPoint3.GetLeftEntryPosX();
		}
		if (EntryPoint4.LeftHandEnterBool){
			glovePosX = EntryPoint4.GetLeftEntryPosX();
		}
		if (EntryPoint5.LeftHandEnterBool){
			glovePosX = EntryPoint5.GetLeftEntryPosX();
		}
		if (EntryPoint6.LeftHandEnterBool){
			glovePosX = EntryPoint6.GetLeftEntryPosX();
		}
		if (EntryPoint7.LeftHandEnterBool){
			glovePosX = EntryPoint7.GetLeftEntryPosX();
		}
		return glovePosX;
	}
	
	private float GetGloveRightPosX(){
		float glovePosX = -500f;
		if (EntryPoint1.RightHandEnterBool){
			glovePosX = EntryPoint1.GetRightEntryPosX();
		}
		if (EntryPoint2.RightHandEnterBool){
			glovePosX = EntryPoint2.GetRightEntryPosX();
		}
		if (EntryPoint3.RightHandEnterBool){
			glovePosX = EntryPoint3.GetRightEntryPosX();
		}
		if (EntryPoint4.RightHandEnterBool){
			glovePosX = EntryPoint4.GetRightEntryPosX();
		}
		if (EntryPoint5.RightHandEnterBool){
			glovePosX = EntryPoint5.GetRightEntryPosX();
		}
		if (EntryPoint6.RightHandEnterBool){
			glovePosX = EntryPoint6.GetRightEntryPosX();
		}
		if (EntryPoint7.RightHandEnterBool){
			glovePosX = EntryPoint7.GetRightEntryPosX();
		}
		return glovePosX;
	}
	
	private void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "LeftHand"){
			LeftSocketObj.SetActive(false);
			LeftGloveFit = false;
			var LeftHandRenderer = LeftHandObj.GetComponent<Renderer>();
			LeftHandRenderer.material.SetColor("_Color", Color.white);
			//
			ClearLeftEntryPoints();
			LeftHandObj.SetActive(true);
			TurnOnStaticHand(LeftLookObj.position.x);
		}
		//
		if (other.gameObject.tag == "RightHand"){
			RightSocketObj.SetActive(false);
			RightGloveFit = false;
			var RightHandRenderer = RightHandObj.GetComponent<Renderer>();
			RightHandRenderer.material.SetColor("_Color", Color.white);
			//
			ClearRightEntryPoints();
			RightHandObj.SetActive(true);
			TurnOnStaticHand(RightLookObj.position.x);
		}
	}
	
	public void TurnOffStaticHand(float Xpos){
		EntryPoint1.TurnOffStaticHand(Xpos);
		EntryPoint2.TurnOffStaticHand(Xpos);
		EntryPoint3.TurnOffStaticHand(Xpos);
		EntryPoint4.TurnOffStaticHand(Xpos);
		EntryPoint5.TurnOffStaticHand(Xpos);
		EntryPoint6.TurnOffStaticHand(Xpos);
		EntryPoint7.TurnOffStaticHand(Xpos);
	}
	
	public void TurnOnStaticHand(float Xpos){
		EntryPoint1.TurnOnStaticHand(Xpos);
		EntryPoint2.TurnOnStaticHand(Xpos);
		EntryPoint3.TurnOnStaticHand(Xpos);
		EntryPoint4.TurnOnStaticHand(Xpos);
		EntryPoint5.TurnOnStaticHand(Xpos);
		EntryPoint6.TurnOnStaticHand(Xpos);
		EntryPoint7.TurnOnStaticHand(Xpos);
	}
	
	public void ClearLeftEntryPoints(){
		EntryPoint1.ClearLeftHandBool();
		EntryPoint2.ClearLeftHandBool();
		EntryPoint3.ClearLeftHandBool();
		EntryPoint4.ClearLeftHandBool();
		EntryPoint5.ClearLeftHandBool();
		EntryPoint6.ClearLeftHandBool();
		EntryPoint7.ClearLeftHandBool();
	}

	public void ClearRightEntryPoints(){
		EntryPoint1.ClearRightHandBool();
		EntryPoint2.ClearRightHandBool();
		EntryPoint3.ClearRightHandBool();
		EntryPoint4.ClearRightHandBool();
		EntryPoint5.ClearRightHandBool();
		EntryPoint6.ClearRightHandBool();
		EntryPoint7.ClearRightHandBool();
	}
	
	// Start is called before the first frame update
    void Start()
    {
        LeftSocketObj.SetActive(false);
		RightSocketObj.SetActive(false);
		LeftGloveFit = false;
		RightGloveFit = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (LeftGloveFit){
			LeftDist = Vector3.Distance(LeftLookObj.transform.position, LeftFocusObj.position);
			LeftSocketObj.transform.localScale = new Vector3(1f, 1f, LeftDist);
			LeftLookObj.transform.LookAt(LeftFocusObj);
		}
		if (RightGloveFit){
			RightDist = Vector3.Distance(RightLookObj.transform.position, RightFocusObj.position);
			RightSocketObj.transform.localScale = new Vector3(1f, 1f, RightDist);
			RightLookObj.transform.LookAt(RightFocusObj);
		}
    }
}
