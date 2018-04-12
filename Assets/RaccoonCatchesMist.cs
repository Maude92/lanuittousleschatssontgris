using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaccoonCatchesMist : MonoBehaviour {
	public Image Black;

	public GameObject Mist;
	public GameObject CheckPoint;

	public GameObject Prefab;
	public Transform InstatiatePlatform;

	public float waitforseconds = 3f;

	public AudioClip raccoon;

	bool fadingback = false;
	bool isfading = false;

	// Use this for initialization
	void Start () {

		Black = Black.GetComponent <Image> ();
		//Black.color.a = 0f;
		Color c = Black.color;
		c.a = 0f;
		Black.color = c;


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
			c.a -= (Time.deltaTime * 3f);
			Black.color = c;
		} else if (Black.color.a <= 0f) {
			fadingback = false;
			//			Color c = Black.color;
			//			c.a = 0f;
			//			Black.color = c;
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			Instantiate (Prefab, InstatiatePlatform.transform.position, InstatiatePlatform.transform.rotation);
			//Instantiate (Prefab, InstatiatePlatform.transform.position, InstatiatePlatform.transform.rotation);
			GetComponent<AudioSource>().PlayOneShot (raccoon,1);
			Mist.GetComponent<Xbox_Controls>().enabled = false;
			Mist.GetComponent<MistStopWhenIdle>().enabled = false;
			//StartCoroutine (Waiting());
			isfading = true;

			//other.transform.position = CheckPoint.transform.position;
			//other.transform.rotation = CheckPoint.transform.rotation;
		
			StartCoroutine (Waiting ());
		

		
		}
	}
	IEnumerator Waiting(){
		yield return new WaitForSeconds(waitforseconds);
		Mist.transform.position = CheckPoint.transform.position;
		Mist.transform.rotation = CheckPoint.transform.rotation;
		//Raccoon.transform.position = PositionReference.transform.position;
		//TriggerRaccoon.TurnRaccoonOff ();
		//NavMover.destPoint = 0;
		//RaccoonEmpty.SetActive (false);
		fadingback = true;
		Mist.GetComponent<MistStopWhenIdle>().enabled = true;
		Mist.GetComponent<Xbox_Controls>().enabled = true;

	}
}
