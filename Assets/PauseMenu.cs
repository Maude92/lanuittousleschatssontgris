using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseUI;

	public bool modePause;

	Xbox_Controls xboxcontrolspc;

	public GameObject mainPauseUI;
	public GameObject controlesPauseUI;

	public AudioSource musiqueTuto1;
	public AudioSource musiqueTuto2;

	QuelleMusiqueJoue quellemusiquejoue;
	public GameObject leTriggerMusic;

	public bool jesuisdansleleveldenuit;

	// Use this for initialization
	void Start () {
		modePause = false;

		xboxcontrolspc = GetComponent <Xbox_Controls> ();

		quellemusiquejoue = leTriggerMusic.GetComponent<QuelleMusiqueJoue> ();
	}
		
	
	// Update is called once per frame
	void Update () {

		// POUR LE MENU PAUSE
		if (Input.GetButtonDown ("360_StartButton")){
			modePause = !modePause;
		}


		// POUR ACTIVER LE MENU PAUSE
		if (modePause == true){
			xboxcontrolspc.enabled = false;
			pauseUI.SetActive (true);
			Time.timeScale = 0;
			if (quellemusiquejoue.changeDeMusique == false) {
			// baisser le volume de la track 1
				musiqueTuto1.volume = 0.4f;
			} else if (quellemusiquejoue.changeDeMusique == true){
				// baisser le volume de la track 2
				musiqueTuto2.volume = 0.65f;
			}
		}


		// POUR SORTIR DU MENU PAUSE
		if (modePause == false){
			//xboxcontrolspc.enabled = true;
			pauseUI.SetActive (false);
			Time.timeScale = 1;
			mainPauseUI.SetActive (true);
			controlesPauseUI.SetActive (false);
			if (quellemusiquejoue.changeDeMusique == false) {
				// remonter le volume de la track 1
				if (jesuisdansleleveldenuit == false) {
					musiqueTuto1.volume = 0.75f;
				} else if (jesuisdansleleveldenuit == true) {
					musiqueTuto1.volume = 0.8f;}
			} else if (quellemusiquejoue.changeDeMusique == true){
				// remonter le volume de la track 2
				musiqueTuto2.volume = 1f;
			}
		}
			
	}


}
