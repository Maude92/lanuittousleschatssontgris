﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatingScript : MonoBehaviour {
	public GameObject Tube;
	public GameObject UI;
	public Canvas Explanation;
	public GameObject TargetAngle;
	Vector3 newRot ;
	Vector3 TargetRot ;
	TorqueOnTube ToT;
	UiBoussolleBalancing UIScript;

	public int youjumped = 0;


	// Use this for initialization
	void Start () {
		ToT = Tube.GetComponent<TorqueOnTube> ();
		UIScript = UI.GetComponent<UiBoussolleBalancing> ();
		UI.SetActive (false);
		Explanation = Explanation.GetComponent<Canvas> ();
		Explanation.enabled = false;
		//UI.enabled = false;
		Tube.GetComponent<TorqueOnTube>().enabled = false;
		newRot = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
		TargetRot =  new Vector3 (TargetAngle.transform.eulerAngles.x, TargetAngle.transform.eulerAngles.y, TargetAngle.transform.eulerAngles.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			UI.SetActive (true);
			Explanation.enabled = true;
			Tube.GetComponent<TorqueOnTube>().enabled = true;
			ToT.tempschange = 1.5f;
			ToT.direction = 1f;

		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Player") {
			transform.rotation = Quaternion.Euler (newRot);
			TargetAngle.transform.rotation = Quaternion.Euler (TargetRot);
			//ToT.directionOfRotation = -1;
			UIScript.rotation = -1;
			Tube.GetComponent<TorqueOnTube>().enabled = false;
			Explanation.enabled = false;
			UI.SetActive (false);


		}
	}
}
