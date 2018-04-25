using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TastyVersionPC : MonoBehaviour {

	public GameObject mistObj;
	public GameObject playerObj;
	public Transform HealthBar;

	Xbox_Controls xboxcontrolspc;
	//Xbox_Controls_MAC xboxcontrolMac;

	//HealthBar HBcode;

	public Canvas ButtonY;

	Animator anim;
	public float NbPtsVieRedonner = 5;

	public bool Ieat;

	public GameObject thisfood;
	public GameObject food1;
	public GameObject lessfood2;
	public GameObject lessfood3;
	public GameObject lessfood4;
	public GameObject lessfood5;
	public GameObject lessfood6;


	// Use this for initialization
	void Start () {
		anim = mistObj.GetComponent <Animator> ();
		xboxcontrolspc = playerObj.GetComponent <Xbox_Controls> ();
		//xboxcontrolMac = GetComponent <Xbox_Controls_MAC> ();
		//HBcode = GetComponent <HealthBar> ();
		Ieat = false;
		ButtonY.enabled = false;
	}

	// Update is called once per frame
	void Update () {
//		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("A_eat")) {
//			print ("Je mange");
//			xboxcontrolspc.enabled = false;
//			//xboxcontrolMac.enabled = false;
//		}
	}

	void OnTriggerStay (Collider other){

		//ButtonY.enabled = true;

		//Faire attention ici qqchose à modifier quand on va le mettre sur le MSI
		if (other.gameObject.tag == "Player" && (Input.GetButtonDown ("360_YButton")) && Ieat == false) {
			Ieat = true;
			print ("Je peux manger");
			anim.SetBool ("Miam", true);
			StartCoroutine (EatThis ());
			HealthBar.GetComponent<HealthBar>().LifeGain(NbPtsVieRedonner);



			//HBcode.LifeGain (10);
			//anim.SetBool ("Miam", false);

		}
	}

//	void OnTriggerEnter (Collider other){
//		ButtonY.enabled = true;
//
//	}
//
//	void OnTriggerExit (Collider other){
//		ButtonY.enabled = false;
//
//	}
//
	IEnumerator EatThis (){
		yield return new WaitForSeconds (0.7f);
		ButtonY.enabled = false;
		food1.SetActive (false);
		yield return new WaitForSeconds (0.43f);
		lessfood2.SetActive (false);
		yield return new WaitForSeconds (0.43f);
		lessfood3.SetActive (false);
		yield return new WaitForSeconds (0.43f);
		lessfood4.SetActive (false);
		yield return new WaitForSeconds (0.43f);
		lessfood5.SetActive (false);
		yield return new WaitForSeconds (0.43f); 
		lessfood6.SetActive (false);
		thisfood.SetActive (false);
		Ieat = false;
	}

}
