﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistCanSleep : MonoBehaviour {

	public int countObjetsDisparus;
	public int nombreMagique;

	public bool goToSleep;

	public Canvas ButtonY;

	// Use this for initialization
	void Start () {
		countObjetsDisparus = 0;
		goToSleep = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (countObjetsDisparus >= nombreMagique) {
			print ("Je peux aller me coucher, j'ai fait disparaître le bon nombre d'objets. (à implémenter)");
			// Faire apparaître nouveau UI objectif
			// Rendre le lit accessible

		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "LitDouillet") {
			ButtonY.enabled = true;
		}
	}

	void OnTriggerStay (Collider other){
		if (other.gameObject.tag == "LitDouillet" && Input.GetButtonDown ("360_YButton") && countObjetsDisparus >= nombreMagique) {
			print ("Zzzzzz.... (cinématique se déclenche quand je pèse sur Y, à implémenter)");
			goToSleep = true;
			ButtonY.enabled = false;
			// Il faut que le UI de Y affiche
			// Déclenche une cinématique
			// Animation de Mist qui s'asseoit, miaule, se couche, s'endort
			// Fade out à la nouvelle scène (même maison, mais fenêtre ouverte)
		}
	}
}
