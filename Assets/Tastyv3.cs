using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Tastyv3 : MonoBehaviour {
	public GameObject mistObj;
	public GameObject Mist;
	public Canvas ButtonY;
	//public Canvas UIRaton;
	public GameObject TriggerUIRaton;
	public GameObject barricade;

	public float timeUI = -1f;

	Animator anim;

	Animator animBarricade;

	//public GameObject thisfood;
	public GameObject lessfood1;
	public GameObject lessfood2;
	public GameObject lessfood3;
	public GameObject lessfood4;
	public GameObject lessfood5;
	public GameObject lessfood6;

	public GameObject raccoon1;
	public GameObject raccoon2;
	public GameObject raccooncutscene1;
	public GameObject raccooncutscene2;
	public GameObject foodtasty;

	public AudioClip Raccoon1;
	public AudioClip dramatic;

	public GameObject block;

	public Camera MainCamera;
	public Camera RaccoonCamera;
	public GameObject raccooncameratarget;
	public GameObject referencemaincamera;
	Vector3 velocity = Vector3.zero;

	public Transform HealthBar;
	public float NbPtsVieRedonner = 5;

	public bool cameramoveforward = false;
	public bool cameramovebackward = false;

	private AudioManager audioManager;

	// Use this for initialization
	void Start () {
		ButtonY.enabled = false;
		block.GetComponent<NavMeshAgent> ().enabled = false;
		anim = mistObj.GetComponent <Animator> ();
		animBarricade = barricade.GetComponent<Animator> ();

		raccoon1.SetActive (false);
		raccoon2.SetActive (false);
		raccooncutscene1.SetActive (false);
		raccooncutscene2.SetActive (false);
		//UIRaton.enabled = false;
		RaccoonCamera.enabled = false;
		TriggerUIRaton.SetActive (false);

		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");	}

	}

	void OnTriggerStay (Collider other){

		//ButtonY.enabled = true;

		//Faire attention ici qqchose à modifier quand on va le mettre sur le MSI
		if (other.gameObject.tag == "Player" && (Input.GetButtonDown ("360_YButton") || Input.GetButtonDown ("XbOne_YButton")) && anim.GetCurrentAnimatorStateInfo(0).IsName ("A_idle")){//  && Ieat == false) {
			//Ieat = true;
			print ("Je peux manger");
			anim.SetBool ("Miam", true);
			StartCoroutine (EatThis ());
			HealthBar.GetComponent<HealthBar>().LifeGain(NbPtsVieRedonner);
			//HealthBar.GetComponent<HealthBar>().LifeGain(NbPtsVieRedonner);
//			lessfood1.SetActive (false);
//			lessfood2.SetActive (false);
//			lessfood3.SetActive (false);
//			lessfood4.SetActive (false);
//			lessfood5.SetActive (false);
//			lessfood6.SetActive (false);
//			block.GetComponent<NavMeshAgent> ().enabled = true;
//			//block.SetActive (false);
//			raccoon1.SetActive (true);
//			raccoon2.SetActive (true);
//			timeUI = 5f;
			//StartCoroutine (EatThis ());


			//HBcode.LifeGain (10);
			//anim.SetBool ("Miam", false);

		}
		if (other.gameObject.tag == "Player" && (Input.GetKeyDown (KeyCode.Y))){//  && Ieat == false) {
			//Ieat = true;
			print ("Je peux manger");
			anim.SetBool ("Miam", true);
			StartCoroutine (EatThis ());


		}
	}

	void OnTriggerExit (Collider other){
		

	}
	void OnTriggerEnter (Collider other){
		

	}
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.C)){
			MainCamera.enabled = false;
			RaccoonCamera.enabled = true;
		}
		if(Input.GetKeyDown(KeyCode.V)){
			MainCamera.enabled = true;
			RaccoonCamera.enabled = false;
		}

		if(cameramoveforward == true){
			RaccoonCamera.transform.position = Vector3.SmoothDamp (RaccoonCamera.transform.position, raccooncameratarget.transform.position, ref velocity, 0.8f, 1000);
			//RaccoonCamera.transform.position += RaccoonCamera.transform.forward * Time.deltaTime *3.7f;
		}
		if(cameramovebackward == true){
			RaccoonCamera.transform.position = Vector3.SmoothDamp (RaccoonCamera.transform.position, referencemaincamera.transform.position, ref velocity, 0.5f, 2000);
			//RaccoonCamera.transform.rotation = Quaternion.Slerp (RaccoonCamera.transform.rotation, MainCamera.transform.rotation, Time.deltaTime );
			RaccoonCamera.transform.rotation = Quaternion.Slerp (RaccoonCamera.transform.rotation, MainCamera.transform.rotation, 0.15f);
			//RaccoonCamera.transform.position -= RaccoonCamera.transform.forward * Time.deltaTime * 19.2f ;
			//RaccoonCamera.transform.position -= RaccoonCamera.transform.forward * Time.deltaTime * 1f ;
		}



		if (timeUI >= 0) {
			//UIRaton.enabled = true;
		} else {
			//UIRaton.enabled = false;
		}
		timeUI -= Time.deltaTime;
	}


	IEnumerator EatThis (){
		if (gameObject.tag == "Milk") {
			audioManager.PlaySound ("Mist_DrinkMilk");
		} else if (gameObject.tag != "Milk") {
			audioManager.PlaySound ("Mist_Eating");
		}
		ButtonY.enabled = false;
		Mist.GetComponent<Xbox_Controls>().enabled = false;
		Mist.GetComponent<MistStopWhenIdle>().enabled = false;
		yield return new WaitForSeconds (0.7f);
		ButtonY.enabled = false;
		GetComponent<AudioSource>().PlayOneShot (Raccoon1,1);
		lessfood1.SetActive (false);
		yield return new WaitForSeconds (0.31f);
		referencemaincamera.transform.position = MainCamera.transform.position;
		//referencemaincamera.transform.rotation = MainCamera.transform.rotation;
		MainCamera.enabled = false;
		RaccoonCamera.enabled = true;
		RaccoonCamera.GetComponent<CameraLookatRaccoon> ().enabled = true;
		raccooncutscene1.SetActive (true);
		raccooncutscene2.SetActive (true);
		yield return new WaitForSeconds (0.250f);
		cameramoveforward = true;
		yield return new WaitForSeconds (0.250f);
		lessfood2.SetActive (false);
		yield return new WaitForSeconds (0.43f);

		lessfood3.SetActive (false);
		yield return new WaitForSeconds (0.43f);
		lessfood4.SetActive (false);
		cameramoveforward = false;
		GetComponent<AudioSource>().PlayOneShot (dramatic,1);
		yield return new WaitForSeconds (1.2f);
		animBarricade.SetBool ("MoveOut", true);
		yield return new WaitForSeconds (0.3f);
		RaccoonCamera.GetComponent<CameraLookatRaccoon> ().enabled = false;
		cameramovebackward = true;
		lessfood5.SetActive (false);

		yield return new WaitForSeconds (0.21f);
		//cameramovebackward = false;
		yield return new WaitForSeconds (0.21f);
		lessfood6.SetActive (false);

		yield return new WaitForSeconds (0.5f);
		MainCamera.enabled = true;

		RaccoonCamera.enabled = false;
		Mist.GetComponent<Xbox_Controls>().enabled = true;
		Mist.GetComponent<MistStopWhenIdle>().enabled = true;
		raccooncutscene1.SetActive (false);
		raccooncutscene2.SetActive (false);
		block.GetComponent<NavMeshAgent> ().enabled = true;
		//yield return new WaitForSeconds (0.43f); 

		//GetComponent<AudioSource>().PlayOneShot (Raccoon1,1);

//		yield return new WaitForSeconds (5.9f); 
//		GetComponent<AudioSource>().PlayOneShot (Raccoon1,1);
//		yield return new WaitForSeconds (0.8f); 
//		MainCamera.enabled = true;
//		RaccoonCamera.enabled = false;
//		Mist.GetComponent<Xbox_Controls>().enabled = true;
//		Mist.GetComponent<MistStopWhenIdle>().enabled = true;
//		raccooncutscene1.SetActive (false);
//		raccooncutscene2.SetActive (false);
//		block.GetComponent<NavMeshAgent> ().enabled = true;


		raccoon1.SetActive (true);
		raccoon2.SetActive (true);
		TriggerUIRaton.SetActive (true);
		timeUI = 5f;
		yield return new WaitForSeconds (5f);
		animBarricade.SetBool ("MoveOut", false);
		animBarricade.SetBool ("MoveIn", true);
		yield return new WaitForSeconds (1f);
		animBarricade.SetBool ("MoveIn", false);
		yield return new WaitForSeconds (1f);
		foodtasty.SetActive (false);
		//thisfood.SetActive (false);
		//Ieat = false;
	}
}
