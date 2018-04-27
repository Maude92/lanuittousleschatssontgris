using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrigerObjectifC : MonoBehaviour {

	public GameObject TextObjectifC;
	AnimatedTextObjectif AnimatedTextObjectifCode;
	public CanvasGroup ObjectifGroup;
	public GameObject MoiMeme; 
	public Text MonObjectif;

	MistCanSleep mistcansleep;
	public GameObject playerObj;

	public int afficheObjectif;

	// Use this for initialization
	void Start () {
		ObjectifGroup.alpha = 0;
		AnimatedTextObjectifCode = TextObjectifC.GetComponent <AnimatedTextObjectif> ();

		mistcansleep = playerObj.GetComponent<MistCanSleep> ();

		afficheObjectif = 0;
	}
		

//	void OnTriggerEnter (Collider other){
//
//		if (other.gameObject.CompareTag("Player")){
//			StartCoroutine ("FadeInObjectifScreen");
//			AnimatedTextObjectifCode.PartObjectif ();
//		}
//
//	}
//
//	void OnTriggerExit (Collider other){
//		if (other.gameObject.CompareTag ("Player")) {
//			StartCoroutine("FadeOutObjectifScreen");
//		}
//	}

	// Update is called once per frame
	void Update () {

		if (mistcansleep.countObjetsDisparus >= mistcansleep.nombreMagique) {
			afficheObjectif++;
		}

		if (afficheObjectif == 1) {
			StartCoroutine ("FadeInObjectifScreen");
			AnimatedTextObjectifCode.PartObjectif ();
		}

		if (afficheObjectif == 500) {
			StartCoroutine("FadeOutObjectifScreen");
		}

		if (afficheObjectif >= 501) {
			afficheObjectif = 501;
		}

	}

	IEnumerator FadeInObjectifScreen() {
		yield return new WaitForSeconds (0.25f);

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
