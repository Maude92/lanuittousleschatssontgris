﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GoAndStopCinematique : MonoBehaviour {

	public PlayableDirector playableDirector;

//	void OnTriggerEnter (Collider col){
//		if (col.gameObject.tag == "Player") {
//			playableDirector.Play ();
//		}
//
//	}

	void OnTriggerExit (Collider other){
		playableDirector.Stop ();


	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
