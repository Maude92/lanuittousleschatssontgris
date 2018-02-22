using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatingScript : MonoBehaviour {
	public GameObject Tube;
	Vector3 newRot ;

	public int youjumped = 0;


	// Use this for initialization
	void Start () {
		
		Tube.GetComponent<TorqueOnTube>().enabled = false;
		newRot = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			Tube.GetComponent<TorqueOnTube>().enabled = true;

		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Player") {
			Tube.GetComponent<TorqueOnTube>().enabled = false;
			transform.rotation = Quaternion.Euler (newRot);

		}
	}
}
