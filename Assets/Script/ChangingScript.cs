using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingScript : MonoBehaviour {
	public GameObject Mist;
	public GameObject camera;
	public GameObject ReferencePoint;
	public GameObject EmptyMist;

	//CubeGrounded cubegrounded;

	// Use this for initialization
	void Start () {
		//cubegrounded = GetComponent <CubeGrounded> ();
		Mist.GetComponent<Xbox_Controls_Balancing>().enabled = false;
		camera.GetComponent<ThirdPersonOrbitCamBalancing> ().enabled = false;
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Balancing") {
			//transform.parent = col.transform;
			Mist.transform.forward = ReferencePoint.transform.forward;
			Mist.transform.position =  new Vector3 (ReferencePoint.transform.position.x, Mist.transform.position.y,Mist.transform.position.z );
			//col.GetComponent<TorqueOnTube> ().enabled = true;
			Mist.GetComponent<Xbox_Controls_Balancing>().enabled = true;
			Mist.GetComponent<Xbox_Controls>().enabled = false;
			Mist.GetComponent<MistStopWhenIdle>().enabled = false;
			camera.GetComponent<ThirdPersonOrbitCamBalancing> ().enabled = true;
			camera.GetComponent<ThirdPersonOrbitCamBasic> ().enabled = false;
		}
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "Balancing") {
			Mist.GetComponent<Xbox_Controls_Balancing>().enabled = false;
			Mist.GetComponent<Xbox_Controls>().enabled = true;
			Mist.GetComponent<MistStopWhenIdle>().enabled = true;
			camera.GetComponent<ThirdPersonOrbitCamBalancing> ().enabled = false;
			camera.GetComponent<ThirdPersonOrbitCamBasic> ().enabled = true;
			//transform.parent = EmptyMist.transform;
			//transform.parent = EmptyMist.transform;
		}
	}
	void OnCollisionEnter (Collision other){
		if (other.gameObject.CompareTag("PlatformeMouvante")) {
			transform.parent = other.transform;
		}
		if (other.gameObject.CompareTag("Balancing")) {
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit (Collision other){
		if (other.gameObject.CompareTag("PlatformeMouvante")) {
			transform.parent = EmptyMist.transform;
		}
		if (other.gameObject.CompareTag("Balancing")) {
			transform.parent = EmptyMist.transform;
		}
	}

//	void OnCollisionEnter(Collider col){
//		if (col.tag == "Balancing") {
//			Mist.GetComponent<Xbox_Controls_Balancing>().enabled = false;
//			Mist.GetComponent<Xbox_Controls>().enabled = true;
//			transform.parent = EmptyMist.transform;
//		}
//	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
