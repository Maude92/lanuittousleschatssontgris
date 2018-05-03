using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEventSystem : MonoBehaviour {

	public GameObject player;
	//PauseMenuNightLevel pausemenu;
	PauseMenu pausemenu;

	public GameObject eventSystem;

	// Use this for initialization
	void Start () {
		pausemenu = player.GetComponent<PauseMenu> ();

	}
	
	// Update is called once per frame
	void Update () {
		//pausemenu.modePause
		if (pausemenu.modePause == true){
			eventSystem.SetActive (false);

		}
		if (pausemenu.modePause == false){
			eventSystem.SetActive (true);

		}
	}
}
