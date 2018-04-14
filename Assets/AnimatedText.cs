using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedText : MonoBehaviour {

	private AudioManager audioManager;

	public float delay = 0.1f;
	public string fullText;
	private string currentText = "";

	public CanvasGroup InstructionBoutonStart;

	public bool death = true;

	// Use this for initialization
	void Start () {

		InstructionBoutonStart.alpha = 0.01f;
		StartCoroutine(ShowText());

		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");
		}
	
	}

	void Update () {
		if (Input.GetButtonDown("XbOne_StartButton")) {
			//Faire reloader le dernier checkpoint ou le début du niveau ?
			print ("Je dois loader le dernier checkpoint ou faire reloader le level");
		}

		StartCoroutine(FadeIn());
	}

	IEnumerator ShowText(){
//		yield return new WaitForSeconds (0.01f);
//		audioManager.PlaySound ("GameOver_Screen");
		//audioManager.PlaySound ("Objectif_New"); //Son pour objectif
		if (death == true){

			for(int i = 0; i < fullText.Length; i++){
				currentText = fullText.Substring(0,i);
				this.GetComponent<Text>().text = currentText;
				yield return new WaitForSeconds(delay);
				//audioManager.PlaySound ("GameOver_Screen");
			}
			//yield return new WaitForSeconds (0.1f);
			audioManager.PlaySound ("GameOver_Screen");
			yield return new WaitForSeconds (1.0f);
			InstructionBoutonStart.alpha = 0;
		}

	}

	IEnumerator FadeIn() {
		//yield return new WaitForSeconds (5f);

		float time = 1f;

		if (InstructionBoutonStart.alpha != 0.01f) {
			yield return new WaitForSeconds (0.01f);
			InstructionBoutonStart.alpha += Time.deltaTime * time;
			if (InstructionBoutonStart.alpha > 1) {
				InstructionBoutonStart.alpha = 1;
			}
		}
	}

}
