using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerMaude : MonoBehaviour {

	public GameObject leempty;
	public GameObject player;

	private float offset;

	// Use this for initialization
	void Start () {
		offset = transform.position.z - leempty.transform.position.z;
	}
	
	// Update is called once per frame
	void Update(){
		
	}

	void LateUpdate () {
		transform.position = leempty.transform.position;
		transform.rotation = player.transform.rotation;
	}
}
