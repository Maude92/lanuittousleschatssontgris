using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistMiawForMenu : MonoBehaviour {

	public GameObject mistObj;
	public int miawCount;

	Animator anim;

	private AudioManager audioManager;


	// Use this for initialization
	void Start () {
		miawCount = 0;

		anim = mistObj.GetComponent <Animator> ();

		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");}
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("B_cry")) {
			miawCount++;
		}

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("B_idle_aftermiaw")) {
			miawCount = 0;
		}

		if (miawCount == 1) {
			audioManager.PlaySound ("MiawIdle");
		}
	}
}
