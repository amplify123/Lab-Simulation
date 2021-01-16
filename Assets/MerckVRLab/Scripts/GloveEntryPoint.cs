using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveEntryPoint : MonoBehaviour
{
    public bool LeftHandEnterBool;
	public bool RightHandEnterBool;
	
	public string GloveEntryPointName;
	
	public GameObject StaticHand;
	public GameObject EntryCover;
	
	// Start is called before the first frame update
    void Start()
    {
        LeftHandEnterBool = false;
		RightHandEnterBool = false;
		EntryCover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void TurnOnStaticHand(float Xpos){
		if (Xpos == this.transform.position.x){
			StaticHand.SetActive(true);
			EntryCover.SetActive(false);
		}
	}
	
	public void TurnOffStaticHand(float Xpos){
		if (Xpos == this.transform.position.x){
			StaticHand.SetActive(false);
			EntryCover.SetActive(true);
		}
	}
	
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "LeftHand"){
			LeftHandEnterBool = true;
			RightHandEnterBool = false;
		}
		if (other.gameObject.tag == "RightHand"){
			LeftHandEnterBool = false;
			RightHandEnterBool = true;
		}
	}
	
	public void ClearLeftHandBool(){
		LeftHandEnterBool = false;
	}
	
	public void ClearRightHandBool(){
		RightHandEnterBool = false;
	}
	
	public float GetLeftEntryPosX(){
		float entryPosX = this.transform.position.x;
		return entryPosX;
	}
	
	public float GetRightEntryPosX(){
		float entryPosX = this.transform.position.x;
		return entryPosX;
	}
	
}
