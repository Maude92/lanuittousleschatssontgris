using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Tastyv3 : MonoBehaviour {
	public GameObject mistObj;

	public Canvas ButtonY;
	public Canvas UIRaton;

	public float timeUI = -1f;

	Animator anim;

	//public GameObject thisfood;
	public GameObject lessfood1;
	public GameObject lessfood2;
	public GameObject lessfood3;
	public GameObject lessfood4;
	public GameObject lessfood5;
	public GameObject lessfood6;

	public GameObject raccoon;
	public GameObject block;

	// Use this for initialization
	void Start () {
		block.GetComponent<NavMeshAgent> ().enabled = false;
		anim = mistObj.GetComponent <Animator> ();
		raccoon.SetActive (false);
		UIRaton.enabled = false;

	}

	void OnTriggerStay (Collider other){

		ButtonY.enabled = true;

		//Faire attention ici qqchose à modifier quand on va le mettre sur le MSI
		if (other.gameObject.tag == "Player" && (Input.GetButtonDown ("360_YButton") || Input.GetButtonDown ("XbOne_YButton")) && anim.GetCurrentAnimatorStateInfo(0).IsName ("A_idle")){//  && Ieat == false) {
			//Ieat = true;
			print ("Je peux manger");
			anim.SetBool ("Miam", true);
			//HealthBar.GetComponent<HealthBar>().LifeGain(NbPtsVieRedonner);
			lessfood1.SetActive (false);
			lessfood2.SetActive (false);
			lessfood3.SetActive (false);
			lessfood4.SetActive (false);
			lessfood5.SetActive (false);
			lessfood6.SetActive (false);
			block.GetComponent<NavMeshAgent> ().enabled = true;
			//block.SetActive (false);
			raccoon.SetActive (true);
			timeUI = 5f;
			//StartCoroutine (EatThis ());


			//HBcode.LifeGain (10);
			//anim.SetBool ("Miam", false);

		}
	}

	void OnTriggerExit (Collider other){
		ButtonY.enabled = false;

	}
	// Update is called once per frame
	void Update () {
		if (timeUI >= 0) {
			UIRaton.enabled = true;
		} else {
			UIRaton.enabled = false;
		}
		timeUI -= Time.deltaTime;
	}
}
