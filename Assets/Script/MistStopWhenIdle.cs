using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistStopWhenIdle : MonoBehaviour {

	public GameObject mistObj;

	Animator anim;

	Xbox_Controls xboxcontrolspc;

	// Use this for initialization
	void Start () {
		anim = mistObj.GetComponent <Animator> ();
		xboxcontrolspc = GetComponent <Xbox_Controls> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Speed2", Mathf.Abs (Input.GetAxis ("Horizontal")));
		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Vertical")));

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("AtoB")) {
			xboxcontrolspc.enabled = false;
		}

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("A_idle")) {
			xboxcontrolspc.enabled = true;
		}
	}
}
