using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FermeLaPorte : MonoBehaviour {

	Animator animPorte;

	public GameObject porteMaison;

	// Use this for initialization
	void Start () {
		animPorte = porteMaison.GetComponent <Animator> ();
		animPorte.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			print ("Faut j'ajoute un bruit de porte qui claque!");
			animPorte.enabled = true;
		}
	}
}
