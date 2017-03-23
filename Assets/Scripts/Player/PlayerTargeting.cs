using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargeting : MonoBehaviour {

	private GameObject target;
	private float targetRange = 150f;
	private Camera playerCam;
	private Projector targetProjector;

	void Start () {
		playerCam = GetComponentInChildren<Camera> ();
	}

	void Update () {
		HandleMouseInput ();
		CheckIfTargetIsStillValid ();
	}

	private void HandleMouseInput () {
		if (Input.GetMouseButtonDown (0)) {
			// disable sticky targeting - TODO make option available
			resetTarget ();
			//creates a ray from camera to mouse position
			//creates a rayHit to detect the object hit
			Ray ray = playerCam.ScreenPointToRay (Input.mousePosition);
			RaycastHit rayHit;
			//Vector3 rayVector;
			GameObject rayHitObject;
			//casts ray 100 meters with rayHit to detect object hit
			//could add layer masks as an additional condition after the distance
			if (Physics.Raycast (ray, out rayHit, 100)) {
				//can get position of ray hit for transforms/vector calculations
				//rayVector = rayHit.point;
				//get the ray hit object 
				rayHitObject = rayHit.collider.gameObject;
				// disable self-targeting with model
				if (rayHitObject != this.gameObject) {
					target = rayHitObject;
					target.GetComponentInChildren<Projector> ().enabled = true;
				}
			}
			Debug.DrawRay (ray.origin, ray.direction * 100f, Color.red, 2f);
		}
	}

	private void CheckIfTargetIsStillValid () {
		if (target != null) {
			float distance = Vector3.Distance (target.transform.position, this.transform.position);
			//check if target is still in range
			if (distance > targetRange) {
				resetTarget ();
			}
		}
	}

	private void resetTarget () {
		if (target != null) {
			target.GetComponentInChildren<Projector> ().enabled = false;
			this.target = null;
		}
	}

	public GameObject getTarget () {
		string uIdentity = target.transform.name;
		GameObject gO = GameObject.Find (uIdentity);
		return gO;
	}
}
