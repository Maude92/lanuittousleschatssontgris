using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbox_Controls_Balancing : MonoBehaviour {

	public float PlayerMovementSpeed = 30;
	public float PlayerRotationSpeed = 180;

	public int jumpforce = 100;

	public bool isjumping;

	public GameObject mistObj;
	public Transform camera;
	public GameObject balancing;
	//public GameObject cubeGroundObj;

	CubeGrounded cubegrounded;

	Rigidbody rb;
	Animator animatorMist;

	//to try and align character to the ground
	float longueurRay = 1.5f;

	RaycastHit hit;
	Quaternion rot;
	public int smooth = 0;

	public int explosion = 60;

	Vector3 DifferenceBetweenPlayerandObject;
	Vector3 forwardRelativeToSurfaceNormal;

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
		//animatorMist.SetFloat ("Speed2", Mathf.Abs (Input.GetAxis ("Horizontal")));
		animatorMist.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Vertical")));

		//raycast
//		if (Physics.Raycast (balancing.transform.position, -transform.up, out hit, longueurRay)) { //version de base!!!!!!!!
//			if (hit.transform.tag == "Balancing") {
//				print("Je suis sur un cylindre");
//				DifferenceBetweenPlayerandObject = hit.transform.position - transform.position;
//				float fucktrigo = Mathf.Tan (DifferenceBetweenPlayerandObject.x/DifferenceBetweenPlayerandObject.y);
//				print ("Mon angle est" + fucktrigo);
//				transform.eulerAngles = new Vector3 (0, 0 , -fucktrigo);
//				//transform.rotation ;
//				//hit.transform.rotation = ;
//				//print ("Attention c'est un mechant");
//			}
//
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

			//CharacterFaceRelativeToSurface ();
			//transform.Translate(Input.GetAxis("Horizontal")*0.01f, 0,0);



			//try and set character rotating;
//		Ray ray = new Ray (transform.position, -transform.up);
//		if(Physics.Raycast(ray, out hit)){
//			rot = Quaternion.FromToRotation (transform.up, hit.normal) * transform.rotation;
//			transform.rotation = Quaternion.Lerp (transform.rotation, rot, Time.deltaTime * smooth);
//		}

		}


//	private void CharacterFaceRelativeToSurface(){
//		if(Physics.Raycast(transform.position, -Vector3.up, out hit, 10)){
//			surfaceNormal = hit.normal;
//			forwardRelativeToSurfaceNormal = Vector3.Cross (transform.right, surfaceNormal);
//			Quaternion targetRotation = Quaternion.LookRotation (forwardRelativeToSurfaceNormal, surfaceNormal);
//			transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation,Time.deltaTime *2);
//		}
//	}

	void Movement(){
		
		Vector3 forward = Vector3.Scale(camera.forward, new Vector3(1, 0, 1)).normalized;
		float v = Input.GetAxis ("Vertical") * Time.deltaTime  * PlayerMovementSpeed;			//float v = Input.GetAxis ("Vertical")  * PlayerMovementSpeed;
																								//float h = Input.GetAxis ("Horizontal")  * PlayerMovementSpeed;


		Vector3 move = v * forward ;//+ h * camera.right;

		// Cette ligne est pour le vertical movement, en ce moment c'est sur l'axe Z
		transform.Translate (move, Space.World);
																								//rb.velocity = new Vector3 (move.x, rb.velocity.y, move.z);
		// Cette ligne est pour le horizontal movement, en ce moment c'est sur l'axe X. When combined with vertical movement it can be used for Strafing
		//transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMovementSpeed, 0, 0);
//		if (move.magnitude > 0) {
//			transform.forward = Vector3.RotateTowards(transform.forward, move.normalized, Time.deltaTime * PlayerRotationSpeed, 0);
//		}
//
		// VERSION CRISTELLE transform.Rotate (0 , 2 * Input.GetAxis("Horizontal"), 0 );

		// Pour rotater la cam
		//transform.Rotate(0, Input.GetAxis ("RightStick") * Time.deltaTime * PlayerRotationSpeed, 0);
	}

	void UserInputs(){
	
		// Bouton A (joystick button 0)
		if (Input.GetButtonDown ("360_AButton") && cubegrounded.isGrounded == true && isjumping == false){
			//print ("Je pèse sur: le bouton A!");
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
			//print ("Je pèse sur: left bumper!");
			//rb.AddForce (transform.right * -explosion);
		}

		// Right bumper (... 5)
		if (Input.GetButtonDown ("360_RightBumper")){
			//print ("Je pèse sur: right bumper!");
			//rb.AddForce (transform.right * explosion);
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
		animatorMist.SetBool ("Grounded", false);
		yield return new WaitForSeconds (0.23f);
		cubegrounded.isGrounded = false;
		rb.AddForce (new Vector3 (0, jumpforce, 0));
		isjumping = false;
	}

}
