using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MistGoToSleepEnd : MonoBehaviour {
	public bool goToSleep;
	Animator anim;
	public GameObject mistObj;
	public Image Black;
	public Text message;

	public Canvas ButtonY;
	bool isfading = false;
	bool isfadingtext = false;

	// Use this for initialization
	void Start () {
		anim = mistObj.GetComponent <Animator> ();
		message = message.GetComponent <Text> ();
		Color c = message.color;
		c.a = 0f;
		message.color = c;
	}
	
	// Update is called once per frame
	void Update () {
		Black = Black.GetComponent <Image> ();
		message = message.GetComponent <Text> ();

		if (isfading == true && Black.color.a < 1f) {
			Color c = Black.color;
			c.a += (Time.deltaTime * 0.5f);
			Black.color = c;

		} else if (Black.color.a >= 1f) {
			isfading = false;

		}

		if (isfadingtext == true && message.color.a < 1f) {
			Color m = message.color;
			m.a += (Time.deltaTime * 0.2f);
			message.color = m;

		} else if (message.color.a >= 1f) {
			isfadingtext = false;
		}
	}
	void OnTriggerStay (Collider other){

		//ButtonY.enabled = true;

		//Faire attention ici qqchose à modifier quand on va le mettre sur le MSI
		if (other.gameObject.tag == "Player" && (Input.GetButtonDown ("360_YButton") || Input.GetButtonDown ("XbOne_YButton")) && anim.GetCurrentAnimatorStateInfo(0).IsName ("A_idle")){//  && Ieat == false) {
			//Ieat = true;
			print ("ZZZZZ");
			anim.SetBool ("DodoTime", true);
			//goToSleep = true;
			//anim.SetBool ("Miam", true);
			StartCoroutine (Sleep ());
			//HealthBar.GetComponent<HealthBar>().LifeGain(NbPtsVieRedonner);
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
	
	}
	IEnumerator Sleep (){
		ButtonY.enabled = false;
		yield return new WaitForSeconds (3f);
		isfading = true;
		yield return new WaitForSeconds (2.3f);
		isfadingtext = true;

	}

	void OnTriggerExit (Collider other){
		ButtonY.enabled = false;

	}
	void OnTriggerEnter (Collider other){
		ButtonY.enabled = true;

	}
}
