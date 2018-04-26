using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseUI;

	public bool modePause;

	Xbox_Controls xboxcontrolspc;

	public GameObject mainPauseUI;
	public GameObject controlesPauseUI;

	// Use this for initialization
	void Start () {
		modePause = false;

		xboxcontrolspc = GetComponent <Xbox_Controls> ();
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
		}


		// POUR SORTIR DU MENU PAUSE
		if (modePause == false){
			//xboxcontrolspc.enabled = true;
			pauseUI.SetActive (false);
			Time.timeScale = 1;
			mainPauseUI.SetActive (true);
			controlesPauseUI.SetActive (false);
		}
			
	}


}
