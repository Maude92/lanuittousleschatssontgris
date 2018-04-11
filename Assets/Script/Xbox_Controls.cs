using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbox_Controls : MonoBehaviour {
	
	public float PlayerMovementSpeed = 30;
	public float PlayerRotationSpeed = 180;

	public float walkSpeed;
	public float runSpeed;

	public int jumpforce = 100;

	public bool isjumping;
	//public bool jesaute;

	public GameObject mistObj;
	public Transform camera;
	//public GameObject cubeGroundObj;

	CubeGrounded cubegrounded;

	Rigidbody rb;
	Animator animatorMist;

	//ANCIENNE VERSION
	//Lumping test 
//	public float longueurRay = 0.8f;
//	private RaycastHit hit;	
//	public GameObject LumpHaut;
//	public GameObject LumpBas;
//	public bool JeLump = false;


// LES NOUVEAUTÉS DE FÉLIX
	//Genre toutes les variables qui ici jusqu'au Start
	//Lumping
	public float longueurRay = 0.8f;
	public float longueurRayBas = 5.1f;
	private RaycastHit hit;
	private RaycastHit hit2;
	private RaycastHit hit3;

	//public GameObject LumpHaut; //n'est plus utile
	//public GameObject LumpBas; //n'est plus utile

	//Pour tester le Falling
	public GameObject FallingTete; // C'est un GameObject vide qui va falloir lié. Il remplace LumpHaut. Il est sur la TETE du chat, un peu en hauteur
	public GameObject FallingCul; // C'est un GameObject vide qui va falloir lié. Il remplace LumpBas. Il est sur le CUL du chat, un peu en hauteur
	public bool isFalling = false;
	public bool ToucheSol;

	public bool JeCours = false;
	public bool isLerping = false;
	public bool canLerp = false;

	//public float LumpForce;

	//public float Distance;
	//public float DistanceBas;

	//Variables Lerp Test
	//public float lerpTime = 1f;
	//public float currentLerpTime;

	//public float moveDistance = 10f;

	Vector3 startPos;
	Vector3 endPos;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
		animatorMist = mistObj.GetComponent <Animator> ();
		cubegrounded = GetComponent <CubeGrounded> ();

		//Pour Lump
		//LumpHaut.SetActive (false); //N'est plus utile
		//LumpBas.SetActive (false); //N'est plus utile

		//jesaute = false;

	}

	void FixedUpdate(){
		Movement ();

		//Ça c'est très important
		startPos = mistObj.transform.position;
	}

	// Update is called once per frame
	void Update () {
		
		//rb.velocity = new Vector3(0,0,5);
		UserInputs ();
		animatorMist.SetFloat ("Speed2", Mathf.Abs (Input.GetAxis ("Horizontal")));
		animatorMist.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Vertical")));


	// NOUVEAUTÉS DE FÉLIX!!
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
	// FIN DES NOUVEAUTÉS DE FÉLIX


		if (cubegrounded.isGrounded == true) {
			animatorMist.SetBool ("Grounded", true);
			//isjumping = false;
		} else if (cubegrounded.isGrounded == false) {
			animatorMist.SetBool ("Grounded", false);
			//isjumping = true;
		}


	// POUR FAIRE PIVOTER LA TÊTE
		// Tête à gauche
		if (Input.GetAxis ("RightStick") < -0.1f) {
			print ("Allo! Tête à gauche.");
			animatorMist.SetFloat ("TurnG", 1);
		} else
			animatorMist.SetFloat ("TurnG", 0);

		// Tête à droite
		if (Input.GetAxis ("RightStick") > 0.1f) {
			print ("Allo! Tête à droite.");
			animatorMist.SetFloat ("TurnD", 1);
		} else
			animatorMist.SetFloat ("TurnD", 0);

		// Tête en haut
		if (Input.GetAxis ("RightStickY") > 0.1f) {
			print ("Allo! Tête en haut.");
			animatorMist.SetFloat ("TurnU", 1);
		} else 
			animatorMist.SetFloat ("TurnU", 0);

	}


	void Movement(){
		// Partie Cristelle
//		if(Input.GetAxis("Vertical")>0){
//			transform.forward = camera.transform.forward;
//		}
		Vector3 forward = Vector3.Scale(camera.forward, new Vector3(1, 0, 1)).normalized;
		float v = Input.GetAxis ("Vertical") * Time.deltaTime  * PlayerMovementSpeed;			//float v = Input.GetAxis ("Vertical")  * PlayerMovementSpeed;
																								//float h = Input.GetAxis ("Horizontal")  * PlayerMovementSpeed;
		float h = Input.GetAxis ("Horizontal") * Time.deltaTime * PlayerMovementSpeed;

		Vector3 move = v * forward + h * camera.right;

		// Cette ligne est pour le vertical movement, en ce moment c'est sur l'axe Z
		//transform.Translate (move, Space.World);
		//rb.velocity = move * PlayerMovementSpeed;
		rb.velocity = new Vector3 (move.x * PlayerMovementSpeed, rb.velocity.y, move.z * PlayerMovementSpeed);

																								//rb.velocity = new Vector3 (move.x, rb.velocity.y, move.z);
		// Cette ligne est pour le horizontal movement, en ce moment c'est sur l'axe X. When combined with vertical movement it can be used for Strafing
		//transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMovementSpeed, 0, 0);
		if (move.magnitude > 0) {
			transform.forward = Vector3.RotateTowards(transform.forward, move.normalized, Time.deltaTime * PlayerRotationSpeed, 0);
		}

		// VERSION CRISTELLE transform.Rotate (0 , 2 * Input.GetAxis("Horizontal"), 0 );

		// Pour rotater la cam
		//transform.Rotate(0, Input.GetAxis ("RightStick") * Time.deltaTime * PlayerRotationSpeed, 0);
	}



	void UserInputs(){
	
		// Bouton A (joystick button 0)
		if (Input.GetButtonDown ("360_AButton") && cubegrounded.isGrounded == true && isjumping == false){
			print ("Je pèse sur: le bouton A!");
			//jesaute = true;
				//animatorMist.SetTrigger ("Jump");
				//animatorMist.SetBool ("Grounded", false);
				StartCoroutine (JumpMistRoutine ());
				//Invoke ("JumpMist", 0.23f);																	// WARNING BOGUE!!!
		}
			
		// Bouton B (joystick button 1)
		if (Input.GetButtonDown ("360_BButton")){
			print ("Je pèse sur: le bouton B!");
		}

		// Bouton X (... 2)
		if (Input.GetButtonDown ("360_XButton")){
			print ("Je pèse sur: le bouton X!");
		}

		// Bouton Y (... 3)
		if (Input.GetButtonDown ("360_YButton")){
			print ("Je pèse sur: le bouton Y!");
		}

		// Left Bumper (... 4)
//		if (Input.GetButtonDown ("360_LeftBumper")){
//			print ("Je pèse sur: left bumper!");
//		}

		// Right bumper (... 5)
//		if (Input.GetButtonDown ("360_RightBumper")){
//			print ("Je pèse sur: right bumper!");
//		}

		// Back button (... 6)
		if (Input.GetButtonDown ("360_BackButton")){
			print ("Je pèse sur: back button!");
		}

		// Start button (... 7)
		if (Input.GetButtonDown ("360_StartButton")){
			print ("Je pèse sur: start button!");
		}

		// Left Thumbstick (... 8)
		if (Input.GetButtonDown ("360_LeftThumbstickButton")){
			print ("Je pèse sur: left thumbstick button!");
		}

		// Right thumbstick (... 9)
		if (Input.GetButtonDown ("360_RightThumbstickButton")){
			print ("Je pèse sur: right thumbstick button!");
		}

		//Trigger gauche (L)
//		if (Input.GetAxis ("360_TriggerL")> 0.001){
//			//print ("Je pèse sur le trigger gauche!!");
//		}

//		if (Input.GetAxis ("360_TriggerR") > 0.001) {
//			//print ("Je pèse sur le trigger droit!!");
//		}


		// The D-PAD is read from the 6th (horizontal) and 7th (vertical) joystick axes and from a sensitivity rating from -1 to 1, similar to the Triggers
		//RIGHT d-pad button is activated when pressure is above 0, or the dead zone
		if (Input.GetAxis ("360_HorizontalDPAD")>0.001){
			print ("Right D-PAD button!");
		}
		// LEFT d-pad....
		if(Input.GetAxis ("360_HorizontalDPAD")<0){
			print ("Left D-PAD button!");
		}
		// UP d-pad...
		if (Input.GetAxis("360_VerticalDPAD")>0.001){
			print ("Up D-PAD button!");
		}
		// DOWN d-pad...
		if (Input.GetAxis("360_VerticalDPAD")<0){
			print ("Down D-PAD button!");
		}


		// LUMP ET COURSE!!

		//Trigger gauche (L)
//		if (Input.GetAxis ("360_TriggerL")> 0.001){
//			print ("Je pèse sur le trigger gauche!!");
//			PlayerMovementSpeed = 4;
//			LumpHaut.SetActive (true);
//			JeLump = true;
//			animatorMist.SetBool ("IsLumpingG", true);
//		} else if (Input.GetAxis ("360_TriggerL") < 0.001) {
//			PlayerMovementSpeed = 2;
//			animatorMist.SetBool ("IsLumpingG", false);
//			LumpHaut.SetActive (false);
//			JeLump = false;
//		}


		//Trigger droite (R)
		if (Input.GetAxis ("360_TriggerR") > 0.001 || Input.GetAxis ("360_TriggerL") > 0.001) {
			print ("Je pèse sur le trigger droit!!");
			PlayerMovementSpeed = runSpeed;
			jumpforce = 240;
			//LumpBas.SetActive (true);
			//JeLump = true;
			JeCours = true;
			animatorMist.SetBool ("IsLumping", true); //Is Lumping = animation courir
//			if (Input.GetAxis ("360_TriggerR") > 0.001) {
//				//LumpBas.SetActive (true);
//			}
//			if (Input.GetAxis ("360_TriggerL") > 0.001) {
//				//LumpHaut.SetActive (true);
//			}
		} else if (Input.GetAxis ("360_TriggerR") < 0.001 || Input.GetAxis ("360_TriggerL") < 0.001) {
			PlayerMovementSpeed = walkSpeed;
			jumpforce = 220;
			JeCours = false;
			animatorMist.SetBool ("IsLumping", false);
			//Distance = 0;
			//LumpBas.SetActive (false);
			//JeLump = false;
//			if (Input.GetAxis ("360_TriggerR") < 0.001) {
//				//LumpBas.SetActive (false);
//			}
//			if (Input.GetAxis ("360_TriggerL") < 0.001) {
//				//LumpHaut.SetActive (false);
//			}
		}

			
//		if (Input.GetAxis ("360_TriggerR") > 0.001 && Input.GetAxis ("360_TriggerL")> 0.001) {
//			LumpHaut.SetActive (false);
//			LumpBas.SetActive (false);
//			JeLump = false;
//		}

	}

//	void JumpMist(){
//		rb.AddForce (new Vector3 (0, jumpforce, 0));
//	}

	IEnumerator JumpMistRoutine(){
		isjumping = true;
		animatorMist.SetTrigger ("Jump");
		//animatorMist.SetBool ("Grounded", false);
		yield return new WaitForSeconds (0.115f);	// Version Félix: 0.01f
		cubegrounded.isGrounded = false;
		rb.AddForce (new Vector3 (0, jumpforce, 0));
		yield return new WaitForSeconds (0.5f);
		isjumping = false;
	}

//	void LumpUP (){
//		print ("Je Lump vers le haut ! Wouhou !");
//	}
//
//	void LumpDown (){
//		print ("Je Lump vers le bas ! Wouhou !");
//	}



//	// TEST POUR LA QUEUE QUI BOUGE QUAND EN ÉQUILIBRE
//	void OnTriggerStay (Collider other){
//		if (Input.GetButton ("360_LeftBumper") && other.gameObject.tag == "Balancing") {
//			print ("Je pèse sur: left bumper pis je suis sur un objet balancing!");
//			//animatorMist.SetBool ("TailG", true);
//		} 
////		else{
////			animatorMist.SetBool ("TailG", false);
////	}
//
//		if (Input.GetButton ("360_RightBumper") && other.gameObject.tag == "Balancing") {
//			print ("Je pèse sur: right bumper pis je suis sur un objet balancing!");
//			//animatorMist.SetBool ("TailD", true);
//		} 
////		else {
////			animatorMist.SetBool ("TailD", false);
////		}
//	}

}
