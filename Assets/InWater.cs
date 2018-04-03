using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWater : MonoBehaviour {

	private AudioManager audioManager;

	// Use this for initialization
	void Start () {
		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		
	}
}
