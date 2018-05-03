using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedTextObjectifLevelNuit : MonoBehaviour {
	private AudioManager audioManager;

	public float delay = 0.1f;
	public string fullText;
	private string currentText = "";

	public Text ObjectifRappelUIVie;
	public Text objectifRappelMenuPause;

	public CanvasGroup CeluiCi;

	PauseMenuNightLevel pausemenu;
	public GameObject playerObj;

	// Use this for initialization
	void Start () {
		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");
		}

		pausemenu = playerObj.GetComponent <PauseMenuNightLevel> ();

		//		StartCoroutine(ShowTextObjectif());
		//		Invoke ("SonObjectif", 0.6f);

	}

	// Update is called once per frame
	void Update () {
		if (CeluiCi.alpha > 0) {
			pausemenu.enabled = false;
		} else if (CeluiCi.alpha == 0) {
			pausemenu.enabled = true;
		}
	}

	public void PartObjectif (){
		StartCoroutine(ShowTextObjectif());
		Invoke ("SonObjectif", 0.6f);
		ObjectifRappelUIVie.text = fullText;
		objectifRappelMenuPause.text = fullText;
		if (fullText == "Va dormir, peut-être qu'ils reviendront demain... ") {
			ObjectifRappelUIVie.text = "Va dormir ";
		}

	}

	void SonObjectif () {
		audioManager.PlaySound ("Objectif_New");
	}

	IEnumerator ShowTextObjectif(){
		for (int i = 0; i < fullText.Length; i++) {
			currentText = fullText.Substring (0, i);
			this.GetComponent<Text> ().text = currentText;
			yield return new WaitForSeconds (delay);
			//audioManager.PlaySound ("GameOver_Screen");
		}


	}
}
