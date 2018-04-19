using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adieu : MonoBehaviour {

	Color alphaColor;
	Color regColor;
	MeshRenderer meshobj;

	//MeshRenderer meshobjB;
	//public MeshRenderer[] shit;
	//MeshRenderer meshobjs;

	//public GameObject[] morceaux;
	//public int nombredemorceaux;
	//MeshRenderer[] meshobjs = new MeshRenderer[nombredemorceaux];
	//public MeshRenderer[] meshobjs;

	public float lerpDuration = 3f;

	public GameObject cetobjet;
	public GameObject opaqueobjet;

	MistCanSleep mistcansleep;
	public GameObject player;


	//public int childIndex;

	void Start (){
		alphaColor = new Color(1.0f, 1.0f, 1.0f, 0f);
		regColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		//meshobj = GetComponent<MeshRenderer> ();

		player = GameObject.FindGameObjectWithTag ("Player");
		mistcansleep = player.GetComponent<MistCanSleep> ();



		//meshobjB = shit [1].GetComponent<MeshRenderer> ();
		//meshobjs = GetComponentsInChildren<MeshRenderer>();


//		for (int childIndex= 0; childIndex < gameObject.transform.childCount; childIndex++) {
//			Transform child = gameObject.transform.GetChild (childIndex);
////			meshobj = child.gameObject.GetComponent<MeshRenderer> ();
////			alphaColor = child.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
////			regColor = child.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
//			//child.gameObject.AddComponent<Adieu> ();
//		}

//		Transform child = gameObject.transform.GetChild (childIndex);
//		meshobj = child.gameObject.GetComponent<MeshRenderer> ();
//		alphaColor = child.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
//		regColor = child.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	}


	private void Update()
	{

//		if(Input.GetKeyDown(KeyCode.F))
//		{
//			//StartCoroutine(Lerp_MeshRenderer_Color(1.0f, 1.0f, 1.0f, 0f));
//			//StartCoroutine(Lerp_MeshRenderer_Color(meshobj, regColor, meshobj, alphaColor));
//			StartCoroutine(Lerp_MeshRenderer_Color(meshobj, lerpDuration, regColor, alphaColor));
//		}

	}


	void OnTriggerEnter(Collider other){
	
		if (other.gameObject.tag == "Player") {
			mistcansleep.countObjetsDisparus++;
			opaqueobjet.SetActive (false);
			StartCoroutine(Lerp_MeshRenderer_Color(lerpDuration, regColor, alphaColor));
		}
	
	}


	private IEnumerator Lerp_MeshRenderer_Color(float lerpDuration, Color startLerp, Color targetLerp)
	{
		float lerpStart_Time = Time.time;
		float lerpProgress;
		bool lerping = true;
		while (lerping)
		{
			yield return new WaitForEndOfFrame();
			lerpProgress = Time.time - lerpStart_Time;
			for (int childIndex = 0; childIndex < transform.GetChildCount (); childIndex++) {
				if (transform.GetChild (childIndex).GetComponent<MeshRenderer> () != null) {
					transform.GetChild (childIndex).GetComponent<MeshRenderer> ().material.color = Color.Lerp (startLerp, targetLerp, lerpProgress / lerpDuration);
				} else {
					lerping = false;
				}
			}

			if (lerpProgress >= lerpDuration)
			{
				lerping = false;
			}
		}
		cetobjet.SetActive (false);
		yield break;

	}
}
