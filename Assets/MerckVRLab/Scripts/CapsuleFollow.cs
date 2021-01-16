using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleFollow : MonoBehaviour
{
	public GameObject capsuleColliderObj;
	public GameObject HeadObj;
	private Vector3 TargetPos;
	
	bool FollowToggle;
	public bool FootSensor;
	
	// Start is called before the first frame update
    void Start()
    {
        FollowToggle = true;
    }

	public void SetFollowToggle(bool ft){
		FollowToggle = ft;
	}
	
    // Update is called once per frame
    void FixedUpdate()
    {
		if (FootSensor){
			transform.position = new Vector3(HeadObj.transform.position.x, 0.2f, HeadObj.transform.position.z);
		}else{
			if (FollowToggle){
				float step = 2f * Time.deltaTime;
				TargetPos = new Vector3(HeadObj.transform.position.x, 0.2f, HeadObj.transform.position.z);
				transform.position = Vector3.MoveTowards(transform.position, TargetPos, step);
			}	
		}
    }
}
