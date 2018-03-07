using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public GameObject emptyMist;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter (Collision other){
		if (other.gameObject.CompareTag("PlatformeMouvante")) {
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit (Collision other){
		if (other.gameObject.CompareTag("PlatformeMouvante")) {
			transform.parent = emptyMist.transform;
		}
	}
}
