using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumpHaut_Code : MonoBehaviour {

// Variables 
	//RayCast
	public float longueurRay = 0.8f;
	private RaycastHit hit;	

	public bool isGrounded;
	public GameObject mistObj;
	Animator animatorMist;

	Rigidbody rb;

	public bool isLerping;

	//Variables Lerp Test
	public float lerpTime = 1f;
	public float currentLerpTime;

	public float moveDistance = 10f;

	Vector3 startPos;
	Vector3 endPos;

	// Use this for initialization
	void Start () {
		animatorMist = mistObj.GetComponent <Animator> ();
		rb = GetComponent <Rigidbody> ();
		startPos = mistObj.transform.position;
		//endPos = (transform.position + 200) + transform.up * moveDistance;
	}

	void FixedUpdate () {

		//Ce que j'essai de faire = un Raycast qui, s'il va toucher à un objet (ou le vide ?) vers le haut,il va faire sauter le personnage. Mais comment le faire atterir à la bonne place ? Est-ce que c'est le joueur qui controle sa direction jusqu'à son atterrissage ou je dois faire un Lerp ? (entre paranthèse, Lerp ça me fait penser à un son que ferait un chien qui sort dans langue dans un meme, fin de la paranthèse)
		if (Physics.Raycast (transform.position + new Vector3 (0, 0.5f, 0), transform.up, out hit, longueurRay, LayerMask.GetMask("Vide"))) {		// je vais chercher la position du transform sur lequel l'objet est		//origine, direction, maxdistance
			print ("On touche à : " + hit.transform.name);										// out = va mettre des infos dans la variable hit, va affecter des valeurs à hit												// out : La variable doit absolument être privée et qu'elle n'est pas de valeur déjà assignée
			print ("JE TOUCHE À DU VIDE!");
			isLerping = true;
		} else {
			isLerping = false;
		}		

		Debug.DrawRay (transform.position, transform.up * longueurRay, Color.red);
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
