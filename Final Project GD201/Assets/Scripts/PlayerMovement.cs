using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


	public float moveSpeed;
	public float jumpForce;
	public CharacterController controller;

	private Vector3 moveDirection;
	public float gravityScale;

	public Animator anim;
	public Transform pivot;
	public float rotateSpeed;
	public GameObject playerModel;

	public bool flashlight;
	public GameObject flashlightObj;
	public int ratsRemaining = 4;
	public int hasKey = 0;

	void Start () {
		controller = GetComponent<CharacterController>();
	}

	void LateUpdate () {
		//basic movement using a character controller rather then rigidbody.
		//moveDirection = new Vector3 (Input.GetAxis ("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis ("Vertical") * moveSpeed);

		//use this to make the player move according to foward direction of the gameObject
		float yStore = moveDirection.y;
		moveDirection = (transform.forward * Input.GetAxisRaw ("Vertical") * moveSpeed) + (transform.right * Input.GetAxisRaw ("Horizontal") * moveSpeed);
		moveDirection = moveDirection.normalized * moveSpeed;
		moveDirection.y = yStore;

		if (controller.isGrounded) {
			
			moveDirection.y = 0f;
			if (Input.GetButtonDown ("Jump")) {

				moveDirection.y = jumpForce;
			}
		}

		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);

		controller.Move (moveDirection * Time.deltaTime);

		//move the player in directions based on the camera look direction

		if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) {
			transform.rotation = Quaternion.Euler (0f, pivot.rotation.eulerAngles.y, 0f);
			Quaternion newRotation = Quaternion.LookRotation (new Vector3 (moveDirection.x, 0f, moveDirection.z));
			playerModel.transform.rotation = Quaternion.Slerp (playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
		}
			
		anim.SetFloat ("Speed", (Mathf.Abs (Input.GetAxisRaw ("Vertical")) + Mathf.Abs (Input.GetAxisRaw ("Horizontal"))));


		//this is the script that will determine if the player is crouched and will play the crouched animation
		if (Input.GetKeyDown ("c")) {
			anim.SetBool ("IsCrouched", true);
			moveSpeed = moveSpeed/2;
		} else {
	}
		if (Input.GetKeyUp ("c")) {
			anim.SetBool ("IsCrouched", false);
			moveSpeed = moveSpeed * 2;
		}

		//this is the script to enable and disable the flashlight
		if (Input.GetKeyDown (KeyCode.F))
			flashlight =! flashlight;
		if (flashlight)
			flashlightObj.SetActive (true);
		else
			flashlightObj.SetActive (false);		
}
}
