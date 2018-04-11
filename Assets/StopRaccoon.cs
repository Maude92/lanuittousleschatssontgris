using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StopRaccoon : MonoBehaviour {
	public GameObject Raccoon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay (Collider other){


		//Faire attention ici qqchose à modifier quand on va le mettre sur le MSI
		if (other.gameObject.tag == "Raccoon"){//  && Ieat == false) {
			Raccoon.GetComponent<NavMeshAgent>().enabled = false;

		}
	}
}
