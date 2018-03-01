using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaccoonAnimation : MonoBehaviour {
	GameObject Raton;
	Animation anim;
	bool isiddle = true;
	//AnimationClip[] animclip;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		//animclip = GetComponent<AnimationClip[]> ();
	}
	
	// Update is called once per frame
	void Update () {
		print (isiddle);
		if(Input.GetKeyDown(KeyCode.Y)){
			isiddle = !isiddle;
		}
		if (isiddle == true) {
			anim.Play("Armature.001|idle_2");
		} else {
			anim.Play("Armature.001|run_2");
		}
	}
}
