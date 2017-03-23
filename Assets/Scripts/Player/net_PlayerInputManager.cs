using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class net_PlayerInputManager : NetworkBehaviour {

	//PlayerTarget
	private GameObject target;
	//PlayerCam
	private Camera playerCam;
	//PlayerClass
	private net_CharacterClass playerClass;

	private float targetRange = 70f;

	void Start (){
		if (isLocalPlayer) {
			//Enable Components
			GetComponent<CharacterController> ().enabled = true;
			GetComponent<PlayerMotor> ().enabled = true;
			GetComponentInChildren<PlayerCamera>().enabled = true;
			GetComponentInChildren<Camera>().enabled = true;
			GetComponent<net_PlayerUI>().enabled = true;
			GetComponent<net_PlayerController>().enabled = true;
			//Get PlayerCam
			playerCam = GetComponentInChildren<Camera>();
			playerClass = GetComponent<net_CharacterClass>();
		}
	}

	void Update(){

		//Handeling Action Input (LMB + Keys)
		HandleActionInput();
	}

	[Client]
	void HandleActionInput(){
		if (isLocalPlayer) {
			//Everything targetable has to react on Raycasts
			if (Input.GetMouseButtonDown (0)) {
				//creates a ray from camera to mouse position
				//creates a rayHit to detect the object hit
				Ray ray = playerCam.ScreenPointToRay (Input.mousePosition);
				RaycastHit rayHit;
				//Vector3 rayVector;
				GameObject rayHitObject;
				//casts ray 150 meters with rayHit to detect object hit
				//could add layer masks as an additional condition after the distance
				if (Physics.Raycast (ray, out rayHit, 50)) {
					//can get position of ray hit for transforms/vector calculations
					//rayVector = rayHit.point;
					//get the ray hit object 
					rayHitObject = rayHit.collider.gameObject;				
					target = rayHitObject;
				}
				//check if target is still in range
				if (target != null) {
					if (CheckDistanceToTarget () > targetRange) {
						resetTarget ();
					}
				}
			}
			//--Begin Spells
			if (Input.GetButtonDown ("Spell1")) {
				playerClass.Spell1 (target);
		} else if (Input.GetButtonDown ("Spell2")) {
				playerClass.Spell2();
		} else if (Input.GetButtonDown ("Spell3")) {
				playerClass.Spell3();
//		} else if (Input.GetButtonDown ("Spell4")) {
//			//			Spell4();
//		} else if (Input.GetButtonDown ("Spell5")) {
//			//			Spell5();
//		} else if (Input.GetButtonDown ("Spell6")) {
//			//			Spell6();
//		} else if (Input.GetButtonDown ("Spell7")) {
//			//			Spell7();
//		}
		//--End Spells

		//TAB EnemySwitching

		//--Escape
//		else if(Input.GetKeyDown(KeyCode.Escape)){
//			UserInterface.Instance.setEscMenu();
//		}
		//--Jump
//		if (Input.GetButton ("Jump")) {
//			playerMotor.Jump ();

			}
		}
	}

	[Client]
	float CheckDistanceToTarget(){
		return Vector3.Distance (target.transform.position, this.transform.position);
	}

	//--SETTER + GETTER for Targeting
	public GameObject getTarget(){
		string uIdentity = target.transform.name;
		GameObject gO = GameObject.Find (uIdentity);
		return gO;
	}

	public void resetTarget(){
		this.target = null;
	}

	public string getTargetName(){
		if (target != null) {
				string uIdentity = target.transform.name;
				GameObject go = GameObject.Find(uIdentity);
				return go.name;
		} else {
			return "null";
		}
	}
}
