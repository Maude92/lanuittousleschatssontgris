using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//C'est le code pour le DeathScreen lorsque le joueur perd une vie

public class AnimatedText : MonoBehaviour {

	private AudioManager audioManager;

	public float delay = 0.1f;
	public string fullText = "Mist a perdu une de ses 9 vies ";
	private string currentText = "";
	public Text EndroitOuLeTexteDoitApparaitre;

	public CanvasGroup InstructionBoutonStart;
	public CanvasGroup CeluiCi;

	public bool death = false;
	public bool reset = false;

	public bool repartMusique;

	public AudioSource SadSong;
	public AudioSource levelmusique;

	PauseMenu pausemenu;
	public GameObject playerObj;

	public GameObject CodeUIvie;

	public float timefade = 3f;

	public bool pleaseFadeOut;
	//public bool pleaseFadeIn;

	// POUR AFFICHER LE MESSAGE QUAND T'AS PLUS DE VIE
	public GameObject leeventsystemdouble;
	public GameObject lenouveaueventsystem;
	public GameObject messageFinUI;

	HealthBar healthbarscript;



	// Use this for initialization
	void Start () {

		repartMusique = false;

		pleaseFadeOut = false;

		SadSong.enabled = false;
		SadSong.Stop ();

		InstructionBoutonStart.alpha = 0;
//		StartCoroutine(ShowText());


		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");
		}

		pausemenu = playerObj.GetComponent <PauseMenu> ();

		healthbarscript = CodeUIvie.GetComponent<HealthBar> ();
	
	}

	void Update () {
		if (Input.GetButtonDown ("360_StartButton") && InstructionBoutonStart.alpha == 1) {
			if (healthbarscript.NbVieRestant >= 1) {
				//Faire reloader le dernier checkpoint ou le début du niveau ?
				//pausemenu.modePause = false;
				print ("Je dois loader le dernier checkpoint ou faire reloader le level");
				CeluiCi.alpha = 0;
				//InstructionBoutonStart.alpha = 0;
				reset = true;
				SadSong.Stop ();
				SadSong.enabled = false;
				repartMusique = true;
				levelmusique.enabled = true;
				levelmusique.Play ();
			} else if (healthbarscript.NbVieRestant < 1){
				// J'affiche le panneau de fin!
				CeluiCi.alpha = 0;
				reset = true;
				leeventsystemdouble.SetActive (false);
				lenouveaueventsystem.SetActive (true);
				messageFinUI.SetActive (true);
				levelmusique.volume = 0f;
				levelmusique.enabled = false;
				levelmusique.Stop ();
				pausemenu.enabled = false;
				//healthbarscript.enabled = false;
				//playerObj.SetActive (false);
			}
		}

		if (CodeUIvie.GetComponent<HealthBar> ().NbVieRestant == 0) {
			fullText = "Mist a perdu toutes ses vies... ";
		}

		if (repartMusique == true) {
			levelmusique.volume += Time.deltaTime / timefade;
			if (levelmusique.volume >= 0.75f) {
				levelmusique.volume = 0.75f;
				repartMusique = false;
			}
		}

		if (reset == true) {
			currentText = "";
			EndroitOuLeTexteDoitApparaitre.text = "";
			InstructionBoutonStart.alpha = 0;
			reset = false;
		}

		if (CeluiCi.alpha > 0) {
			pausemenu.enabled = false;
		} else if (CeluiCi.alpha == 0) {
			pausemenu.enabled = true;
		}

		if (pleaseFadeOut == true) {
			levelmusique.volume -= Time.deltaTime / timefade;
		}
			
			
	}

	public void StartLeShit (){
		StartCoroutine (ShowText ());
	}
		

	IEnumerator ShowText(){
//		levelmusique.volume -= Time.deltaTime / timefade;
		pleaseFadeOut = true;

			SadSong.enabled = true;
			SadSong.Play ();

			for (int i = 0; i < fullText.Length; i++) {
			currentText += fullText.Substring (i,1);
				this.GetComponent<Text> ().text = currentText;
			print (i + " " + fullText.Substring (i, 1) + currentText);
				yield return new WaitForSeconds (delay);
				//audioManager.PlaySound ("GameOver_Screen");
				
			}
			audioManager.PlaySound ("GameOver_Screen");
			yield return new WaitForSeconds (0.1f);
			StartCoroutine (FadeIn ());
	}

	IEnumerator FadeIn() {
		//yield return new WaitForSeconds (5f);
		//pausemenu.enabled = false;
		pleaseFadeOut = false;
		float time = 1f;

		//if (InstructionBoutonStart.alpha > 0) {
		while (InstructionBoutonStart.alpha < 1) {
			yield return new WaitForSeconds (0.01f);
			InstructionBoutonStart.alpha += Time.deltaTime * time;
			if (InstructionBoutonStart.alpha > 1) {
				InstructionBoutonStart.alpha = 1;
			}
		}

	}

}
