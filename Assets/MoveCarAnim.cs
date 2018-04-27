using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarAnim : MonoBehaviour {

	Animator animvoiture;
	Animator animvoiture2;

	public GameObject voitureQuiBouge;
	public GameObject vusQuiBouge;

	// Use this for initialization
	void Start () {
		animvoiture = voitureQuiBouge.GetComponent<Animator> ();
		animvoiture2 = vusQuiBouge.GetComponent<Animator> ();
		animvoiture.enabled = false;
		animvoiture2.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			animvoiture.enabled = true;
			animvoiture2.enabled = true;
		}
	}
}
