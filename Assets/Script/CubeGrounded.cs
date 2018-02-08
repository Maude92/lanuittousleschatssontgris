using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGrounded : MonoBehaviour {

	public float longueurRay = 0.8f;
	private RaycastHit hit;	

	//public GameObject groundCheck;
	//public GameObject player;

	public bool isGrounded;
	public GameObject mistObj;
	Animator animatorMist;

	//public LayerMask groundLayerMask;


	// Use this for initialization
	void Start () {
		animatorMist = mistObj.GetComponent <Animator> ();
	}

//	void FixedUpdate(){
//		Vector3 dwn = transform.TransformDirection (Vector3.down);
//
//		if (Physics.Raycast (transform.position, dwn, 0.5f)) {
//			print ("Je touche à quelque chose avec mon raycast");
//		}
//	}

	// Update is called once per frame
	void FixedUpdate () {

		if (Physics.Raycast (transform.position + new Vector3 (0, 0.5f, 0), -transform.up, out hit, longueurRay, LayerMask.GetMask("Ground"))) {		// je vais chercher la position du transform sur lequel l'objet est		//origine, direction, maxdistance
			print ("On touche à : " + hit.transform.name);										// out = va mettre des infos dans la variable hit, va affecter des valeurs à hit												// out : La variable doit absolument être privée et qu'elle n'est pas de valeur déjà assignée
				print ("JE TOUCHE À DU GROUND!");
				isGrounded = true;
		} else {
			isGrounded = false;
		}		

		Debug.DrawRay (transform.position, -transform.up * longueurRay, Color.green);

		//transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 0.25f, player.transform.position.z);

		//Debug.DrawLine (transform.position, groundCheck.transform.position, Color.red);
		//transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 0.1f, player.transform.position.z);
		//isGrounded = Physics.Raycast (transform.position, groundCheck.transform.position, groundLayerMask);
	}

	void Update(){
		if (isGrounded == true)
			animatorMist.SetBool ("Grounded", true);
	}
}
