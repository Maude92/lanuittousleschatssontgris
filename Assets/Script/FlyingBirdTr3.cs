using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBirdTr3 : MonoBehaviour {
	public GameObject Target;
	public GameObject FlyingUp;
	public GameObject Mist;
	Vector3 velocity = Vector3.zero;
	public float t = 0;
	public float smoothTime = 5f;
	public float maxvelocity = 5f;

	public bool flying = true;

	Animator animatorBird;

	public AudioClip song1;
	public AudioClip song2;

	// Use this for initialization
	void Start () {
		animatorBird = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (flying ==true){
			transform.LookAt (Mist.transform.position);
		}
		if (flying == false){
			//t += Time.deltaTime;
		
			//if (t > 1f && Vector3.Distance(Target.transform.position, transform.position) > 0.02f) {
			if (Vector3.Distance(Target.transform.position, transform.position) > 1f) {//&& Vector3.Distance(Target.transform.position, transform.position) > 2f) {
				//animatorBird.SetTrigger("landingTrigger");
				transform.LookAt (Target.transform.position);
				//transform.position = Vector3.Lerp (transform.position, Target.transform.position, 1f);
				transform.position = Vector3.SmoothDamp (transform.position, Target.transform.position, ref velocity, smoothTime, maxvelocity);
				//GetComponent<Rigidbody>().AddForce((transform.forward * 5f));

			} else if (Vector3.Distance(Target.transform.position, transform.position) > 0.05f && Vector3.Distance(Target.transform.position, transform.position)<= 1f) {//&& Vector3.Distance(Target.transform.position, transform.position) > 2f) {
				animatorBird.SetTrigger("landingTrigger");
				transform.up = FlyingUp.transform.up;
				//transform.position = Vector3.Lerp (transform.position, Target.transform.position, 1f);
				transform.position = Vector3.SmoothDamp (transform.position, Target.transform.position, ref velocity, smoothTime, maxvelocity);
				//GetComponent<Rigidbody>().AddForce((transform.forward * 5f));

			} else if (Vector3.Distance(Target.transform.position, transform.position) <= 0.05f) {
				animatorBird.ResetTrigger("landingTrigger");
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				flying = true;
			}

		}
		if (Input.GetButtonDown ("360_XButton")){
			print ("Je pèse sur: le bouton X!");
			//GetComponent<Rigidbody>().AddForce((FlyingUp.transform.forward * 50f));
			//GetComponent<Rigidbody>().AddForce((transform.up * 50f));
			GetComponent<Rigidbody>().AddForce((Vector3.up * 50f));
			flying = false;

			//GetComponent<Rigidbody> ().AddForce ((transform.forward * 500f);(transform.up * 100f));
//			onGround = false;
//			GetComponent<Rigidbody>().isKinematic = false;
//			GetComponent<Rigidbody>().drag = 0.5f;

		}


	}
	public void StartingToFly(){
		//GetComponent<Rigidbody>().AddForce((FlyingUp.transform.forward * 50f));
		transform.LookAt (Target.transform.position);
		animatorBird.SetTrigger("flyingTrigger");
		GetComponent<Rigidbody> ().AddForce (transform.up * 15f);
		Invoke ("Flight", 0.73f);
		//GetComponent<Rigidbody> ().AddForce ((transform.forward * -30f) + (transform.up * 60f));
		//GetComponent<Rigidbody>().AddForce((Vector3.up * 50f));
		//flying = false;
	}

	void Flight() {
		GetComponent<Rigidbody> ().AddForce ((transform.forward * -30f) + (transform.up * 60f));
		//GetComponent<Rigidbody>().AddForce((Vector3.up * 50f));
		flying = false;
		//birdController.BirdFindTarget(Bird);
		//birdFly.FlyToTarget(reference.transform.position);
		//Bird.SendMessage ("FlyToTarget");
	}

	void PlaySong(){
		
			if(Random.value < .5){
				GetComponent<AudioSource>().PlayOneShot (song1,1);
			}else{
				GetComponent<AudioSource>().PlayOneShot (song2,1);
			}

	}
}
