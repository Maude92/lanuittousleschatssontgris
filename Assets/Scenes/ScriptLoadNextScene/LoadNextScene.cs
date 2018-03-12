using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour {

	//public int NumeroScene;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.N))
			LoadNxtScene();
		if (Input.GetKeyDown (KeyCode.P))
			LoadPrecScene ();
		if (Input.GetKeyDown (KeyCode.R))
			ReloadScene ();
		if (Input.GetKeyDown (KeyCode.Escape))
			Quit ();
			
	}

	void LoadNxtScene (){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}

	void ReloadScene (){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void LoadPrecScene (){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	void Quit (){
		Application.Quit ();
	}
}
