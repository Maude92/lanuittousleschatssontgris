using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueOnTube : MonoBehaviour {
	public float amount = 0.4f;
	public float direction = 1f;
	public float tempschange = 1.5f;
	public float MinTime= 3f;
	public float MaxTime= 5f;
	public float smooth = 6;

	public GameObject target;

	public GameObject Mist;
	public Rigidbody rb;
	//Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rb = Mist.GetComponent<Rigidbody> ();

		//rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		tempschange -= Time.deltaTime;
		if (tempschange <= 0) {
			direction *= -1;
			//tempschange= 4f;
			tempschange= Random.Range(MinTime,MaxTime);
		}
		//print (transform.rotation.eulerAngles.x);

		if(transform.rotation.eulerAngles.x <= 72){
			print ("Cet angle est trop grand");
			Mist.transform.parent = null;
			rb.AddForce (-transform.forward* 30);
//
		}
		transform.Rotate(0,(amount * direction),0);
		transform.rotation = Quaternion.Slerp (transform.rotation, target.transform.rotation, Time.deltaTime *smooth);
//		float h = amount * Time.deltaTime;
//
//		rigidbody.AddTorque (transform.up * h);
		if (Input.GetButtonDown ("360_LeftBumper")){
			target.transform.Rotate(0,2,0);
			//transform.Rotate = Quaternion.Slerp (transform.Rotate, target, Time.deltaTime *2f);
			//transform.Rotate(0,4,0);
			//print ("Je pèse sur: left bumper!");
			//rb.AddForce (transform.right * -explosion);
		}

		// Right bumper (... 5)
		if (Input.GetButtonDown ("360_RightBumper")){
			target.transform.Rotate(0,-2,0);
			//transform.Rotate = Quaternion.Slerp (transform.Rotate, target, Time.deltaTime *2f);
			//transform.Rotate(0,-4,0);
			//print ("Je pèse sur: right bumper!");
			//rb.AddForce (transform.right * explosion);
		}
	}


}
