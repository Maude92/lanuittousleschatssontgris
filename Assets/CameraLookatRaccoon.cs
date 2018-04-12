using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookatRaccoon : MonoBehaviour {
	public Transform raccoon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (raccoon);
		
	}
}
