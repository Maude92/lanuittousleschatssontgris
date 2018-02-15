using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbox_Controls : MonoBehaviour {

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

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
		animatorMist = mistObj.GetComponent <Animator> ();
		cubegrounded = GetComponent <CubeGrounded> ();
	}

	void FixedUpdate(){
		Movement ();
	}

	// Update is called once per frame
	void Update () {
		UserInputs ();
		animatorMist.SetFloat ("Speed2", Mathf.Abs (Input.GetAxis ("Horizontal")));
		animatorMist.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Vertical")));

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
		transform.Translate (move, Space.World);
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
		if (Input.GetButtonDown ("360_LeftBumper")){
			print ("Je pèse sur: left bumper!");
		}

		// Right bumper (... 5)
		if (Input.GetButtonDown ("360_RightBumper")){
			print ("Je pèse sur: right bumper!");
		}

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
		if (Input.GetAxis ("360_TriggerL")> 0.001){
			print ("Je pèse sur le trigger gauche!!");
		}

		if (Input.GetAxis ("360_TriggerR") > 0.001) {
			print ("Je pèse sur le trigger droit!!");
		}

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
	}

//	void JumpMist(){
//		rb.AddForce (new Vector3 (0, jumpforce, 0));
//	}

	IEnumerator JumpMistRoutine(){
		isjumping = true;
		animatorMist.SetTrigger ("Jump");
		//animatorMist.SetBool ("Grounded", false);
		yield return new WaitForSeconds (0.115f);
		cubegrounded.isGrounded = false;
		rb.AddForce (new Vector3 (0, jumpforce, 0));
		yield return new WaitForSeconds (0.5f);
		isjumping = false;
	}

}
