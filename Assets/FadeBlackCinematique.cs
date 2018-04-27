using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBlackCinematique : MonoBehaviour {

	public Image Black;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Color c = Black.color;
		c.a -= (Time.deltaTime * 2f);
		Black.color = c;
	}
}
