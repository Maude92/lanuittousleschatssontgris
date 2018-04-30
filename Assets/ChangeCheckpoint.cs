using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCheckpoint : MonoBehaviour {
	public GameObject checkpoint;
	public GameObject referencePoint;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			checkpoint.transform.position = referencePoint.transform.position;
			checkpoint.transform.rotation = referencePoint.transform.rotation;

		}

	}
}
