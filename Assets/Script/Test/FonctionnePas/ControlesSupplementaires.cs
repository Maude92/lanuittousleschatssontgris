using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesSupplementaires : MonoBehaviour {

	private Transform m_Cam;                  // A reference to the main camera in the scenes transform
	private Vector3 m_CamForward;             // The current forward direction of the camera
	private Vector3 m_Move;

	// Use this for initialization
	private void Start () {
		// get the transform of the main camera
		if (Camera.main != null) {
			m_Cam = Camera.main.transform;
		} else {
			Debug.LogWarning (
				"Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
		}
	}


	// Fixed update is called in sync with physics
	private void FixedUpdate()
	{
		// read inputs
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		// calculate move direction to pass to character
		if (m_Cam != null)
		{
			// calculate camera relative direction to move:
			m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
			m_Move = v*m_CamForward + h*m_Cam.right;
		}
		else
		{
			// we use world-relative directions in the case of no main camera
			m_Move = v*Vector3.forward + h*Vector3.right;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
