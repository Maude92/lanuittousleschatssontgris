using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutTest : MonoBehaviour {

	public CanvasGroup BlackObjectifScreen;

	// Use this for initialization
	void Start () {
		BlackObjectifScreen.alpha = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown("XbOne_StartButton") || Input.GetButton("XbOne_StartButton") || Input.GetButtonUp("XbOne_StartButton")) {
			StartCoroutine("FadeOut");
			}
		}

	IEnumerator FadeOut() {
		//yield return new WaitForSeconds (5f);

		float time = 1f;

		if (BlackObjectifScreen.alpha > 0) {
			yield return new WaitForSeconds (0.01f);
			BlackObjectifScreen.alpha -= Time.deltaTime / time;
			if (BlackObjectifScreen.alpha < 0) {
				BlackObjectifScreen.alpha = 0;
			}
		}
	}
}
