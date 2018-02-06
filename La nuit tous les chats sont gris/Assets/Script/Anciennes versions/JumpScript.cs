using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour {
	int isfalling = 1;
	int isfallingsound = 1;
	//bool isgrounded = true;
	public int jumpheight =14;
	Animator anim;

	public AudioClip audioJump;
	public AudioClip audioNo;
	AudioSource audio;

	public bool isgrounded = true;
	public int isgrounded1 = 0;


	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && isgrounded == true) {
			//anim.SetTrigger ("jump");
			//rigidbody.velocity.y =  jumpheight;
			GetComponent<Rigidbody>().velocity = Vector3.up * jumpheight;
			isgrounded = false;
			audio.clip = audioJump;
			audio.Play();
			//isfallingsound++;
//			audio.clip = audioJump;
//			audio.Play();
		}
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			isfallingsound++;
//		}
//		if (Input.GetKeyDown (KeyCode.Space) && isfallingsound < 4) {
//			anim.SetTrigger ("jump");
//			//rigidbody.velocity.y =  jumpheight;
//
//			audio.clip = audioJump;
//			audio.Play();
//		}
		if (Input.GetKeyDown (KeyCode.Space) && isgrounded == false) {
			//anim.SetTrigger ("jump");
			//rigidbody.velocity.y =  jumpheight;

			audio.clip = audioNo;
			audio.Play();
		}
//		if (Input.GetKeyUp (KeyCode.Space)) {
//			anim.SetTrigger("jumptoiddle");
//		}
//		if (Input.GetKey (KeyCode.Space) && isfalling <= 3) {
//			anim.SetTrigger ("jump");
//		}


	}

//	void OnCollisionExit (Collision col){
//		if (col.gameObject.tag == "Ground")anim.SetTrigger ("jump");
//	}

	void OnCollisionEnter (Collision col){
//		if (col.gameObject.tag == "Ground") {
//			anim.SetTrigger ("jumptoiddle");
//			if (isfalling >= 3){
//				isfalling = 0;
//			}
//		}

		if (col.gameObject.tag == "Ground") {
			//anim.SetTrigger ("jumptoiddle");

			isgrounded = true;
		}
	}
//	void OnCollisionStay (){
//
//		anim.SetTrigger ("jumptoiddle");
//	}
	}

