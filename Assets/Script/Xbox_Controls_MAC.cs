using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbox_Controls_MAC : MonoBehaviour {

	public float PlayerMovementSpeed = 30;
	public float PlayerRotationSpeed = 180;

	private AudioManager audioManager;

	public int jumpforce = 100;
	public bool isjumping;

	public GameObject mistObj;
	public Transform camera;

	CubeGrounded cubegrounded;

	Rigidbody rb;
	Animator animatorMist;

	public float longueurRay = 0.8f;
	public float longueurRayBas = 5.1f;
	private RaycastHit hit;
	private RaycastHit hit2;
	private RaycastHit hit3;

	public GameObject LumpHaut; //n'est plus utile
	public GameObject LumpBas; //n'est plus utile


	//Sound Effect
	public AudioSource WalkWater;
	public AudioSource WalkGround;
	public AudioSource RunGround; 
	public bool InWater;
	public bool EnMouvement;
	public bool Ijump;
	public bool GachetteOn = false;


	//Pour tester le Falling et les particules
	public GameObject FallingTete; // C'est un GameObject vide qui va falloir lié. Il remplace LumpHaut. Il est sur la TETE du chat, un peu en hauteur
	public GameObject FallingCul; // C'est un GameObject vide qui va falloir lié. Il remplace LumpBas. Il est sur le CUL du chat, un peu en hauteur
	public bool isFalling = false;
	public bool ToucheSol;
	public GameObject FumeeAtterrissage;
	public GameObject FumeeRun;
	public bool JeCours = false;

	//Variables Lerp Test
	public float lerpTime = 1f;
	public float currentLerpTime;
	public float moveDistance = 10f;
	public float LumpForce;
	public bool isLerping = false;
	public bool canLerp = false;

	public float Distance;
	public float DistanceBas;

	Vector3 startPos;
	Vector3 endPos;

	// Use this for initialization
	void Start () {
		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");
		}

		rb = GetComponent <Rigidbody> ();
		animatorMist = mistObj.GetComponent <Animator> ();
		cubegrounded = GetComponent <CubeGrounded> ();

		//Pour Lump
		LumpHaut.SetActive (false); //N'est plus utile
		LumpBas.SetActive (false); //N'est plus utile

		//Particules
		FumeeAtterrissage.SetActive(false);
		FumeeRun.SetActive (false);

		WalkGround.enabled = false;

	}

	void FixedUpdate(){
		Movement ();
//Ça c'est très important
		startPos = mistObj.transform.position;
	}

	// Update is called once per frame
	void Update () {

		print ("Mes Gachettes sont " + GachetteOn);

		UserInputs ();
		animatorMist.SetFloat ("Speed2", Mathf.Abs (Input.GetAxis ("Horizontal")));
		animatorMist.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Vertical")));

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

		//Pour les particules à l'atterrissage
		if (animatorMist.GetCurrentAnimatorStateInfo (0).IsName ("A_jump_loop")) {
			//StartCoroutine (Atterrissage ());

		}

	//Pour les sons
		//Pour jouer son lorsque joueur bouge
		if (Physics.Raycast (FallingTete.transform.position, -transform.up, out hit, longueurRay, LayerMask.GetMask ("Ground")) && Physics.Raycast (FallingCul.transform.position, -transform.up, out hit, longueurRay, LayerMask.GetMask ("Ground"))) {

			if (hit.transform.tag == "Liquide" && EnMouvement == true && !WalkWater.isPlaying) {
				//audioManager.PlaySound ("Mist_Nage2");
				print ("Je touche à de l'eau et je bouge !");
				WalkWater.enabled = true;
				WalkWater.Play ();

				//Les Stops
				WalkGround.enabled = false;
				WalkGround.Stop ();

//				RunGround.enabled = false;
//				RunGround.Stop ();
			}

			if (hit.transform.tag == "Solide" && EnMouvement == true && !WalkGround.isPlaying) {
				print ("Je touche au sol et je fais du bruit !");
				WalkGround.enabled = true;
				WalkGround.Play ();

				//Les Stops
				WalkWater.Stop ();
				WalkWater.enabled = false;

//				RunGround.enabled = false;
//				RunGround.Stop ();
			} 

			if (hit.transform.tag == "Solide" && EnMouvement == true && !RunGround.isPlaying && GachetteOn == true) {
				print ("Je cours sur le sol et je fais du bruit !");
				RunGround.enabled = true;
				RunGround.Play ();

				//Les Stops
				WalkWater.Stop ();
				WalkWater.enabled = false;

				WalkGround.enabled = false;
				WalkGround.Stop ();

				//Particules Course
				FumeeRun.SetActive (true);
			} 
				

		}

		if (EnMouvement == false) {
			WalkWater.Stop ();
			WalkWater.enabled = false;

			WalkGround.enabled = false;
			WalkGround.Stop ();

			RunGround.enabled = false;
			RunGround.Stop ();
		}

		if (EnMouvement == true && Ijump == true) {
			WalkWater.Stop ();
			WalkWater.enabled = false;

			WalkGround.enabled = false;
			WalkGround.Stop ();

			RunGround.enabled = false;
			RunGround.Stop ();
		}

		if (GachetteOn == false) {
			RunGround.enabled = false;
			RunGround.Stop ();
			FumeeRun.SetActive (false);
		}

		if (GachetteOn == true) {
//			WalkWater.Stop ();
//			WalkWater.enabled = false;

			WalkGround.enabled = false;
			WalkGround.Stop ();

		}

		if (GachetteOn && Ijump == true) {
			FumeeRun.SetActive (false);
		}
			

	// POUR FAIRE PIVOTER LA TÊTE
		// Tête à gauche
		if (Input.GetAxis ("XbOne_RightStickX") < -0.1f) {
			//print ("Allo! Tête à gauche.");
			animatorMist.SetFloat ("TurnG", 1);
		} else
			animatorMist.SetFloat ("TurnG", 0);

		// Tête à droite
		if (Input.GetAxis ("XbOne_RightStickX") > 0.1f) {
			//print ("Allo! Tête à droite.");
			animatorMist.SetFloat ("TurnD", 1);
		} else
			animatorMist.SetFloat ("TurnD", 0);

		// Tête en haut
		if (Input.GetAxis ("XbOne_RightStickY") > 0.1f) {
			//print ("Allo! Tête en haut.");
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
			//print ("Je pèse sur: le bouton A!");
			Ijump = true;
			StartCoroutine (JumpMistRoutine ());
			audioManager.PlaySound ("Mist_Jump");
			StartCoroutine (Atterrissage ());
		}

		// Bouton B (joystick button 1)
		if (Input.GetButtonDown ("XbOne_BButton")) {
			audioManager.PlaySound ("Mist_Meow");
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

		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			EnMouvement = true;
			print (EnMouvement);
		} else {
			EnMouvement = false;
			print (EnMouvement);
		}

//Ok ici il y a du stock très important, mais attention à ce que tu ais les bon boutons (Input), ignore les commentaires
	// LUMP et course
		if (Input.GetAxis ("XbOne_LeftTrigger") > 0.001 || Input.GetAxis ("XbOne_RightTrigger") < -0.001) {
			//print ("Je pèse sur le trigger gauche!!");
			GachetteOn = true;
			PlayerMovementSpeed = 4;
			jumpforce = 240;
			JeCours = true;
			animatorMist.SetBool ("IsLumping", true); //IsLumping = animation courrir
			if (Input.GetAxis ("XbOne_LeftTrigger") > 0.001) {
				//rien du tout
			}
				if (Input.GetAxis ("XbOne_RightTrigger") < -0.001) {
				//rien du tout
				}
			} else if (Input.GetAxis ("XbOne_LeftTrigger") < 0.001 || Input.GetAxis ("XbOne_RightTrigger") > -0.001) {
				PlayerMovementSpeed = 2;
				jumpforce = 220;
				JeCours = false;
				animatorMist.SetBool ("IsLumping", false);
				Distance = 0;
				GachetteOn = false;
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
				GachetteOn = false;
				animatorMist.SetBool ("IsLumping", false);
			}

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

	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag ("Water")) {
			Invoke ("Splash", 0.2f);
		} 
			
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.CompareTag("Solide")){
			audioManager.PlaySound ("Mist_Land");
			Ijump = false;
			StartCoroutine (Atterrissage ());
		}

		if (col.gameObject.CompareTag ("Liquide")) {
			//audioManager.PlaySound ("Mist_Nage");
			Ijump = false;
		}
	}

	void Splash (){
		audioManager.PlaySound ("Mist_Splash");
	}
		
	IEnumerator JumpMistRoutine(){
		isjumping = true;
		animatorMist.SetTrigger ("Jump");
		animatorMist.SetBool ("Grounded", false);
		yield return new WaitForSeconds (0.01f);
		cubegrounded.isGrounded = false;
		rb.AddForce (new Vector3 (0, jumpforce, 0));
		isjumping = false;
	}

	IEnumerator Atterrissage(){
		FumeeAtterrissage.SetActive(true);
		yield return new WaitForSeconds (2f);
		FumeeAtterrissage.SetActive (false);
		print ("Je fonctionne");
	}
		


}
