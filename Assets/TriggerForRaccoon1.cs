using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForRaccoon1 : MonoBehaviour {
	
	public GameObject Raccoon;

	// Use this for initialization
	void Start () {
		//Raccoon = GetComponent<GameObject> ();
		Raccoon.SetActive (false);
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			Raccoon.SetActive (true);
			//Instantiate (Prefab, InstatiatePlatform.transform.position, InstatiatePlatform.transform.rotation);
			//Mist.GetComponent<Xbox_Controls>().enabled = false;
			//Mist.GetComponent<MistStopWhenIdle>().enabled = false;
			//StartCoroutine (Waiting());
			//other.transform.position = CheckPoint.transform.position;
			//StartCoroutine (Waiting ());

			//			Black = Black.GetComponent <Image> ();
			//			//Black.color.a = 0f;
			//			Color c = Black.color;
			//			c.a = 0f;
			//			Black.color = c;

			//transform.parent = other.transform;
		}
	}
	void TurnRaccoonOff(){
		Raccoon.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
