using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistStopWhenIdle : MonoBehaviour {

	public GameObject mistObj;

	Animator anim;

	Xbox_Controls xboxcontrolspc;

	//Rigidbody rb;

	//public int cheat;

	//public float stopPlease = 0.5f;

	// Use this for initialization
	void Start () {
		anim = mistObj.GetComponent <Animator> ();
		xboxcontrolspc = GetComponent <Xbox_Controls> ();
		//rb = GetComponent <Rigidbody> ();
		//cheat = 0;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Speed2", Mathf.Abs (Input.GetAxis ("Horizontal")));
		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Vertical")));

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("AtoB") || anim.GetCurrentAnimatorStateInfo (0).IsName ("F_sleep") || anim.GetCurrentAnimatorStateInfo (0).IsName ("A_eat") || anim.GetCurrentAnimatorStateInfo (0).IsName ("A_pole_start")) { 		// || anim.GetCurrentAnimatorStateInfo (0).IsName ("A_jump_end")
			xboxcontrolspc.enabled = false;
//			Rigidbody rb;
//			GameObject personnage;
//			Debug.Log ("Enter State Jump Down animation");
//			personnage = GameObject.FindGameObjectWithTag ("Player");
//			rb = personnage.GetComponent<Rigidbody> ();
//			Debug.Log (rb + "111");
//			rb.velocity = new Vector3 (0, rb.velocity.y, 0);
		}

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("A_idle") || anim.GetCurrentAnimatorStateInfo (0).IsName ("A_walk") || anim.GetCurrentAnimatorStateInfo (0).IsName ("A_walk 2")) {			// || anim.GetCurrentAnimatorStateInfo (0).IsName ("A_walk") || anim.GetCurrentAnimatorStateInfo (0).IsName ("A_walk 2")
			xboxcontrolspc.enabled = true;
			//cheat = 0;
		}
	}

//		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("A_jump_end")){
//			cheat++;
//			if (cheat == 1) {
//				StartCoroutine (StopMovingPlease ());
//			}
//		}
//	}
//
//	IEnumerator StopMovingPlease(){
//			print ("Je commence une coroutine");
//			rb.velocity = new Vector3 (0, rb.velocity.y, 0);
//			xboxcontrolspc.enabled = false;
//			yield return new WaitForSeconds (stopPlease);
//			xboxcontrolspc.enabled = true;
//			//cheat = 0;
//	}
}
