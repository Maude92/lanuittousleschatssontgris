using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThugMist : MonoBehaviour {

	private AudioManager audioManager;

	public GameObject fallingobject;
	public GameObject mistObj;
	public GameObject particlesDestruction;

	public float timeBeforeFall = 0.4f;
	public float thugForce = 100f;

	Animator anim;
	//Collider colFallingObjet;
	Rigidbody rbObject;

	// Use this for initialization
	void Start () {
		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");
		}



		anim = mistObj.GetComponent<Animator> ();
		//colFallingObjet = GetComponent<Collider> ();
		rbObject = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player" && gameObject.tag == "FallingObjectDroite" ) {
			//print ("Je suis proche du pot de fleur");
			StartCoroutine (MistEstThug());
		} 
		if (other.gameObject.tag == "Player" && gameObject.tag == "FallingObjectGauche") {
			StartCoroutine (MistEstThugGauche());
		}
	}

	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "Solide" || other.gameObject.tag == "Gazon") {
			particlesDestruction.transform.position = gameObject.transform.position;
			particlesDestruction.SetActive (true);
			audioManager.PlaySound ("Flower_Destroy");
			Destroy (gameObject);
		}
	}

	IEnumerator MistEstThug(){
		anim.SetLayerWeight(3, 1);
		anim.SetBool ("Punch", true);
		yield return new WaitForSeconds (timeBeforeFall);
		rbObject.AddForce (new Vector3 (0, 0, thugForce));
		//print ("Die! Pot de fleur");
	}

	IEnumerator MistEstThugGauche(){
		anim.SetLayerWeight(3, 1);
		anim.SetBool ("Punch", true);
		yield return new WaitForSeconds (timeBeforeFall);
		rbObject.AddForce (new Vector3 (0, 0, -thugForce));
		//print ("Die! Pot de fleur");
	}
}
