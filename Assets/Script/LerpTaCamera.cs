using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTaCamera : MonoBehaviour {

	public Transform posDepart;
	public Transform posFin;

	// Use this for initialization
	void Start () {
		transform.position = Vector3.Lerp (posDepart.position, posFin.position, 0.5f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
