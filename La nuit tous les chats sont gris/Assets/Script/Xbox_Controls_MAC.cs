using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbox_Controls_MAC : MonoBehaviour {

	public float PlayerMovementSpeed = 30;
	public float PlayerRotationSpeed = 180;

	public int jumpforce = 100;

	public GameObject mistObj;
	public GameObject cubeGroundObj;

	CubeGrounded cubegrounded;

	Rigidbody rb;
	Animator animatorMist;

	public GameObject camera;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
		animatorMist = mistObj.GetComponent <Animator> ();
		cubegrounded = cubeGroundObj.GetComponent <CubeGrounded> ();
	}

	void FixedUpdate(){
		Movement ();
	}

	// Update is called once per frame
	void Update () {
		UserInputs ();
		animatorMist.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
		animatorMist.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Vertical")));
	}


	void Movement(){
		// Partie Cristelle
		//		if(Input.GetAxis("Vertical")>0){
		//			transform.forward = camera.transform.forward;
		//		}

		// Cette ligne est pour le vertical movement, en ce moment c'est sur l'axe Z
		transform.Translate (0, 0, Input.GetAxis ("Vertical") * Time.deltaTime * PlayerMovementSpeed);

		// Cette ligne est pour le horizontal movement, en ce moment c'est sur l'axe X. When combined with vertical movement it can be used for Strafing
		transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMovementSpeed, 0, 0);
		transform.Rotate (0, Input.GetAxis ("Horizontal") * Time.deltaTime * PlayerRotationSpeed, 0);
		// VERSION CRISTELLEtransform.Rotate (0 , 2 * Input.GetAxis("Horizontal"), 0 );
	}

	void UserInputs(){

		// Bouton A (joystick button 0)
		if (Input.GetButtonDown ("XbOne_AButton")){
			print ("Je pèse sur: le bouton A!");
			animatorMist.SetTrigger ("Jump");
			animatorMist.SetBool ("Grounded", false);
			Invoke ("JumpMist", 0.23f);
		}

		// Bouton B (joystick button 1)
		if (Input.GetButtonDown ("XbOne_BButton")){
			print ("Je pèse sur: le bouton B!");
		}

		// Bouton X (... 2)
		if (Input.GetButtonDown ("XbOne_XButton")){
			print ("Je pèse sur: le bouton X!");
		}

		// Bouton Y (... 3)
		if (Input.GetButtonDown ("XbOne_YButton")){
			print ("Je pèse sur: le bouton Y!");
		}

		// Left Bumper (... 4)
		if (Input.GetButtonDown ("XbOne_LeftBumper")){
			print ("Je pèse sur: left bumper!");
		}

		// Right bumper (... 5)
		if (Input.GetButtonDown ("XbOne_RightBumper")){
			print ("Je pèse sur: right bumper!");
		}

		// Back button (... 6)
		if (Input.GetButtonDown ("XbOne_BackButton")){
			print ("Je pèse sur: back button!");
		}

		// Start button (... 7)
		if (Input.GetButtonDown ("XbOne_StartButton")){
			print ("Je pèse sur: start button!");
		}

		// Left Thumbstick (... 8)
		if (Input.GetButtonDown ("XbOne_LeftStickClick")){
			print ("Je pèse sur: left thumbstick button!");
		}

		// Right thumbstick (... 9)
		if (Input.GetButtonDown ("XbOne_RightStickClick")){
			print ("Je pèse sur: right thumbstick button!");
		}

		//Trigger gauche (L)
		if (Input.GetAxis ("XbOne_LeftTrigger")> 0.001){
			print ("Je pèse sur le trigger gauche!!");
		}

		//Trigger doirte (R)
		if (Input.GetAxis ("XbOne_RightTrigger") < -0.001) {
			print ("Je pèse sur le trigger droit!!");

		}

		print (Input.GetAxis("XbOne_RightTrigger"));

		//		// The D-PAD is read from the 6th (horizontal) and 7th (vertical) joystick axes and from a sensitivity rating from -1 to 1, similar to the Triggers
		//		//RIGHT d-pad button is activated when pressure is above 0, or the dead zone
		//		if (Input.GetAxis ("360_HorizontalDPAD")>0.001){
		//			print ("Right D-PAD button!");
		//		}
		//		// LEFT d-pad....
		//		if(Input.GetAxis ("360_HorizontalDPAD")<0){
		//			print ("Left D-PAD button!");
		//		}
		//		// UP d-pad...
		//		if (Input.GetAxis("360_VerticalDPAD")>0.001){
		//			print ("Up D-PAD button!");
		//		}
		//		// DOWN d-pad...
		//		if (Input.GetAxis("360_VerticalDPAD")<0){
		//			print ("Down D-PAD button!");
		//		}

		//D-PAD Mac
		// UP
		if (Input.GetButtonDown ("XbOne_DPadUp")){
			print ("Je pèse sur: le bouton UP du D-PAD!");
		}

		// Down
		if (Input.GetButtonDown ("XbOne_DPadDown")){
			print ("Je pèse sur: le bouton Down du D-PAD!");
		}

		// Left
		if (Input.GetButtonDown ("XbOne_DPadLeft")){
			print ("Je pèse sur: le bouton Left du D-PAD!");
		}

		// Right
		if (Input.GetButtonDown ("XbOne_DPadRight")){
			print ("Je pèse sur: le bouton Right du D-PAD!");
		}

		//Xbox Button
		if (Input.GetButtonDown ("XbOne_XboxButton")){
			print ("Je pèse sur: le bouton Xbox!");
		}
	}

	void JumpMist(){
		rb.AddForce (new Vector3 (0, jumpforce, 0));
	}
}
