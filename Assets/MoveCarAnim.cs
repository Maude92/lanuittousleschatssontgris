using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarAnim : MonoBehaviour {

	Animator animvoiture;
	Animator animvoiture2;

	public GameObject voitureQuiBouge;
	public GameObject vusQuiBouge;

	public int cartime;

	private AudioManager audioManager;


	// Use this for initialization
	void Start () {
		animvoiture = voitureQuiBouge.GetComponent<Animator> ();
		animvoiture2 = vusQuiBouge.GetComponent<Animator> ();
		animvoiture.enabled = false;
		animvoiture2.enabled = false;

		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");	}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			animvoiture.enabled = true;
			animvoiture2.enabled = true;
			//StartCoroutine (StartCarSound ());
		}
	}

	IEnumerator StartCarSound(){
		yield return new WaitForSeconds (cartime);
		audioManager.PlaySound ("CarPassingBy");
	}
}
