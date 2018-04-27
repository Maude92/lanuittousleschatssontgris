using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbox_Controls : MonoBehaviour {
	
	public float PlayerMovementSpeed = 30;
	public float PlayerRotationSpeed = 180;

	private AudioManager audioManager;

	public float walkSpeed;
	public float runSpeed;

	public int jumpforce = 100;

	public bool isjumping;

	public GameObject mistObj;
	public Transform camera;

	public AudioClip[] miaulement;
	private AudioClip miaulementClip;
	private AudioSource audioSource;

	CubeGrounded cubegrounded;

	Rigidbody rb;
	Animator animatorMist;



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
	public GameObject FumeeAtterrissage;
	public GameObject FumeeRun;
	public bool JeCours = false;
	public bool isLerping = false;
	public bool canLerp = false;
	public int landSound;

	Vector3 startPos;
	Vector3 endPos;


	//Sound Effect
	public AudioSource WalkWater;
	public AudioSource WalkGround;
	public AudioSource RunGround; 
	public bool InWater;
	public bool EnMouvement;
	public bool Ijump;
	public bool GachetteOn = false;
	public AudioSource WalkGazon;
	public AudioSource RunGazon;


	public CanvasGroup UIVieCanvasGroup;


	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
		animatorMist = mistObj.GetComponent <Animator> ();
		cubegrounded = GetComponent <CubeGrounded> ();

		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");
		}


		//Particules
		//FumeeAtterrissage.SetActive(false);
		//FumeeRun.SetActive (false);

		// Sons
		WalkGround.enabled = false;
		WalkGazon.enabled = false;

		landSound = 0;

		audioSource = gameObject.GetComponent<AudioSource> ();


	}

	void FixedUpdate(){
		Movement ();

		//Ça c'est très important
		startPos = mistObj.transform.position;
	}

	// Update is called once per frame
	void Update () {

		//print ("Mes Gachettes sont " + GachetteOn);
		SoundEffect ();
		
		//rb.velocity = new Vector3(0,0,5);
		UserInputs ();
		animatorMist.SetFloat ("Speed2", Mathf.Abs (Input.GetAxis ("Horizontal")));
		animatorMist.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Vertical")));


		// POUR LE SON DE LAND
		if (animatorMist.GetCurrentAnimatorStateInfo (0).IsName ("A_jump_end")){
			landSound++;
			Ijump = false;
		}
		if (landSound == 1) {
			audioManager.PlaySound ("Mist_Land");
		}


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


		if (cubegrounded.isGrounded == true) {
			animatorMist.SetBool ("Grounded", true);
			//isjumping = false;
		} else if (cubegrounded.isGrounded == false) {
			animatorMist.SetBool ("Grounded", false);
			//isjumping = true;
		}


		//Pour les particules à l'atterrissage
//		if (animatorMist.GetCurrentAnimatorStateInfo (0).IsName ("A_jump_loop")) {
//			//StartCoroutine (Atterrissage ());
//
//		}


	// POUR FAIRE PIVOTER LA TÊTE
		// Tête à gauche
		if (Input.GetAxis ("RightStick") < -0.1f) {
			//print ("Allo! Tête à gauche.");
			animatorMist.SetFloat ("TurnG", 1);
		} else
			animatorMist.SetFloat ("TurnG", 0);

		// Tête à droite
		if (Input.GetAxis ("RightStick") > 0.1f) {
			//print ("Allo! Tête à droite.");
			animatorMist.SetFloat ("TurnD", 1);
		} else
			animatorMist.SetFloat ("TurnD", 0);

		// Tête en haut
		if (Input.GetAxis ("RightStickY") > 0.1f) {
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
			//print ("Je pèse sur: le bouton A!");
			Ijump = true;
			//jesaute = true;
				//animatorMist.SetTrigger ("Jump");
				//animatorMist.SetBool ("Grounded", false);
				StartCoroutine (JumpMistRoutine ());
			audioManager.PlaySound ("Mist_Jump");
			//StartCoroutine (Atterrissage ());			* Pour les particules
				//Invoke ("JumpMist", 0.23f);																	// WARNING BOGUE!!!
		}
			
		// Bouton B (joystick button 1)
//		if (Input.GetButtonDown ("360_BButton")){
//			audioManager.PlaySound ("Mist_Meow");
//			print ("Je pèse sur: le bouton B!");
//		}

		// BOUTON B -> Random miaw quand on appuie sur le bouton
		if (Input.GetButtonDown ("360_BButton") && !audioSource.isPlaying && (animatorMist.GetCurrentAnimatorStateInfo (0).IsName ("A_idle") || animatorMist.GetCurrentAnimatorStateInfo (0).IsName ("A_walk") || animatorMist.GetCurrentAnimatorStateInfo (0).IsName ("A_walk 2") || animatorMist.GetCurrentAnimatorStateInfo (0).IsName ("A_run"))){
			animatorMist.SetBool ("Miaw", true);
			int indexMiaw = Random.Range (0, miaulement.Length);
			miaulementClip = miaulement [indexMiaw];
			audioSource.clip = miaulementClip;
			audioSource.Play ();
		}

//		if (Input.GetButton ("360_RightThumbstickButton")) {
//			animatorMist.SetBool ("Surprise", true);
//		}


		// Bouton X (... 2)
//		if (Input.GetButtonDown ("360_XButton")){
//			print ("Je pèse sur: le bouton X!");
//		}

		if (Input.GetButton ("360_XButton")) {
			UIVieCanvasGroup.alpha = 1;
		}

		// Bouton Y (... 3)
//		if (Input.GetButtonDown ("360_YButton")){
//			//print ("Je pèse sur: le bouton Y!");
//		}

		// Left Bumper (... 4)
//		if (Input.GetButtonDown ("360_LeftBumper")){
//			print ("Je pèse sur: left bumper!");
//		}

		// Right bumper (... 5)
//		if (Input.GetButtonDown ("360_RightBumper")){
//			print ("Je pèse sur: right bumper!");
//		}

//		// Back button (... 6)
//		if (Input.GetButtonDown ("360_BackButton")){
//			print ("Je pèse sur: back button!");
//		}

		// Start button (... 7)
//		if (Input.GetButtonDown ("360_StartButton")){
//			print ("Je pèse sur: start button!");
//		}

//		// Left Thumbstick (... 8)
//		if (Input.GetButtonDown ("360_LeftThumbstickButton")){
//			print ("Je pèse sur: left thumbstick button!");
//		}
//
//		// Right thumbstick (... 9)
//		if (Input.GetButtonDown ("360_RightThumbstickButton")){
//			print ("Je pèse sur: right thumbstick button!");
//		}

		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			EnMouvement = true;
			print (EnMouvement);
		} else {
			EnMouvement = false;
			print (EnMouvement);
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
			//print ("Je pèse sur le trigger droit!!");
			GachetteOn = true;
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
			GachetteOn = false;
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


	void SoundEffect(){
		//Pour jouer son lorsque joueur bouge
		if (Physics.Raycast (FallingTete.transform.position, -transform.up, out hit, longueurRay, LayerMask.GetMask ("Ground")) && Physics.Raycast (FallingCul.transform.position, -transform.up, out hit, longueurRay, LayerMask.GetMask ("Ground"))) {

			//MARCHE ET COURSE EAU			** Attention, tag liquide, layer ground!!
			if (hit.transform.tag == "Liquide" && EnMouvement == true && !WalkWater.isPlaying) {
				//audioManager.PlaySound ("Mist_Nage2");
				//print ("Je touche à de l'eau et je bouge !");
				WalkWater.enabled = true;
				WalkWater.Play ();

				//Les Stops
				WalkGround.enabled = false;
				WalkGround.Stop ();

				WalkGazon.enabled = false;
				WalkGazon.Stop ();

			}

			//MARCHE GAZON
			if (hit.transform.tag == "Gazon" && EnMouvement == true && !WalkGazon.isPlaying) {
				//print ("Je marche sur le gazon et je fais du bruit");
				WalkGazon.enabled = true;
				WalkGazon.Play ();

				//Les Stops
				WalkWater.Stop ();
				WalkWater.enabled = false;

				WalkGround.enabled = false;
				WalkGround.Stop ();
			} 

			//COURSE GAZON
			if (hit.transform.tag == "Gazon" && EnMouvement == true && !RunGazon.isPlaying && GachetteOn == true) {
				//print ("Je cours sur le sol et je fais du bruit !");
				RunGazon.enabled = true;
				RunGazon.Play ();

				//Les Stops
				RunGround.enabled = false;
				RunGround.Stop ();

				WalkWater.Stop ();
				WalkWater.enabled = false;

				WalkGround.enabled = false;
				WalkGround.Stop ();

				WalkGazon.enabled = false;
				WalkGazon.Stop ();

				//Particules Course
				//FumeeRun.SetActive (true);
			} 

			//MARCHE SOL
			if ((hit.transform.tag == "Solide" || hit.transform.tag == "SupportFallingObject") && EnMouvement == true && !WalkGround.isPlaying) {
				//print ("Je touche au sol et je fais du bruit !");
				WalkGround.enabled = true;
				WalkGround.Play ();

				//Les Stops
				WalkWater.Stop ();
				WalkWater.enabled = false;

				WalkGazon.enabled = false;
				WalkGazon.Stop ();

			} 

			//COURSE SOL
			if ((hit.transform.tag == "Solide" || hit.transform.tag == "SupportFallingObject") && EnMouvement == true && !RunGround.isPlaying && GachetteOn == true) {
				//print ("Je cours sur le sol et je fais du bruit !");
				RunGround.enabled = true;
				RunGround.Play ();

				//Les Stops
				WalkWater.Stop ();
				WalkWater.enabled = false;

				WalkGround.enabled = false;
				WalkGround.Stop ();

				WalkGazon.enabled = false;
				WalkGazon.Stop ();

				RunGazon.enabled = false;
				RunGazon.Stop ();

				//Particules Course
				//FumeeRun.SetActive (true);
			} 


		}

		if (EnMouvement == false) {
			WalkWater.Stop ();
			WalkWater.enabled = false;

			WalkGround.enabled = false;
			WalkGround.Stop ();

			WalkGazon.enabled = false;
			WalkGazon.Stop ();

			RunGround.enabled = false;
			RunGround.Stop ();


			RunGazon.enabled = false;
			RunGazon.Stop ();
		}

		if (EnMouvement == true && Ijump == true) {
			WalkWater.Stop ();
			WalkWater.enabled = false;

			WalkGround.enabled = false;
			WalkGround.Stop ();

			WalkGazon.enabled = false;
			WalkGazon.Stop ();

			RunGround.enabled = false;
			RunGround.Stop ();


			RunGazon.enabled = false;
			RunGazon.Stop ();
		}

		if (GachetteOn == false) {
			RunGround.enabled = false;
			RunGround.Stop ();
			//FumeeRun.SetActive (false);

			RunGazon.enabled = false;
			RunGazon.Stop ();
		}

		if (GachetteOn == true) {
			//			WalkWater.Stop ();
			//			WalkWater.enabled = false;

			WalkGround.enabled = false;
			WalkGround.Stop ();

			WalkGazon.enabled = false;
			WalkGazon.Stop ();

		}

//		if (GachetteOn && Ijump == true) {
//			FumeeRun.SetActive (false);
//		}
	}


	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag ("Water")) {
			Invoke ("Splash", 0.2f);
		} 

		if (other.gameObject.tag == "Water") {
			animatorMist.SetBool ("Nage", true);
		}

	}

	// JE VEUX QUE MIST NAGE :D
	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Water") {
			animatorMist.SetBool ("Nage", false);
		}
	}


	void OnCollisionEnter (Collision col){
//		if (col.gameObject.CompareTag("Solide")){
//			audioManager.PlaySound ("Mist_Land");
//			Ijump = false;
//			StartCoroutine (Atterrissage ());
//		}

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
		landSound = 0;
		animatorMist.SetTrigger ("Jump");
		//animatorMist.SetBool ("Grounded", false);
		yield return new WaitForSeconds (0.01f);			// Version Félix: 0.01f
		cubegrounded.isGrounded = false;
		rb.AddForce (new Vector3 (0, jumpforce, 0));
		yield return new WaitForSeconds (0.5f);
		isjumping = false;
	}


	IEnumerator Atterrissage(){
		FumeeAtterrissage.SetActive(true);
		yield return new WaitForSeconds (2f);
		FumeeAtterrissage.SetActive (false);
		//print ("Je fonctionne");
	}
		
}
