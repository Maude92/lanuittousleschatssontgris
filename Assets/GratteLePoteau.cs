using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GratteLePoteau : MonoBehaviour {

	public GameObject mistObj;
	public GameObject playerObj;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = mistObj.GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
