using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBoussolleBalancing : MonoBehaviour {

	public RectTransform Needle;
	public GameObject Player;
	//Vector3 PlayerRot = Mist.transform.rotation.y;
	//Vector3 PlayerRot = (Mist.transform.rotation.x, Mist.transform.rotation.y, Mist.transform.rotation.z);
	private Quaternion qTo;


	// Use this for initialization
	void Start () {
		//qTo = Mist.transform.rotation;
	}

	// Update is called once per frame
	void Update () {
		//Vector3 PlayerRot = Mist.eulerAngles; 
		//Needle.transform.rotation = Quaternion.Euler (0, 0, Mist.transform.rotation.z);
		//Needle.transform.rotation = new Vector3 (0, 0, Mist.transform.rotation.z);
		//Needle.transform.rotation = Quaternion.Euler (0, 0, PlayerRot.y);

		qTo = Player.transform.rotation;


		Needle.transform.rotation = qTo;
	}
}
