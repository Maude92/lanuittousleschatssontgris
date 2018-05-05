using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GratteLePoteau : MonoBehaviour {

	public GameObject mistObj;
	public Canvas ButtonY;

	public Text ButtonYText;
	public string TextePourLeBoutonY;

	//public int jeGratte;
	public float ledelai;

	Animator anim;

	private AudioManager audioManager;

	Xbox_Controls xboxcontrolspc;
	public GameObject playerObj;


	// Use this for initialization
	void Start () {
		//jeGratte = 0;

		anim = mistObj.GetComponent <Animator> ();
		ButtonY.enabled = false;

		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");	}

		xboxcontrolspc = playerObj.GetComponent<Xbox_Controls> ();
	}




	void OnTriggerStay (Collider other){
		if (other.gameObject.tag == "NezDeChat" && (Input.GetButtonDown ("360_YButton")) && anim.GetCurrentAnimatorStateInfo (0).IsName ("A_idle")) {			// Test :  && anim.GetCurrentAnimatorStateInfo (0).IsName ("A_idle")
			//xboxcontrolspc.enabled = false;
			print ("Je gratte un poteau! Much fun!");
			//audioManager.PlaySound ("GratteGratte");
			StartCoroutine (MistGratte());
			anim.SetBool ("Gratte", true);
			ButtonY.enabled = false;
		}
	}


	void OnTriggerEnter (Collider other){
		ButtonY.enabled = true;
		ButtonYText.text = TextePourLeBoutonY;
	}


	void OnTriggerExit (Collider other){
		ButtonY.enabled = false;
		ButtonYText.text = "";
	}

	IEnumerator MistGratte(){
		yield return new WaitForSeconds (ledelai);
		audioManager.PlaySound ("GratteGratte");
		gameObject.GetComponent<Collider> ().enabled = false;
		yield return new WaitForSeconds (3f);
		gameObject.GetComponent<Collider> ().enabled = true;
	}
}
