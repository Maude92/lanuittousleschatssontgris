using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMistToCheckPoint : MonoBehaviour {
	public Image Black;

	public GameObject CheckPoint;

	public GameObject Prefab;
	public Transform InstatiatePlatform;

	bool fadingback = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Black = Black.GetComponent <Image> ();

		if (fadingback == true && Black.color.a > 0f) {
			Color c = Black.color;
			c.a -= (Time.deltaTime * 6f);
			Black.color = c;
		} else if (Black.color.a <= 0f) {
			fadingback = false;
			//			Color c = Black.color;
			//			c.a = 0f;
			//			Black.color = c;
		}
//		if (fadingback = true) {
//		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			Instantiate (Prefab, InstatiatePlatform.transform.position, InstatiatePlatform.transform.rotation);
			//StartCoroutine (Waiting());
			other.transform.position = CheckPoint.transform.position;
			StartCoroutine (Waiting ());

//			Black = Black.GetComponent <Image> ();
//			//Black.color.a = 0f;
//			Color c = Black.color;
//			c.a = 0f;
//			Black.color = c;

			//transform.parent = other.transform;
		}
	}

	IEnumerator Waiting(){
		yield return new WaitForSeconds(1f);
		fadingback = true;
	}


}
