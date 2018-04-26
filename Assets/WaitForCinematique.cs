using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForCinematique : MonoBehaviour {

	public float timeAttente = 21f;

	//Xbox_Controls xboxcontroles;

	Animator anim;
	public GameObject mistObj;

	// Use this for initialization
	void Start () {
		//xboxcontroles = GetComponent<Xbox_Controls> ();	
		anim = mistObj.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		timeAttente -= Time.deltaTime;
		if (timeAttente > 0) {
			anim.SetBool ("CinematiqueOver", false);
			//xboxcontroles.enabled = false;
		} else if (timeAttente <= 0) {
			anim.SetBool ("CinematiqueOver", true);
			//xboxcontroles.enabled = true;
		}

		if (timeAttente < 0) {
			timeAttente = 0;
		}
	}
}
