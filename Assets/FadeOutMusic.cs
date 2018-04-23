using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutMusic : MonoBehaviour {

	public GameObject music;
	AudioSource audiosourcemusic;
	public float timefade = 1f;
	public bool fademusictuto;

	// Use this for initialization
	void Start () {
		audiosourcemusic = music.GetComponent <AudioSource> ();
		fademusictuto = false;
	}

	// Update is called once per frame
	void Update () {
		if (fademusictuto == true) {
			audiosourcemusic.volume -= Time.deltaTime / timefade;
		}	
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			music.SetActive (true);
			fademusictuto = true;
		}
	}
}
