using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAttempt : MonoBehaviour {
	public Transform from;
	public Transform to;
	public float speed = 0.1f;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Lerp (from.rotation, to.rotation, Time.time * speed);
	}
}
