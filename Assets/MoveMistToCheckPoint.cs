using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMistToCheckPoint : MonoBehaviour {
	public Image Black;

	public GameObject Mist;
	public GameObject CheckPoint;
	public GameObject Bird;
	public GameObject BirdTarget;

	public GameObject Prefab;
	public Transform InstatiatePlatform;

	bool fadingback = false;
	bool isfading = false;

	public float waitforseconds = 3f;

	// Use this for initialization
	void Start () {
		
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
			Mist.GetComponent<Xbox_Controls>().enabled = false;
			Mist.GetComponent<MistStopWhenIdle>().enabled = false;
			//StartCoroutine (Waiting());
			isfading = true;

			//other.transform.position = CheckPoint.transform.position;
			//other.transform.rotation = CheckPoint.transform.rotation;
			//Bird.transform.position = BirdTarget.transform.position;
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
		yield return new WaitForSeconds(waitforseconds);
		Mist.transform.position = CheckPoint.transform.position;
		Mist.transform.rotation = CheckPoint.transform.rotation;
		Bird.transform.position = BirdTarget.transform.position;
		//Mist.transform.position = CheckPoint.transform.position;
		fadingback = true;
		Mist.GetComponent<Xbox_Controls>().enabled = true;
		Mist.GetComponent<MistStopWhenIdle>().enabled = true;
	}


}
