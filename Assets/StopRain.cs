using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRain : MonoBehaviour {
	public GameObject rain;
	// Use this for initialization
	void Start () {
		rain.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			rain.SetActive (true);
		}
	}
}
