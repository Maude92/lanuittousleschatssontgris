using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaccoonAnimation : MonoBehaviour {
	GameObject Raton;
	public Animation anim;
	bool isiddle = true;
	NavMeshAgent navAgent;

	//AnimationClip[] animclip;
	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animation> ();
		//anim ["Armature.001|run(1)"].speed = 10f;

		//animclip = GetComponent<AnimationClip[]> ();
	}
	
	// Update is called once per frame
	void Update () {
//		print (isiddle);
//		if(Input.GetKeyDown(KeyCode.Y)){
//			isiddle = !isiddle;
//		}
//		if (isiddle == true) {
//			anim.Play("Armature.001|idle_2");
//		} else {
//			anim.Play("Armature.001|run_2");
//		}

		if(Input.GetKeyDown(KeyCode.Y)){
			isiddle = !isiddle;
		}
		if (isiddle == true) {
			anim.Play("Armature.001|run");
		} else {
			anim.Play("Armature.001|run(1)");
		}
	}
}
