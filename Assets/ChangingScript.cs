using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingScript : MonoBehaviour {
	public GameObject Mist;
	public GameObject camera;
	public GameObject ReferencePoint;
	public GameObject EmptyMist;

	// Use this for initialization
	void Start () {
		Mist.GetComponent<Xbox_Controls_Balancing>().enabled = false;
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Balancing") {
			transform.parent = col.transform;
			Mist.transform.forward = ReferencePoint.transform.forward;
			Mist.transform.position =  new Vector3 (ReferencePoint.transform.position.x, Mist.transform.position.y,Mist.transform.position.z );
			//col.GetComponent<TorqueOnTube> ().enabled = true;
			Mist.GetComponent<Xbox_Controls_Balancing>().enabled = true;
			Mist.GetComponent<Xbox_Controls>().enabled = false;
		}
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "Balancing") {
			Mist.GetComponent<Xbox_Controls_Balancing>().enabled = false;
			Mist.GetComponent<Xbox_Controls>().enabled = true;
			transform.parent = EmptyMist.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
