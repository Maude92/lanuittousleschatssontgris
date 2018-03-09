using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbox_Controls_MAC : MonoBehaviour {

	public float PlayerMovementSpeed = 30;
	public float PlayerRotationSpeed = 180;

	public int jumpforce = 100;
//Peut-être cette variable :
	public bool isjumping;

	public GameObject mistObj;
	public Transform camera;
	//public GameObject cubeGroundObj;

	CubeGrounded cubegrounded;

	Rigidbody rb;
	Animator animatorMist;

	//public GameObject camera;

//Genre toutes les variables qui ici jusqu'au Start
	//Lumping
	public float longueurRay = 0.8f;
	public float longueurRayBas = 5.1f;
	private RaycastHit hit;
	private RaycastHit hit2;
	private RaycastHit hit3;

	public GameObject LumpHaut; //n'est plus utile
	public GameObject LumpBas; //n'est plus utile

	//Pour tester le Falling
	public GameObject FallingTete; // C'est un GameObject vide qui va falloir lié. Il remplace LumpHaut. Il est sur la TETE du chat, un peu en hauteur
	public GameObject FallingCul; // C'est un GameObject vide qui va falloir lié. Il remplace LumpBas. Il est sur le CUL du chat, un peu en hauteur
	public bool isFalling = false;
	public bool ToucheSol;

	public bool JeCours = false;
	public bool isLerping = false;
	public bool canLerp = false;



//	//Variables Lerp Test
	public float lerpTime = 1f;
	public float currentLerpTime;

	public float moveDistance = 10f;
	public float LumpForce;

	public float Distance;
	public float DistanceBas;

	Vector3 startPos;
	Vector3 endPos;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
		animatorMist = mistObj.GetComponent <Animator> ();
		cubegrounded = GetComponent <CubeGrounded> ();

		//Pour Lump
		LumpHaut.SetActive (false); //N'est plus utile
		LumpBas.SetActive (false); //N'est plus utile

		//Pour Lump test
		//startPos = mistObj.transform.position;
		//endPos = LumpHaut.transform.position + transform.up * moveDistance;
		//endPos = hit + transform.up * moveDistance;
	}

	void FixedUpdate(){
		Movement ();
//Ça c'est très important
		startPos = mistObj.transform.position;

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

//Tout ce qui est ici est très important
		//Pour animation TOMBER
		//RayCast pour Falling Test (TETE et CUL)
		Debug.DrawRay (FallingTete.transform.position, -transform.up * longueurRay, Color.red);
		Debug.DrawRay (FallingCul.transform.position, -transform.up * longueurRay, Color.blue);

		if (Physics.Raycast (FallingTete.transform.position, -transform.up, out hit, longueurRay, LayerMask.GetMask ("Ground")) && Physics.Raycast (FallingCul.transform.position, -transform.up, out hit, longueurRay, LayerMask.GetMask ("Ground"))) {
			ToucheSol = true;
			isFalling = false;
			animatorMist.SetBool ("IsFalling", false);
			//animatorMist.SetBool ("Grounded", true);

		} else {
			isFalling = true;
			ToucheSol = false;
		}
			
		if (isFalling == true && ToucheSol == false && isjumping == false){
			//rb.AddForce (0, -5, 2);
			animatorMist.SetBool ("IsFalling", true);
			//animatorMist.SetBool ("Grounded", false);
		}

		if (isjumping == true) {
			isFalling = false;
			ToucheSol = false;
			animatorMist.SetBool ("IsFalling", false);
			//animatorMist.SetBool ("Grounded", true);
		}
			

		//Pour Lump Bas
		//DistanceBas = hit2.transform.position.y - hit3.transform.position.y;
//Jusqu' à ici, ce qui est en dessous c'est juste des tests qui fonctionnaient pas pour les Lump Haut

	//Pour Lump Haut V-LF
	//Distance = hit.transform.position.y - hit2.transform.position.y;

		//Test A
//		if (Distance <= 0.25f && Distance > 0) {
//			rb.AddForce (0, LumpForce, -10);
//			print ("ta mère en short");
//		}

		//Test B
//		if (Distance > 0.1f) {
//			animatorMist.SetTrigger ("Jump");
//			animatorMist.SetBool ("Grounded", false);
//			rb.velocity = new Vector3 (0, 2.5f, 0);
//			rb.AddForce (0, 0, 15);
//		}

		//Test C
//		if (DistanceBas > 0.1f) {
//			print ("Ta mère en short vers le bas");
//			animatorMist.SetTrigger ("Jump");
//			animatorMist.SetBool ("IsFalling", true);
//			rb.velocity = new Vector3 (0, 2.5f, 0);
//			rb.AddForce (0, 0, 15);
//		}

		//Si on tombe
//		if (cubegrounded.isGrounded == false){
//			animatorMist.SetBool ("IsFalling", true);
//		}

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

//Ok ici il y a du stock très important, mais attention à ce que tu ais les bon boutons (Input), ignore les commentaires
	// LUMP et course
		if (Input.GetAxis ("XbOne_LeftTrigger") > 0.001 || Input.GetAxis ("XbOne_RightTrigger") < -0.001) {
			print ("Je pèse sur le trigger gauche!!");
			PlayerMovementSpeed = 4;
			jumpforce = 240;
			JeCours = true;
			animatorMist.SetBool ("IsLumping", true); //IsLumping = animation courrir
			if (Input.GetAxis ("XbOne_LeftTrigger") > 0.001) {
				//LumpHaut.SetActive (true);

				//RAYCAST Version LF
				//RayCast LumpHaut
//				Physics.Raycast (LumpHaut.transform.position, -transform.up, out hit, longueurRay, LayerMask.GetMask ("Ground"));
//				Debug.DrawRay (LumpHaut.transform.position, -transform.up * longueurRay, Color.red);

				//RayCast PositionMist
//				Physics.Raycast (transform.position + new Vector3 (0, 0.5f, 0), -transform.up, out hit2, longueurRay, LayerMask.GetMask("Ground"));
//				Debug.DrawRay (transform.position, -transform.up * longueurRay, Color.yellow);

//				//Ancien RayCast pour Lump Version A-B-C
//				if (Physics.Raycast (LumpHaut.transform.position, -transform.up, out hit, longueurRay, LayerMask.GetMask ("Ground"))) {		// je vais chercher la position du transform sur lequel l'objet est		//origine, direction, maxdistance
//					print ("On touche à : " + hit.transform.name);										// out = va mettre des infos dans la variable hit, va affecter des valeurs à hit												// out : La variable doit absolument être privée et qu'elle n'est pas de valeur déjà assignée
//					print ("JE TOUCHE À UN OBJET SUR LEQUEL JE PEUX FAIRE UN LERP");
//					endPos = new Vector3 (hit.transform.position.x, hit.transform.position.y + longueurRay, hit.transform.position.z);
//					if (hit.transform.tag == "Lump") {
//						canLerp = true;
//					}
//				}

//				Ancienne méthode de Lump
				//if (canLerp == true && isLerping == false) {
//
//					//Méthode C.2 :
//					//LumpUP ();
//
//					//Méthode A:
//					rb.AddForce (0, LumpForce, 10);
//					animatorMist.SetTrigger ("Jump");
//					animatorMist.SetBool ("Grounded", false);
//					isLerping = true;
//
//					//Méthode B:
//					//StartCoroutine (JumpMistRoutine ());
//					// isLerping = true;
//
//					//Méthode C:
////					isLerping = false;
////					//increment timer once per frame
////					currentLerpTime += Time.deltaTime;
////					if (currentLerpTime > lerpTime) {
////						currentLerpTime = lerpTime;
////					}
////
////					//lerp!
////					//		float perc = currentLerpTime / lerpTime;
////					//		transform.position = Vector3.Lerp(startPos, endPos, perc);
////					float t = currentLerpTime / lerpTime;
////					//		t = Mathf.Sin(t * Mathf.PI * 0.5f);
////					//		t = t*t*t * (t * (6f*t - 15f) + 10f);
////					t = t * t;
////					transform.position = Vector3.Lerp (startPos, endPos, t);
////
////				} else if (isLerping == false) {
////					currentLerpTime = 0f;
////				}
//
//					//Pour méthode A et B
//			
//
//				} else if (isLerping == true) {  //PENSE ICI LE PROB DU VOL
//					canLerp = false;
//					isLerping = false;
//				}
			}
				if (Input.GetAxis ("XbOne_RightTrigger") < -0.001) {
					//LumpBas.SetActive (true);
					//RAYCAST vers le Bas
					//RayCast LumpBas
//					Physics.Raycast (LumpBas.transform.position, -transform.up, out hit3, longueurRayBas, LayerMask.GetMask ("Ground"));
//					Debug.DrawRay (LumpBas.transform.position, -transform.up * longueurRayBas, Color.blue);
//
//					//RayCast PositionMist
//					Physics.Raycast (transform.position + new Vector3 (0, 0.5f, 0), -transform.up, out hit2, longueurRay, LayerMask.GetMask("Ground"));
//					Debug.DrawRay (transform.position, -transform.up * longueurRay, Color.yellow);
				}
			} else if (Input.GetAxis ("XbOne_LeftTrigger") < 0.001 || Input.GetAxis ("XbOne_RightTrigger") > -0.001) {
				PlayerMovementSpeed = 2;
				jumpforce = 220;
				JeCours = false;
				animatorMist.SetBool ("IsLumping", false);
				Distance = 0;
				if (Input.GetAxis ("XbOne_LeftTrigger") < 0.001) {
					LumpHaut.SetActive (false);
				}
				if (Input.GetAxis ("XbOne_RightTrigger") > -0.001) {
					LumpBas.SetActive (false);
				}
			}

			if (Input.GetAxis ("XbOne_RightTrigger") < -0.001 && Input.GetAxis ("XbOne_LeftTrigger") > 0.001) {
				PlayerMovementSpeed = 2;
				jumpforce = 220;
				LumpHaut.SetActive (false);
				LumpBas.SetActive (false);
				JeCours = false;
				animatorMist.SetBool ("IsLumping", false);
			}
//Jusqu'à ici environ. Il y a certains trucs que tu devais déjà avoir, mais mieux vaut revérifier au cas où			

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

//Je crois pas avoir changer des trucs là dedans, mais mieux vaut vérifier quand même.
	IEnumerator JumpMistRoutine(){
		isjumping = true;
		animatorMist.SetTrigger ("Jump");
		animatorMist.SetBool ("Grounded", false);
		yield return new WaitForSeconds (0.01f);
		cubegrounded.isGrounded = false;
		rb.AddForce (new Vector3 (0, jumpforce, 0));
		isjumping = false;
	}

//	void LumpUP (){
//		print ("Je Lump vers le haut ! Wouhou !");
//		isLerping = true;
//		if (isLerping == true) {
//			//Méthode C:
//			isLerping = false;
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
//
//		} else if (isLerping == false) {
//			currentLerpTime = 0f;
//		}
//	}
//
//	void LumpDown (){
//		print ("Je Lump vers le bas ! Wouhou !");
//	}
}
