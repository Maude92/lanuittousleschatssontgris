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
		if (Input.GetKeyDown (KeyCode.Space))
			LoadNxtScene();
	}

	void LoadNxtScene (){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}
}
