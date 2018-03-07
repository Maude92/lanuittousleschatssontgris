using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBoussolleBalancing : MonoBehaviour {
	public GameObject cylindre;
	TorqueOnTube ToT;

	public RectTransform Needle;
	public GameObject Player;
	//Vector3 PlayerRot = Mist.transform.rotation.y;
	//Vector3 PlayerRot = (Mist.transform.rotation.x, Mist.transform.rotation.y, Mist.transform.rotation.z);
	private Quaternion qTo;
	public float rotation = -1;
	public float needleAngle;


	// Use this for initialization
	void Start () {
		ToT = cylindre.GetComponent<TorqueOnTube> ();
		//qTo = Mist.transform.rotation;
	}

	// Update is called once per frame
	void Update () {
		//print (rotation);

		//Vector3 PlayerRot = Mist.eulerAngles; 
		//Needle.transform.rotation = Quaternion.Euler (0, 0, Mist.transform.rotation.z);
		//Needle.transform.rotation = new Vector3 (0, 0, Mist.transform.rotation.z);
		//Needle.transform.rotation = Quaternion.Euler (0, 0, PlayerRot.y);

		//qTo = Player.transform.rotation;
		//qTo = Player.transform.rotation *= 3f;
		needleAngle = ToT.biggerAngle;

		Quaternion rot = transform.rotation;
		rot.eulerAngles = new Vector3 (0f, 0f, rotation * needleAngle);

		//needleAngle = ToT.biggerAngle;
		Needle.transform.rotation = rot;


		//Needle.transform.rotation = qTo;
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Needle") {
			//print (rotation);
			rotation *= -1;
		} 
	}
}
