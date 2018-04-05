using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaccoonCatchesMist2 : MonoBehaviour {

	public Image Black;

	public GameObject Mist;
	public GameObject CheckPoint;

	public GameObject Prefab1;
	public Transform InstatiatePlatform1;
	public GameObject Prefab2;
	public Transform InstatiatePlatform2;
	public GameObject Prefab3;
	public Transform InstatiatePlatform3;

	public float waitforseconds = 3f;

	//public GameObject PositionReference;
	//public GameObject Raccoon;
	//public GameObject RaccoonEmpty;
	//NavMover NavMover;

	//public GameObject TriggerForRaccoon;
	//TriggerForRaccoon1 TriggerRaccoon;

	bool fadingback = false;
	bool isfading = false;

	// Use this for initialization
	void Start () {
		//TriggerRaccoon = TriggerForRaccoon.GetComponent<TriggerForRaccoon1> ();
		//NavMover = Raccoon.GetComponent<NavMover> ();
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
			Instantiate (Prefab1, InstatiatePlatform1.transform.position, InstatiatePlatform1.transform.rotation);
			Instantiate (Prefab2, InstatiatePlatform2.transform.position, InstatiatePlatform2.transform.rotation);
			Instantiate (Prefab3, InstatiatePlatform3.transform.position, InstatiatePlatform3.transform.rotation);
			//Instantiate (Prefab, InstatiatePlatform.transform.position, InstatiatePlatform.transform.rotation);
			Mist.GetComponent<Xbox_Controls>().enabled = false;
			Mist.GetComponent<MistStopWhenIdle>().enabled = false;
			//StartCoroutine (Waiting());
			isfading = true;

			//other.transform.position = CheckPoint.transform.position;
			//other.transform.rotation = CheckPoint.transform.rotation;
			//other.transform.position = CheckPoint.transform.position;
			//RaccoonEmpty.SetActive (false);
			StartCoroutine (Waiting ());
			//RaccoonEmpty.SetActive (false);

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
		//Raccoon.transform.position = PositionReference.transform.position;
		//TriggerRaccoon.TurnRaccoonOff ();
		//NavMover.destPoint = 0;
		//RaccoonEmpty.SetActive (false);
		fadingback = true;
		Mist.GetComponent<MistStopWhenIdle>().enabled = true;
		Mist.GetComponent<Xbox_Controls>().enabled = true;

	}
}
