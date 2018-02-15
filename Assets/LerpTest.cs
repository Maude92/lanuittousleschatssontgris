using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour {

	public float lerpTime = 1f;
	public float currentLerpTime;

	public float moveDistance = 10f;

	Vector3 startPos;
	Vector3 endPos;

	protected void Start() {
		startPos = transform.position;
		endPos = transform.position + transform.up * moveDistance;
	}

	protected void Update() {
		//reset when we press spacebar
		if (Input.GetKeyDown(KeyCode.Space)) {
			currentLerpTime = 0f;
		}

		//increment timer once per frame
		currentLerpTime += Time.deltaTime;
		if (currentLerpTime > lerpTime) {
			currentLerpTime = lerpTime;
		}

		//lerp!
//		float perc = currentLerpTime / lerpTime;
//		transform.position = Vector3.Lerp(startPos, endPos, perc);
		float t = currentLerpTime / lerpTime;
//		t = Mathf.Sin(t * Mathf.PI * 0.5f);
//		t = t*t*t * (t * (6f*t - 15f) + 10f);
		t = t*t;
		transform.position = Vector3.Lerp(startPos, endPos, t);
	}
}
