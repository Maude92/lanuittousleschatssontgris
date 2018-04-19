using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfficheInfos : MonoBehaviour {

	public CanvasGroup panneauInfos;
	public GameObject UIinfos;
	public GameObject UIprecedent;

	public float fadeTime;
	public float tempsAffiche;
	public bool fadeInfos;

	// Use this for initialization
	void Start () {
		panneauInfos.alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeInfos == true) {
			StartCoroutine (AfficheCetInfo());
		}


	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			UIinfos.SetActive (true);
			fadeInfos = true;
		}
	}

	IEnumerator AfficheCetInfo(){
		if (UIprecedent.activeInHierarchy == true) {
			panneauInfos.alpha = 0;
			UIprecedent.SetActive (false);
		}
		panneauInfos.alpha += Time.deltaTime / fadeTime;
		yield return new WaitForSeconds (tempsAffiche);
		fadeInfos = false;
		panneauInfos.alpha -= Time.deltaTime / fadeTime;
		yield return new WaitForSeconds (tempsAffiche);
		if (panneauInfos.alpha == 0) {
			UIinfos.SetActive (false);
			gameObject.SetActive (false);
		}
		//yield return new WaitForSeconds (10f);
		//UIinfos.SetActive (false);
	}
}
