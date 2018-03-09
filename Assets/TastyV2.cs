using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TastyV2 : MonoBehaviour {

	public GameObject mistObj;
	public Transform HealthBar;

	Xbox_Controls xboxcontrolspc;
	Xbox_Controls_MAC xboxcontrolMac;

	//HealthBar HBcode;

	Animator anim;
	public float NbPtsVieRedonner = 5;

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
		xboxcontrolspc = GetComponent <Xbox_Controls> ();
		xboxcontrolMac = GetComponent <Xbox_Controls_MAC> ();
		//HBcode = GetComponent <HealthBar> ();
	}

	// Update is called once per frame
	void Update () {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("A_eat")) {
			print ("Je mange");
			xboxcontrolspc.enabled = false;
			xboxcontrolMac.enabled = false;
		}
	}

	void OnTriggerStay (Collider other){
		//Faire attention ici qqchose à modifier quand on va le mettre sur le MSI
		if (other.gameObject.tag == "Player" && (Input.GetButtonDown ("360_YButton") || Input.GetButtonDown ("XbOne_YButton")) && anim.GetCurrentAnimatorStateInfo (0).IsName ("A_idle")) {
			print ("Je peux manger");
			anim.SetBool ("Miam", true);
			HealthBar.GetComponent<HealthBar>().LifeGain(NbPtsVieRedonner);
			StartCoroutine (EatThis ());


			//HBcode.LifeGain (10);
			//anim.SetBool ("Miam", false);

		}
	}

	IEnumerator EatThis (){
		yield return new WaitForSeconds (0.7f);
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
	}
		
}
