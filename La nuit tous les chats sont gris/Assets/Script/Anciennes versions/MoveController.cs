using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelWizards.GameSystem.Controllers
{
	//[RequireComponent(typeof(CharacterController))]
public class MoveController : MonoBehaviour {

		// public user configurable
		public float walkSpeed = 1.0f;
		public float gravity = 9.8f;

		// private internals
		private CharacterController controller;
		private Camera mainCamera;

		private float currentGravity = 0f;

		// movement calculations
		private float desiredSpeed = 0f;
		private float currentSpeed = 0f;

		// store user input (horizontal &amp; vertical)
		private float h;
		private float v;

		// for maths (screen-relative movement calculations)
		private Vector3 moveDirection = Vector3.zero;
		private Vector3 forward;
		private Vector3 right;

		private void Awake(){
			controller = GetComponent<CharacterController> ();
		}

		// Use this for initialization
		void Start(){
			mainCamera = Camera.main;
		}

		// Update is called once per frame
		void Update(){
			h = Input.GetAxis ("Horizontal");
			v = Input.GetAxis("Vertical");

			// check if we are on the ground
			if (controller.isGrounded) {
				// camera-relative movement - which way points forward for us
				forward = mainCamera.transform.TransformDirection(Vector3.forward);
				forward.y = 0;
				forward = forward.normalized;
				//figure out hte right vector based on our forward vector
				right = new Vector3(forward.z, 0, forward.x);

				// figure out which direction we're going
				moveDirection = (h * right + v * forward).normalized;

				// apply move speed
				desiredSpeed = walkSpeed;
				moveDirection *= Mathf.Lerp (currentSpeed, desiredSpeed, Time.deltaTime);
			}

			// apply gravity
			var currentGravity = gravity * (Time.deltaTime * 50);
			moveDirection.y -= currentGravity;

			// Actually do the move
			controller.Move(moveDirection * Time.deltaTime);

			// remove any Y movement 
			moveDirection.y = 0f;

			// Figure out how fast we're going
			currentSpeed = moveDirection.magnitude;

			// face where we are moving
			transform.rotation = Quaternion.LookRotation(moveDirection);
		}


	}

	}

