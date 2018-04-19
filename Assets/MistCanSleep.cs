using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistCanSleep : MonoBehaviour {

	public int countObjetsDisparus;
	public int nombreMagique;

	public bool goToSleep;

	// Use this for initialization
	void Start () {
		countObjetsDisparus = 0;
		goToSleep = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (countObjetsDisparus >= nombreMagique) {
			print ("Je peux aller me coucher, j'ai fait disparaître le bon nombre d'objets. (à implémenter)");
		}
	}

	void OnTriggerStay (Collider other){
		if (other.gameObject.tag == "LitDouillet" && Input.GetButtonDown ("360_YButton")) {
			print ("Zzzzzz.... (cinématique se déclenche quand je pèse sur Y, à implémenter)");
			goToSleep = true;
		}
	}
}
