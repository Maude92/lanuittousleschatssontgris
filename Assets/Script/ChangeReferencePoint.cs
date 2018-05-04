using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeReferencePoint : MonoBehaviour {
	public GameObject PositionReference;
	public GameObject NewPosition;

	public GameObject ColliderEnd;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			PositionReference.transform.position = NewPosition.transform.position;
			Vector3 newRot = new Vector3 (NewPosition.transform.eulerAngles.x, NewPosition.transform.eulerAngles.y, NewPosition.transform.eulerAngles.z);
				PositionReference.transform.rotation = Quaternion.Euler (newRot);
			ColliderEnd.GetComponent<Collider> ().isTrigger = true;
		}

	}
}
