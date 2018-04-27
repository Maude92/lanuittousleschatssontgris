using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MistCanSleep : MonoBehaviour {

	public int countObjetsDisparus;
	public int nombreMagique;

	public bool goToSleep;

	public Canvas ButtonY;
	public GameObject leTriggerDodo;
	public GameObject leTriggerObjectifC;

	Animator anim;
	public GameObject mistObj;

	public GameObject health;

	public int afficheObjectifPlease;

	public Image Black;

	public bool pleaseFadeToBlack;

	//public PlayableDirector Cinematique2;

	// Use this for initialization
	void Start () {
		//Cinematique2.Stop ();
		pleaseFadeToBlack = false;
		countObjetsDisparus = 0;
		afficheObjectifPlease = 0;
		goToSleep = false;

		anim = mistObj.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (countObjetsDisparus >= nombreMagique) {
			print ("Je peux aller me coucher, j'ai fait disparaître le bon nombre d'objets. (à implémenter)");
			leTriggerDodo.SetActive (true);
//			afficheObjectifPlease++;
			// Faire apparaître nouveau UI objectif
		}

//		if (afficheObjectifPlease == 1) {
//			StartCoroutine (AfficheObjectifC ());
//		} 
//		if (afficheObjectifPlease >= 2) {
//			afficheObjectifPlease = 2;
//		}

		if (pleaseFadeToBlack == true) {
			Color c = Black.color;
			c.a += (Time.deltaTime * 2f);
			Black.color = c;
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "LitDouillet") {
			ButtonY.enabled = true;
		}
	}

	void OnTriggerStay (Collider other){
		if (other.gameObject.tag == "LitDouillet" && Input.GetButtonDown ("360_YButton") && countObjetsDisparus >= nombreMagique) {
			print ("Zzzzzz.... (cinématique se déclenche quand je pèse sur Y, à implémenter)");
			Staticlife.numberoflives = health.GetComponent<HealthBar> ().NbVieRestant;
			anim.SetBool ("DodoTime", true);
			goToSleep = true;
			ButtonY.enabled = false;
			StartCoroutine (FadeToNextScreen ());
			//Cinematique2.Play ();
			// Il faut que le UI de Y affiche
			// Déclenche une cinématique
			// Animation de Mist qui s'asseoit, miaule, se couche, s'endort
			// Fade out à la nouvelle scène (même maison, mais fenêtre ouverte)
		}
	}

	IEnumerator AfficheObjectifC (){
		leTriggerObjectifC.SetActive (true);
		yield return new WaitForSeconds (3f);
		leTriggerObjectifC.SetActive (false);
	}

	IEnumerator FadeToNextScreen(){
		yield return new WaitForSeconds (3f);
		pleaseFadeToBlack = true;
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
