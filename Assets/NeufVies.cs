using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeufVies : MonoBehaviour {

	HealthBar healthbarscript;

	public GameObject uiVieObj;


	// Use this for initialization
	void Start () {
		healthbarscript = uiVieObj.GetComponent<HealthBar> ();

		healthbarscript.NbVieRestant = 9;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
