using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuelleMusiqueJoue : MonoBehaviour {

	public bool changeDeMusique;

	void Start(){
		changeDeMusique = false;
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			changeDeMusique = true;
		}
	}
}
