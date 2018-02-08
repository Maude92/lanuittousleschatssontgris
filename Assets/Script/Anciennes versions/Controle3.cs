using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle3 : MonoBehaviour {
	Rigidbody rb;
	Animator anim;
	int hp = 0;
	public GameObject position;
	public GameObject camera;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		if (hp>= 1){
			transform.position = position.transform.position;
			hp = 0;
		}
		if (transform.position.y < -100) { 
			transform.position = position.transform.position;

		}
//		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.S)) {
//			
//		}
		if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.S)){
//			while (transform.forward != camera.transform.forward) {
//				transform.Rotate (0, 1, 0);
//
//			}
			transform.forward = camera.transform.forward;
			
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.position += camera.transform.forward * Time.deltaTime * 100;
			transform.Rotate (0 , 2 * Input.GetAxis("Horizontal"), 0 );
//			transform.position += transform.forward * Time.deltaTime * 100;
		} 
		else if  (Input.GetKey (KeyCode.S)) {
			transform.position -= camera.transform.forward * Time.deltaTime * 100;
			transform.Rotate (0 , 2 * Input.GetAxis("Horizontal"), 0 );
		} 

		if (Input.GetKeyDown (KeyCode.W) ||Input.GetKeyDown (KeyCode.S) ) {
			anim.SetTrigger ("walk");
		}
		if (Input.GetKeyUp (KeyCode.W)||Input.GetKeyUp (KeyCode.S)) {
			anim.SetTrigger ("stop");
		} 
		if (Input.GetMouseButtonDown (0)) {
			anim.SetTrigger ("Hit");
		} 
		if (Input.GetMouseButtonUp (0)) {
			anim.SetTrigger ("hittoiddle");
		} 




	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Guardian") {

			hp++;
			print (hp);
			//Destroy (col.gameObject);
			//animation.SetTrigger ("damage");
		}
	}
}
