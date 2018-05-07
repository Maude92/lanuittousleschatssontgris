using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeufVies : MonoBehaviour {

	HealthBar healthbarscript;

	public GameObject uiVieObj;

	public Image Circle;


	// Use this for initialization
	void Start () {
		healthbarscript = uiVieObj.GetComponent<HealthBar> ();

		healthbarscript.NbVieRestant = 9;
		Circle.fillAmount = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
