using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbox360_Controls : MonoBehaviour {

	// Pour modifier la vitesse de Mist et la vitesse de rotation

	public float PlayerMovementSpeed = 30;
	public float PlayerRotationSpeed = 180;


	public int jumpforce = 100;
	public GameObject mistObj;
	public Transform groundCheck;
	public Transform catCheck;
	public LayerMask groundLayerMask;
	bool jumped;
	public bool grounded = true;
	bool hasjumped = false;
	public float longueurRay;
	//float jumptime;
	//float jumpdelay = 0.0f;

	Rigidbody rb;
	Animator animatorMist;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
		animatorMist = mistObj.GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		UserInputs ();
		animatorMist.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
		animatorMist.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Vertical")));

		//grounded = Physics.Raycast (catCheck.position, groundCheck.position, groundLayerMask);

		Debug.DrawLine (catCheck.position, groundCheck.position, Color.red);

//		if (Input.GetAxis ("Vertical")) {
//			//animatorMist.SetBool ("isWalking", true);
//
//		} else {
//			
//		}

//		jumptime -= Time.deltaTime;
//		if (jumptime <= 0 && jumped == true) {
//			animatorMist.SetTrigger ("Land");
//			jumped = false;
//		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Ground") {
			grounded = true;
		} 
	}

	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Ground") {
			grounded = false;
		} 
	}

		


	// This function handles the movement calculations. You can adjust the code to work with different AXES is preferred
	// Right Thumbstick use theth (Vertical) and th (Horizontal) Input Joystick Axes, and the Left Thumbstick uses the X (Horizontal) and Y (vertical) Input Joystick axes
	// For movement the Vertical Axis is read from moving the LEFT THUMBSTICK up and down. The Horizontal Axis is read from moving the LEFT THUMBSTICK left and right
	// For Rotation I hava it reading from the RIGHT THUMBSTICK

	// A mettre dans FixedUpdate?
	void Movement(){
	// Cette ligne est pour le vertical movement, en ce moment c'est sur l'axe Z
		transform.Translate (0,0, Input.GetAxis("Vertical") * Time.deltaTime * PlayerMovementSpeed);
	
	// Cette ligne est pour le horizontal movement, en ce moment c'est sur l'axe X. When combined with vertical movement it can be used for Strafing
		transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMovementSpeed, 0, 0);

																										//transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMovementSpeed, 0);

	 //Cette ligne est pour la rotation, en ce moment c'est sur l'axe Y
		transform.Rotate(0, Input.GetAxis ("RightStick") * Time.deltaTime * PlayerRotationSpeed, 0);
	//transform.Rotate (Input.GetAxis ("RightStickY") * Time.deltaTime * PlayerRotationSpeed, 0, 0);


	}


	// This function handles the Inputs from the buttons on the controller

	void UserInputs(){
	
//		if (jumped == true) {
//			animatorMist.SetTrigger ("Land");
//			jumped = false;
//		}
//
		if (grounded == true) {
			animatorMist.SetBool ("Grounded", true);
		}

		// Bouton A (joystick button 0)
		if (Input.GetButtonDown ("360_AButton") && grounded == true){
			print ("Je pèse sur: le bouton A!");
			//jumptime = jumpdelay;
			animatorMist.SetTrigger ("Jump");
			//grounded = false;
			animatorMist.SetBool ("Grounded", false);
			Invoke ("JumpMist", 0.23f);
			//rb.AddForce (new Vector3 (0, jumpforce, 0));
			jumped = true;
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

		// Triggers are read from the 3rd joystick axis and read from a sensitivity rating from -1 to 1
		//

		//Trigger gauche (L)
		if (Input.GetAxis ("360_TriggerL")> 0.001){
			print ("Je pèse sur le trigger gauche!!");
		}

		if (Input.GetAxis ("360_TriggerR") > 0.001) {
			print ("Je pèse sur le trigger droit!!");
		}

		//Right trigger is activated when pressure is above 0, or the dead zone
//		if (Input.GetAxis("360_Triggers")>0.001){
//			print ("Trigger droit!");
//		}
//		// Right trigger is activated when pressure is under 0, or the dead zone
//		if (Input.GetAxis("360_Triggers")<-0.1){
//			print ("Trigger gauche");
//		}
			


		// The D-PAD is read from the 6th (horizontal) and 7th (vertical) joystick axes and from a sensitivity rating from -1 to 1, similar to the Triggers
		//
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

	void JumpMist(){
		rb.AddForce (new Vector3 (0, jumpforce, 0));
	}


}
