using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMeGrounded : MonoBehaviour {

	CubeGrounded cubegroundedscript;

	public GameObject playerObj;


	// Use this for initialization
	void Start () {
		cubegroundedscript = playerObj.GetComponent <CubeGrounded> ();
	}
	
	void OnTriggerStay (Collider other){
		if (other.gameObject.tag == "Player") {
			cubegroundedscript.isGrounded = true;
		}
	}

}
