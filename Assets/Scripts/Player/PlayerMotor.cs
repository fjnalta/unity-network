using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : NetworkBehaviour {

	// Player Objects
	private Transform playerTransform;
	private Transform playerModel;

	// Movement
	private float moveSpeed = 10f;
	private float jumpSpeed = 7f;
	private Vector3 MoveVector = Vector3.zero;

	// Character Controller
	private CharacterController CharacterController;

	// Gravity
	public float Gravity = 20f;

	void Start () {
		CharacterController = GetComponent ("CharacterController") as CharacterController;
		// Let Default Layer Objects pass through each other
		Physics.IgnoreLayerCollision (0,0);
	}

	void Update () {
		if (isLocalPlayer) {
			if (CharacterController.isGrounded) {
				MoveVector = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
				MoveVector = transform.TransformDirection (MoveVector);
				// Normalize MoveVector if Magnitude is > 1
				if (MoveVector.magnitude > 1) {
					MoveVector = Vector3.Normalize (MoveVector);
				}
				// set the movement speed based on the movement direction
				MoveSpeed ();
				// add movementSpeed to MoveVector
				MoveVector *= moveSpeed;
				// handle Jump input
				if (Input.GetButton ("Jump")) {
					MoveVector.y = jumpSpeed;
				}
			}
			// Apply Gravity
			MoveVector.y -= Gravity * Time.deltaTime;
			// Move CharacterController in world space
			CharacterController.Move (MoveVector * Time.deltaTime);
		}
	}

	/* This method determines the character MovementSpeed 
	 * based on the direction */
	void MoveSpeed () {
		// set max speed for forward and side-forward
		if ((Input.GetAxisRaw ("Vertical") > 0) || (Input.GetAxisRaw ("Horizontal") > 0 || Input.GetAxisRaw ("Horizontal") < 0)) {
			moveSpeed = 10f;
		}
		// set max speed / 2 for backward and side-backward
		if ((Input.GetAxisRaw ("Vertical") < 0) || (Input.GetAxisRaw ("Horizontal") > 0 && Input.GetAxisRaw ("Vertical") < 0) || (Input.GetAxisRaw ("Horizontal") < 0 && Input.GetAxisRaw ("Vertical") < 0)) {
			moveSpeed = 5f;
		}
	}
}
