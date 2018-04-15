using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseUI;

	public bool modePause;

	// Use this for initialization
	void Start () {
		modePause = false;
	}
		
	
	// Update is called once per frame
	void Update () {

		// POUR LE MENU PAUSE
		if (Input.GetButtonDown ("360_StartButton")){
			modePause = !modePause;
		}


		// POUR ACTIVER LE MENU PAUSE
		if (modePause == true){
			pauseUI.SetActive (true);
			Time.timeScale = 0;
		}


		// POUR SORTIR DU MENU PAUSE
		if (modePause == false){
			pauseUI.SetActive (false);
			Time.timeScale = 1;
		}
			
	}


}
