using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrigerObjectifB : MonoBehaviour {

	public GameObject TextObjectifB;
	AnimatedTextObjectif AnimatedTextObjectifCode;
	public CanvasGroup ObjectifGroup;
	public GameObject MoiMeme; 
	public Text MonObjectif;

	public GameObject letextequiveutpasdisparaitre;

	// Use this for initialization
	void Start () {
		ObjectifGroup.alpha = 0;
		AnimatedTextObjectifCode = TextObjectifB.GetComponent <AnimatedTextObjectif> ();
	}

	void OnTriggerEnter (Collider other){

		if (other.gameObject.CompareTag("Player")){
			letextequiveutpasdisparaitre.SetActive (false);
			StartCoroutine ("FadeInObjectifScreen");
			AnimatedTextObjectifCode.PartObjectif ();
		}

	}

	void OnTriggerExit (Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			//MonObjectif.text = "";
			StartCoroutine("FadeOutObjectifScreen");
			//MonObjectif.text = "";  //MAUDE !!! ESSAYE ICI VOIR SI ÇA RÈGLE LE BUG DE LA SUPERPOSITION
		}
		//MonObjectif.text = ""; //OU ESSAYE ICI SI LA PREMIÈRE ENDROIT NE FONCTIONNAIT PAS !!
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
