using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GratteLePoteau : MonoBehaviour {

	public GameObject mistObj;
	public Canvas ButtonY;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = mistObj.GetComponent <Animator> ();
		ButtonY.enabled = false;
	}


	void OnTriggerStay (Collider other){
		if (other.gameObject.tag == "NezDeChat" && (Input.GetButtonDown ("360_YButton"))) {
			print ("Je gratte un poteau! Much fun!");
			anim.SetBool ("Gratte", true);
			ButtonY.enabled = false;
		}
	}


	void OnTriggerEnter (Collider other){
		ButtonY.enabled = true;
	}


	void OnTriggerExit (Collider other){
		ButtonY.enabled = false;
	}
}
