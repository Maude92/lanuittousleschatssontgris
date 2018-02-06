using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
	public GameObject Player;
	public float rotateSpeed = 5;//added
	Vector3 offset;

	JumpScript jump;

	// Use this for initialization
	void Start () {
		jump = Player.GetComponent<JumpScript> ();
		offset = Player.transform.position - transform.position;

	}

	void Update(){
		//transform.RotateAround(Player.transform.position,Vector3.up, 1 );
		//print(jump.isgrounded1);
	}


	void LateUpdate () {
		//print (jump.isfalling);

		if(Input.GetAxis("Vertical")>0){//|| jump.isgrounded == false){
		//float horizontal = Input.GetAxis ("RightStick") * rotateSpeed;//
			Player.transform.Rotate (0, Input.GetAxis ("RightStick"), 0);//

			float desiredAngle = Player.transform.eulerAngles.y;
			Quaternion rotation = Quaternion.Euler (0, desiredAngle, 0);


			transform.position = Player.transform.position - (rotation * offset);
			transform.LookAt (Player.transform);

		} else{
			float horizontal2 = Input.GetAxis ("RightStick") * rotateSpeed;
			transform.RotateAround(Player.transform.position,Vector3.up, horizontal2 );
		}


	}
}
