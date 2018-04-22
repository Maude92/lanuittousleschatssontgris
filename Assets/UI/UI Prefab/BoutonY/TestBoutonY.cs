using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBoutonY : MonoBehaviour {

	public Canvas ButtonYCanvas;
	public Text ButtonYText;
	public string TextePourLeBoutonY;

	void OnTriggerEnter (Collider other){
		ButtonYCanvas.enabled = true;
		ButtonYText.text = TextePourLeBoutonY;

	}

	void OnTriggerExit (Collider other){
		ButtonYCanvas.enabled = false;
		ButtonYText.text = "";

	}

}
