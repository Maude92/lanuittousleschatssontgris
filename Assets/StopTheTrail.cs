using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTheTrail : MonoBehaviour {

	public GameObject theBird;

	TrailRenderer trailBird;

	// Use this for initialization
	void Start () {
		trailBird = theBird.GetComponent <TrailRenderer> ();
		trailBird.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			trailBird.enabled = true;
		}
	}
}
