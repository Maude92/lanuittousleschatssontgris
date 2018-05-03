using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrigerObjectifF : MonoBehaviour {

	public GameObject TextObjectifF;
	AnimatedTextObjectif AnimatedTextObjectifCode;
	public CanvasGroup ObjectifGroup;
	public GameObject MoiMeme; 
	public Text MonObjectif;

	public GameObject letextequiveutpasdisparaitre;		// Pour éviter le même bogue que dans le tuto, c'est le texte objectif précédent

	// Use this for initialization
	void Start () {
		ObjectifGroup.alpha = 0;
		AnimatedTextObjectifCode = TextObjectifF.GetComponent <AnimatedTextObjectif> ();
	}

	void OnTriggerEnter (Collider other){

		if (other.gameObject.CompareTag("Player")){
			letextequiveutpasdisparaitre.SetActive (false);		// Pour éviter le même bogue que dans le tuto, c'est le texte objectif précédent
			StartCoroutine ("FadeInObjectifScreen");
			AnimatedTextObjectifCode.PartObjectif ();
		}

	}

	void OnTriggerExit (Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			StartCoroutine("FadeOutObjectifScreen");
		}
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator FadeInObjectifScreen() {
		//yield return new WaitForSeconds (5f);

		float time = 1.5f;

		while (ObjectifGroup.alpha < 1) {
			yield return new WaitForSeconds (0.01f);
			ObjectifGroup.alpha += Time.deltaTime * time;
			if (ObjectifGroup.alpha > 1) {
				ObjectifGroup.alpha = 1;
			}
		}
	}

	IEnumerator FadeOutObjectifScreen() {
		//yield return new WaitForSeconds (5f);

		float time = 1f;

		while (ObjectifGroup.alpha > 0) {
			yield return new WaitForSeconds (0.01f);
			ObjectifGroup.alpha -= Time.deltaTime / time;
			if (ObjectifGroup.alpha < 0) {
				ObjectifGroup.alpha = 0;
			}
		}
		MonObjectif.text = "";
		MoiMeme.SetActive (false);
	}
}
