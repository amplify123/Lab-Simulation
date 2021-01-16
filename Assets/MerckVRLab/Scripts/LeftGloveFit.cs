using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGloveFit : MonoBehaviour
{
    public Transform LookObj;
	public Transform FocusObj;
	public GameObject SocketObj;
	public GameObject LimbObj;
	public GameObject HandObj;
	public Transform SensorObj;
	
	private float dist;
	private bool GloveFit;
	
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "LeftHand"){
			//var limbRenderer = LimbObj.GetComponent<Renderer>();
			var handRenderer = HandObj.GetComponent<Renderer>();
			Color gloveColor = new Color(0.8980392f, 0.8588235f, 0.6666667f);
			//limbRenderer.material.SetColor("_Color", Color.yellow);
			handRenderer.material.SetColor("_Color", gloveColor);
			SocketObj.SetActive(true);
			GloveFit = true;
		}
	}
	
	private void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "LeftHand"){
			SocketObj.SetActive(false);
			GloveFit = false;
			var handRenderer = HandObj.GetComponent<Renderer>();
			handRenderer.material.SetColor("_Color", Color.white);
		}
	}
	
	// Start is called before the first frame update
    void Start()
    {
        SocketObj.SetActive(false);
		GloveFit = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (GloveFit){
			dist = Vector3.Distance(LookObj.transform.position, FocusObj.position);
			SocketObj.transform.localScale = new Vector3(1f, 1f, dist);
			LookObj.transform.LookAt(FocusObj);
		}
    }
}
