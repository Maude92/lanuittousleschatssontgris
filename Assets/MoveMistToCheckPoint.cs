using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMistToCheckPoint : MonoBehaviour {
	public GameObject CheckPoint;

	public GameObject Prefab;
	public Transform InstatiatePlatform;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			other.transform.position = CheckPoint.transform.position;
			Instantiate (Prefab, InstatiatePlatform.transform.position, InstatiatePlatform.transform.rotation);
			//transform.parent = other.transform;
		}
	}


}
