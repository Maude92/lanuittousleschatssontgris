using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrigerObjectifA : MonoBehaviour {

	public GameObject TextObjectifA;
	AnimatedTextObjectif AnimatedTextObjectifCode;
	public CanvasGroup ObjectifGroup;
	public GameObject MoiMeme;
	public Text MonObjectif;

	public float time = 0f;

	// Use this for initialization
	void Start () {
		ObjectifGroup.alpha = 0;
		AnimatedTextObjectifCode = TextObjectifA.GetComponent <AnimatedTextObjectif> ();
	}

	void Update () {
//		time -= Time.deltaTime;
//
//		if (time <= 0) {
//			StartCoroutine("FadeOutObjectifScreen");
//		}
	}

	void OnTriggerEnter (Collider other){

		if (other.gameObject.CompareTag("Player")){
			//time = 7f;
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
