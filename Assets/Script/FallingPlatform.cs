using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {
	private Rigidbody rb;
	private Animator anim;

	public float fallDelay = 2f;


	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		anim.enabled = false;
		rb = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.CompareTag("Player")) {
			anim.enabled = true;
			Invoke ("Fall", fallDelay);
			//audioManager.PlaySound ("Falling");
		}
		if(col.gameObject.CompareTag("Ground")){
			Destroy (gameObject);

		}
	}

	void Fall() {
		rb.isKinematic = false;
		anim.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
