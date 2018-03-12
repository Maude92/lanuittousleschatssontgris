﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueOnTube : MonoBehaviour {
	public GameObject UI;
	UiBoussolleBalancing uiScript;
	public float amount = 0.4f;
	public float direction = 1f;
	public float tempschange = 1.5f;
	public float MinTime= 3f;
	public float MaxTime= 5f;
	public float smooth = 6;
	public float changementAmount = 1;

	public int youjumped = 0;
	public float biggerAngle;
	public int directionOfRotation = 1;

	public GameObject target;

	public GameObject Mist;
	Rigidbody rb;

	public GameObject cylindre;
	ActivatingScript activating;


	//Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		uiScript = UI.GetComponent<UiBoussolleBalancing> ();
		activating = cylindre.GetComponent<ActivatingScript> ();
		rb = Mist.GetComponent<Rigidbody> ();

		//rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		tempschange -= Time.deltaTime;
//		if (activating.youjumped >= 1) {
//			direction = 3f;
//		}

		if (tempschange <= 0) {
			direction *= -1;
			//tempschange= 4f;
			tempschange= Random.Range(MinTime,MaxTime);
		}
		//print (90f - transform.rotation.eulerAngles.x);
		biggerAngle = 5.3f *(90f - transform.rotation.eulerAngles.x);
		//print ( biggerAngle);


		if(transform.rotation.eulerAngles.x <= 72){
			Mist.GetComponent<Xbox_Controls_Balancing>().enabled = false;
			print ("Cet angle est trop grand");
			Mist.transform.parent = null;
			//rb.AddForce (-transform.forward* 60);
			rb.AddForce (uiScript.rotation * -1 *transform.right* 200);

//
		}
		target.transform.Rotate(0,(amount * direction),0);
		transform.rotation = Quaternion.Slerp (transform.rotation, target.transform.rotation, Time.deltaTime *smooth);
//		float h = amount * Time.deltaTime;
//
//		rigidbody.AddTorque (transform.up * h);
//		if (Input.GetButtonDown ("360_LeftBumper")){
//			target.transform.Rotate(0,2,0);
//			//transform.Rotate = Quaternion.Slerp (transform.Rotate, target, Time.deltaTime *2f);
//			//transform.Rotate(0,4,0);
//			//print ("Je pèse sur: left bumper!");
//			//rb.AddForce (transform.right * -explosion);
//		}
//
//
//		// Right bumper (... 5)
//		if (Input.GetButtonDown ("360_RightBumper")){
//			target.transform.Rotate(0,-2,0);
//			//transform.Rotate = Quaternion.Slerp (transform.Rotate, target, Time.deltaTime *2f);
//			//transform.Rotate(0,-4,0);
//			//print ("Je pèse sur: right bumper!");
//			//rb.AddForce (transform.right * explosion);
//		}


//		if (Input.GetButtonDown ("360_AButton")){
//			activating.youjumped++;
//
//		}

		if (Input.GetButton ("360_LeftBumper")){
			target.transform.Rotate(0,(amount * changementAmount),0);

		}

		if (Input.GetButton ("360_RightBumper")){
			target.transform.Rotate(0,(-changementAmount * amount),0);

		}
	}



}
