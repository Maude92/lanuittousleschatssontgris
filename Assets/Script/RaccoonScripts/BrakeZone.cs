using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class BrakeZone : MonoBehaviour {

	// Use this for initialization
	public float targetSpeed = 0f;

	float orginalSpeed;

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "Raccoon") {
			//orginalSpeed = other.GetComponent<NavMeshAgent> ().speed;
			other.GetComponent<NavMeshAgent> ().speed = targetSpeed;
		}
		
	}

//	void OnTriggerExit(Collider col)
//	{
//
//		if(col.CompareTag("Raccoon"))
//			col.GetComponent<NavMeshAgent> ().speed = orginalSpeed;
//	}
}
