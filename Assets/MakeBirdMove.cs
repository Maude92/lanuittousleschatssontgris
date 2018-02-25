using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBirdMove : MonoBehaviour {
	public GameObject NextTarget;
	public GameObject reference;

	public GameObject Bird;
	lb_BirdController1Bird birdController;
	FlyingBirdTr3 FlyBird;
	BirdFlying birdFly;

	public float delayflight = 2f;
	// Use this for initialization
	void Start () {
		birdController = Bird.GetComponent<lb_BirdController1Bird> ();
		birdFly = Bird.GetComponent<BirdFlying> ();
		FlyBird = Bird.GetComponent<FlyingBirdTr3> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			
			//Bird.GetComponent<Rigidbody>().AddForce((FlyingUp.transform.forward * 50f));
			reference.transform.position = NextTarget.transform.position;
			//FlyBird.StartingToFly ();
			Invoke ("Flight", delayflight);
		}

	}

	void Flight() {
		print ("The Bird is flying");
		FlyBird.StartingToFly ();
		//birdController.BirdFindTarget(Bird);
		//birdFly.FlyToTarget(reference.transform.position);
		//Bird.SendMessage ("FlyToTarget");
	}
}
