using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbox_Controls_MAC : MonoBehaviour {

	public float PlayerMovementSpeed = 30;
	public float PlayerRotationSpeed = 180;

	public int jumpforce = 100;

	public bool isjumping;

	public GameObject mistObj;
	public Transform camera;
	//public GameObject cubeGroundObj;

	CubeGrounded cubegrounded;

	Rigidbody rb;
	Animator animatorMist;

	//public GameObject camera;


	//Lumping test
	public float longueurRay = 0.8f;
	private RaycastHit hit;	

	public GameObject LumpHaut;
	public GameObject LumpBas;

	public bool JeLump = false;
	public bool isLerping = false;

	//Variables Lerp Test
	public float lerpTime = 1f;
	public float currentLerpTime;

	public float moveDistance = 10f;

	Vector3 startPos;
	Vector3 endPos;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
		animatorMist = mistObj.GetComponent <Animator> ();
		cubegrounded = GetComponent <CubeGrounded> ();

		//Pour Lump
		LumpHaut.SetActive (false);
		LumpBas.SetActive (false);

		//Pour Lump test
		startPos = mistObj.transform.position;
		//endPos = LumpHaut.transform.position + transform.up * moveDistance;
		//endPos = hit + transform.up * moveDistance;
	}

	void FixedUpdate(){
		Movement ();

//		//Pour Lump test (LUMP HAUT)
//		//Ce que j'essai de faire = un Raycast qui, s'il va toucher à un objet (ou le vide ?) vers le haut,il va faire sauter le personnage. Mais comment le faire atterir à la bonne place ? Est-ce que c'est le joueur qui controle sa direction jusqu'à son atterrissage ou je dois faire un Lerp ? (entre paranthèse, Lerp ça me fait penser à un son que ferait un chien qui sort dans langue dans un meme, fin de la paranthèse)
//		if (Physics.Raycast (LumpHaut.transform.position, -transform.up, out hit, longueurRay, LayerMask.GetMask("Ground"))) {		// je vais chercher la position du transform sur lequel l'objet est		//origine, direction, maxdistance
//			print ("On touche à : " + hit.transform.name);										// out = va mettre des infos dans la variable hit, va affecter des valeurs à hit												// out : La variable doit absolument être privée et qu'elle n'est pas de valeur déjà assignée
//			print ("JE TOUCHE À UN OBJET SUR LEQUEL JE PEUX FAIRE UN LERP");
//			endPos = hit.transform.position;
//			isLerping = true;
//		} else {
//			isLerping = false;
//		}		
	}

	// Update is called once per frame
	void Update () {
		UserInputs ();
		animatorMist.SetFloat ("Speed2", Mathf.Abs (Input.GetAxis ("Horizontal")));
		animatorMist.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Vertical")));

		// POUR FAIRE PIVOTER LA TÊTE
		// Tête à gauche
		if (Input.GetAxis ("XbOne_RightStickX") < -0.1f) {
			print ("Allo! Tête à gauche.");
			animatorMist.SetFloat ("TurnG", 1);
		} else
			animatorMist.SetFloat ("TurnG", 0);

		// Tête à droite
		if (Input.GetAxis ("XbOne_RightStickX") > 0.1f) {
			print ("Allo! Tête à droite.");
			animatorMist.SetFloat ("TurnD", 1);
		} else
			animatorMist.SetFloat ("TurnD", 0);

		// Tête en haut
		if (Input.GetAxis ("XbOne_RightStickY") > 0.1f) {
			print ("Allo! Tête en haut.");
			animatorMist.SetFloat ("TurnU", 1);
		} else 
			animatorMist.SetFloat ("TurnU", 0);

	}


	void Movement(){
		Vector3 forward = Vector3.Scale(camera.forward, new Vector3(1, 0, 1)).normalized;
		float v = Input.GetAxis ("Vertical") * Time.deltaTime  * PlayerMovementSpeed;			//float v = Input.GetAxis ("Vertical")  * PlayerMovementSpeed;
		//float h = Input.GetAxis ("Horizontal")  * PlayerMovementSpeed;
		float h = Input.GetAxis ("Horizontal") * Time.deltaTime * PlayerMovementSpeed;

		Vector3 move = v * forward + h * camera.right;

		// Cette ligne est pour le vertical movement, en ce moment c'est sur l'axe Z
		transform.Translate (move, Space.World);
		//rb.velocity = new Vector3 (move.x, rb.velocity.y, move.z);
		// Cette ligne est pour le horizontal movement, en ce moment c'est sur l'axe X. When combined with vertical movement it can be used for Strafing
		//transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMovementSpeed, 0, 0);
		if (move.magnitude > 0) {
			transform.forward = Vector3.RotateTowards(transform.forward, move.normalized, Time.deltaTime * PlayerRotationSpeed, 0);
		}
			
	}

	void UserInputs(){

		// Bouton A (joystick button 0)
		if (Input.GetButtonDown ("XbOne_AButton") && cubegrounded.isGrounded == true && isjumping == false) {
			print ("Je pèse sur: le bouton A!");
			StartCoroutine (JumpMistRoutine ());
		}

		// Bouton B (joystick button 1)
		if (Input.GetButtonDown ("XbOne_BButton")) {
			print ("Je pèse sur: le bouton B!");
		}

		// Bouton X (... 2)
		if (Input.GetButtonDown ("XbOne_XButton")) {
			print ("Je pèse sur: le bouton X!");
		}

		// Bouton Y (... 3)
		if (Input.GetButtonDown ("XbOne_YButton")) {
			print ("Je pèse sur: le bouton Y!");
		}

		// Left Bumper (... 4)
		if (Input.GetButtonDown ("XbOne_LeftBumper")) {
			print ("Je pèse sur: left bumper!");
		}

		// Right bumper (... 5)
		if (Input.GetButtonDown ("XbOne_RightBumper")) {
			print ("Je pèse sur: right bumper!");
		}

		// Back button (... 6)
		if (Input.GetButtonDown ("XbOne_BackButton")) {
			print ("Je pèse sur: back button!");
		}

		// Start button (... 7)
		if (Input.GetButtonDown ("XbOne_StartButton")) {
			print ("Je pèse sur: start button!");
		}

		// Left Thumbstick (... 8)
		if (Input.GetButtonDown ("XbOne_LeftStickClick")) {
			print ("Je pèse sur: left thumbstick button!");
		}

		// Right thumbstick (... 9)
		if (Input.GetButtonDown ("XbOne_RightStickClick")) {
			print ("Je pèse sur: right thumbstick button!");
		}

// LUMP et course
		if (Input.GetAxis ("XbOne_LeftTrigger") > 0.001 || Input.GetAxis ("XbOne_RightTrigger") < -0.001) {
			print ("Je pèse sur le trigger gauche!!");
			PlayerMovementSpeed = 4;
			jumpforce = 240;
			JeLump = true;
			animatorMist.SetBool ("IsLumping", true);
			if (Input.GetAxis ("XbOne_LeftTrigger") > 0.001) {
				LumpHaut.SetActive (true);

				//Copier du truc plus haut pour tester ici
				if (Physics.Raycast (LumpHaut.transform.position, -transform.up, out hit, longueurRay, LayerMask.GetMask ("Ground"))) {		// je vais chercher la position du transform sur lequel l'objet est		//origine, direction, maxdistance
					print ("On touche à : " + hit.transform.name);										// out = va mettre des infos dans la variable hit, va affecter des valeurs à hit												// out : La variable doit absolument être privée et qu'elle n'est pas de valeur déjà assignée
					print ("JE TOUCHE À UN OBJET SUR LEQUEL JE PEUX FAIRE UN LERP");
					//endPos = hit.transform.position;
					isLerping = true;
				}

				Debug.DrawRay (LumpHaut.transform.position, -transform.up * longueurRay, Color.red);

				//LumpUP ();
				if (isLerping == true) {
					StartCoroutine (JumpMistRoutine ());
					//isLerping = false;
//					//increment timer once per frame
//					currentLerpTime += Time.deltaTime;
//					if (currentLerpTime > lerpTime) {
//						currentLerpTime = lerpTime;
//					}
//
//					//lerp!
//					//		float perc = currentLerpTime / lerpTime;
//					//		transform.position = Vector3.Lerp(startPos, endPos, perc);
//					float t = currentLerpTime / lerpTime;
//					//		t = Mathf.Sin(t * Mathf.PI * 0.5f);
//					//		t = t*t*t * (t * (6f*t - 15f) + 10f);
//					t = t * t;
//					transform.position = Vector3.Lerp (startPos, endPos, t);
//				} else if (isLerping == false) {
//					currentLerpTime = 0f;
				}
			}
				if (Input.GetAxis ("XbOne_RightTrigger") < -0.001) {
					LumpBas.SetActive (true);
				}
			} else if (Input.GetAxis ("XbOne_LeftTrigger") < 0.001 || Input.GetAxis ("XbOne_RightTrigger") > -0.001) {
				PlayerMovementSpeed = 2;
				jumpforce = 220;
				JeLump = false;
				animatorMist.SetBool ("IsLumping", false);
				if (Input.GetAxis ("XbOne_LeftTrigger") < 0.001) {
					LumpHaut.SetActive (false);
				}
				if (Input.GetAxis ("XbOne_RightTrigger") > -0.001) {
					LumpBas.SetActive (false);
				}
			}

			if (Input.GetAxis ("XbOne_RightTrigger") < -0.001 && Input.GetAxis ("XbOne_LeftTrigger") > 0.001) {
				LumpHaut.SetActive (false);
				LumpBas.SetActive (false);
				JeLump = false;
			}

// ANCIEN LUMP & COURSE
			//Trigger gauche (L)
//		if (Input.GetAxis ("XbOne_LeftTrigger")> 0.001){
//			print ("Je pèse sur le trigger gauche!!");
//			PlayerMovementSpeed = 5;
//			LumpHaut.SetActive (true);
//			JeLump = true;
//			//LumpUP ();
//			animatorMist.SetBool ("IsLumpingG", true);
//		} else if (Input.GetAxis ("XbOne_LeftTrigger") < 0.001) {
//			PlayerMovementSpeed = 2;
//			LumpHaut.SetActive (false);
//			JeLump = false;
//			animatorMist.SetBool ("IsLumpingG", false);
//		}
			

//		//Trigger droite (R)
//		if (Input.GetAxis ("XbOne_RightTrigger") < -0.001) {
//			print ("Je pèse sur le trigger droit!!");
//			PlayerMovementSpeed = 4;
//			LumpBas.SetActive (true);
//			JeLump = true;
//			//LumpDown ();
//			animatorMist.SetBool ("IsLumping", true);
//		} else if (Input.GetAxis ("XbOne_RightTrigger") > -0.001) {
//			PlayerMovementSpeed = 2;
//			LumpBas.SetActive (false);
//			JeLump = false;
//			animatorMist.SetBool ("IsLumping", false);
//		}
			

			//D-PAD Mac
			// UP
			if (Input.GetButtonDown ("XbOne_DPadUp")) {
				print ("Je pèse sur: le bouton UP du D-PAD!");
			}

			// Down
			if (Input.GetButtonDown ("XbOne_DPadDown")) {
				print ("Je pèse sur: le bouton Down du D-PAD!");
			}

			// Left
			if (Input.GetButtonDown ("XbOne_DPadLeft")) {
				print ("Je pèse sur: le bouton Left du D-PAD!");
			}

			// Right
			if (Input.GetButtonDown ("XbOne_DPadRight")) {
				print ("Je pèse sur: le bouton Right du D-PAD!");
			}

			//Xbox Button
			if (Input.GetButtonDown ("XbOne_XboxButton")) {
				print ("Je pèse sur: le bouton Xbox!");
			}
		}

	IEnumerator JumpMistRoutine(){
		isLerping = false;
		isjumping = true;
		animatorMist.SetTrigger ("Jump");
		animatorMist.SetBool ("Grounded", false);
		yield return new WaitForSeconds (0.23f);
		cubegrounded.isGrounded = false;
		rb.AddForce (new Vector3 (0, jumpforce, 0));
		isjumping = false;
	}

//	void LumpUP (){
//		print ("Je Lump vers le haut ! Wouhou !");
//		if (isLerping == true) {
//			//increment timer once per frame
//			currentLerpTime += Time.deltaTime;
//			if (currentLerpTime > lerpTime) {
//				currentLerpTime = lerpTime;
//			}
//
//			//lerp!
//			//		float perc = currentLerpTime / lerpTime;
//			//		transform.position = Vector3.Lerp(startPos, endPos, perc);
//			float t = currentLerpTime / lerpTime;
//			//		t = Mathf.Sin(t * Mathf.PI * 0.5f);
//			//		t = t*t*t * (t * (6f*t - 15f) + 10f);
//			t = t * t;
//			transform.position = Vector3.Lerp (startPos, endPos, t);
//		} else if (isLerping == false) {
//			currentLerpTime = 0f;
//		}
//	}
//
//	void LumpDown (){
//		print ("Je Lump vers le bas ! Wouhou !");
//	}
}
