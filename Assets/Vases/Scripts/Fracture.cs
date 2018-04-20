using UnityEngine;
using System.Collections;

public class Fracture : MonoBehaviour {
	private AudioManager audioManager;

	public Transform parts;
    private Transform breakable = null;

	public GameObject fallingobject;
	public GameObject mistObj;

	public float timeBeforeFall = 0.2f;
	public float thugForce = 200f;

	Animator anim;
	Rigidbody rbObject;


	void Start () {
		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");
		}

		anim = mistObj.GetComponent<Animator> ();
		rbObject = fallingobject.GetComponent<Rigidbody> ();
	}


	void OnTriggerEnter /*Stay*/ (Collider other){
		if (other.gameObject.tag == "Player" && gameObject.tag == "FallingObjectDroite" /*&& Input.GetButtonDown("XbOne_YButton")*/) {
			audioManager.PlaySound ("Flower_Woosh");
			StartCoroutine (MistEstThugGauche());
		} 
		if (other.gameObject.tag == "Player" && gameObject.tag == "FallingObjectGauche" /*&& Input.GetButtonDown("XbOne_YButton")*/) {
			audioManager.PlaySound ("Flower_Woosh");
			StartCoroutine (MistEstThug());
		}
	}


    private void OnCollisionEnter(Collision collision)
	{

		Vector3 velocity = transform.GetComponent<Rigidbody> ().velocity;
        
//      if (velocity.magnitude < 2.0f) return;
//		if (breakable) return;
		if (collision.gameObject.tag == "Solide" || collision.gameObject.tag == "Gazon") {
			
			breakable = (Transform)Instantiate (parts, transform.position, transform.rotation); 
		//breakable.localScale = transform.localScale;

		foreach (Transform part in breakable) {
			part.gameObject.GetComponent<Renderer> ().materials [1].CopyPropertiesFromMaterial (gameObject.GetComponent<Renderer> ().material);
			if (!part.gameObject.GetComponent<Rigidbody> ()) {
				part.gameObject.AddComponent<Rigidbody> ();
				part.gameObject.GetComponent<Rigidbody> ().velocity = velocity;
			}
			if (!part.gameObject.GetComponent<MeshCollider> ()) {
				part.gameObject.AddComponent<MeshCollider> ();
				part.gameObject.GetComponent<MeshCollider> ().convex = true;
			}

			float time = Random.Range (5f, 30f);
			Destroy (part.gameObject, time);
		}

		Destroy (breakable.gameObject, 30f);
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
