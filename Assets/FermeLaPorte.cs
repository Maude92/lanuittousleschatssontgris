using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FermeLaPorte : MonoBehaviour {

	Animator animPorte;

	public GameObject porteMaison;

	private AudioManager audioManager;

	// Use this for initialization
	void Start () {
		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");	}

		animPorte = porteMaison.GetComponent <Animator> ();
		animPorte.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			//print ("Faut j'ajoute un bruit de porte qui claque!");
			audioManager.PlaySound ("PorteClaque");
			animPorte.enabled = true;
		}
	}


	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player") {
			gameObject.GetComponent<Collider>().enabled = false;
		}
	}
}
