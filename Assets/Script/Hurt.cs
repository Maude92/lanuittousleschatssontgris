using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour {

	//public GameObject vieObj;
	//HealthBar viescript;
	//Animator anim;

	public Transform healthbar;

//	private AudioManager audioManager;

	// Use this for initialization
	void Start () {
		//viescript = vieObj.GetComponent<HealthBar> ();
		//anim = X.GetComponent<Animator> ();

//		audioManager = AudioManager.instance;
//		if (audioManager == null) {
//			Debug.LogError ("Attention, le AudioManager n'a pas été trouvé dans la scène.");}
	}

	IEnumerator TurnOffTrigger(){
		Debug.Log ("HURT");
		GetComponent<Collider> ().enabled = false;
		yield return new WaitForSeconds (2);
		GetComponent<Collider> ().enabled = true;
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player" /*&& viescript.currentHealth >= 1.0f*/) {
			//audioManager.PlaySound ("Hurt");
			//anim.SetBool ("Hit", true);
			//viescript.currentHealth = viescript.currentHealth - 5.0f;
			healthbar.GetComponent<HealthBar>().Damage(2);
			StartCoroutine (TurnOffTrigger());
		}
	}
}
