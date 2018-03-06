using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptFadeChilds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter() {
		print(transform.GetChildCount());
		for (int childIndex = 0; childIndex < transform.GetChildCount(); childIndex++) {
			transform.GetChild (childIndex).GetComponent<MeshRenderer> ().material.color = new Color (0, 0, 0, 0);
		}
	}

//	IEnumerator Disparait() {
//		for (int childIndex = 0; childIndex < transform.GetChildCount(); childIndex++) {
//			transform.GetChild (childIndex).GetComponent<MeshRenderer> ().material.color = new Color (0, 0, 0, 0);
//		}
//	}
}
