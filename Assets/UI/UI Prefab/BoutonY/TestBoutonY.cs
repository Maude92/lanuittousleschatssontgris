using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBoutonY : MonoBehaviour {

	public Canvas ButtonY;
	public Text ButtonYText;
	public string TonTextePourLeBoutonY;

	void OnTriggerEnter (Collider other){
		ButtonY.enabled = true;
		ButtonYText.text = TonTextePourLeBoutonY;

	}

	void OnTriggerExit (Collider other){
		ButtonY.enabled = false;
		ButtonYText.text = "";

	}

}
