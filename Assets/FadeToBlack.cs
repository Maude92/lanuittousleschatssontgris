using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour {
	public Image Black;
	float Alpha;


	Color alphaColor;
	Color regColor;

	bool isfading = false;

	// Use this for initialization
	void Start () {
		Black = Black.GetComponent <Image> ();
		//Black.color.a = 0f;
		Color c = Black.color;
		c.a = 0f;
		Black.color = c;

//		alphaColor = new Color(1.0f, 1.0f, 1.0f, 0f);
//		regColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		Black = Black.GetComponent <Image> ();

		if (isfading == true && Black.color.a < 1f) {
			Color c = Black.color;
			c.a += (Time.deltaTime * 5f);
			Black.color = c;
		} else if (Black.color.a >= 1f) {
			isfading = false;
//			Color c = Black.color;
//			c.a = 0f;
//			Black.color = c;
		}

		//Alpha = Black.color.a;


//		while(Alpha < 1){
//			Color c = Black.color;
//			c.a += Time.deltaTime * 30;
//			Black.color = c;
			//Alpha += Time.deltaTime * 30;
			//Color newColor = new Color (1,1,1,Alpha);
			//Black.color = newColor;
		//}


//		if(Black.color.a < 1){
//			Black.color.a += Time.deltaTime *3;
//		}	
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			//FadeIn ();
			isfading = true;
			//Black.color = Color.Lerp (alphaColor, regColor, 30f);
			//Black.color.a = Mathf.Lerp (0f, 1f, 1f);
			//transform.parent = other.transform;
		}
	}

	IEnumerator Waiting(){
		
		yield return new WaitForSeconds (1);

	}

	void FadeIn(){
		//Black = Black.GetComponent <Image> ();
		Black = Black.GetComponent <Image> ();
		Black.CrossFadeAlpha (1f, 0.5f, true);
	}


}
