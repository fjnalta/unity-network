using UnityEngine;
using System.Collections;

/* Script handles the PlayerCamera */
public class PlayerCamera : MonoBehaviour {

	[SerializeField] private GameObject target;
	[SerializeField] private Camera playerCam;

	private float targetHeight = 1.7f;
	// Vertical offset adjustment
	private float distance = 15.0f;
	// Default Distance
	private float offsetFromWall = 0.1f;
	// Bring camera away from any colliding objects
	private float maxDistance = 20f;
	// Maximum zoom Distance
	private float minDistance = 0.6f;
	// Minimum zoom Distance
	private float xSpeed = 250.0f;
	// Orbit speed (Left/Right)
	private float ySpeed = 200.0f;
	// Orbit speed (Up/Down)
	private float yMinLimit = -80f;
	// Looking up limit
	private float yMaxLimit = 80f;
	// Looking down limit
	private float zoomRate = 40f;
	// Zoom Speed
	private float rotationDampening = 0.5f;
	// Auto Rotation speed (higher = faster)
	private float zoomDampening = 5.0f;
	// Auto Zoom speed (Higher = faster)
	private LayerMask collisionLayers = -1;
	// What the camera will collide with

	private float xDeg = 0.0f;
	private float yDeg = 0.0f;
	private float currentDistance;
	private float desiredDistance;
	private float correctedDistance;
	private float pbuffer = 0.0f;
	//Cooldownpuffer for SideButtons

	void Start () {
			playerCam = GetComponentInChildren<Camera> ();
			Vector3 angles = transform.eulerAngles;
			xDeg = angles.x;
			yDeg = angles.y;
			currentDistance = distance;
			desiredDistance = distance;
			correctedDistance = distance;
	}

	void LateUpdate () {
		// If the Camera target is null try to get the Parent GameObject. Else return.
		if (target == null) {
			if (transform.parent.gameObject != null) {
				target = transform.parent.gameObject;
			} else {
				return;
			}
		}

		// reset cursor
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		// pushbuffer
		if (pbuffer > 0)
			pbuffer -= Time.deltaTime;
		if (pbuffer < 0)
			pbuffer = 0;	
           
		Vector3 vTargetOffset;
                       
		// If either mouse buttons are down, let the mouse govern camera position
		if (GUIUtility.hotControl == 0) {
			// lock the cursor if any mouse button gets pressed
			if (Input.GetMouseButton (0)) {
				Cursor.visible = false;
			} else if (Input.GetMouseButton (1) || Input.GetMouseButton (2)) {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
			// Left mouse Button - rotate camera
			if (Input.GetMouseButton (0)) {
				xDeg += Input.GetAxis ("Mouse X") * xSpeed * 0.02f;
				yDeg -= Input.GetAxis ("Mouse Y") * ySpeed * 0.02f;
			// Right mouse Button - rotate camera and player
			} else if (Input.GetMouseButton (1)) {
				xDeg += Input.GetAxis ("Mouse X") * xSpeed * 0.02f;
				yDeg -= Input.GetAxis ("Mouse Y") * ySpeed * 0.02f;
				// rotate the player at RMB
				target.transform.rotation = Quaternion.Euler (0, GetComponentInChildren<Camera> ().transform.eulerAngles.y, 0);
			// rotate behind player if any movement key is pressed
			} else if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) {
				RotateBehindTarget ();
			}

			yDeg = ClampAngle (yDeg, yMinLimit, yMaxLimit);

			// Set camera rotation
			Quaternion rotation = Quaternion.Euler (yDeg, xDeg, 0);

			// Calculate the desired distance
			desiredDistance -= Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs (desiredDistance);
			desiredDistance = Mathf.Clamp (desiredDistance, minDistance, maxDistance);
			correctedDistance = desiredDistance;

			// Calculate desired camera position
			vTargetOffset = new Vector3 (0, -targetHeight, 0);
			Vector3 position = target.transform.position - (rotation * Vector3.forward * desiredDistance + vTargetOffset);
         
			// Check for collision using the true target's desired registration point as set by user using height
			RaycastHit collisionHit;
			Vector3 trueTargetPosition = new Vector3 (target.transform.position.x, target.transform.position.y + targetHeight, target.transform.position.z);

			// If there was a collision, correct the camera position and calculate the corrected distance
			var isCorrected = false;
			if (Physics.Linecast (trueTargetPosition, position, out collisionHit, collisionLayers)) {
				// Calculate the distance from the original estimated position to the collision location,
				// subtracting out a safety "offset" distance from the object we hit.  The offset will help
				// keep the camera from being right on top of the surface we hit, which usually shows up as
				// the surface geometry getting partially clipped by the camera's front clipping plane.
				correctedDistance = Vector3.Distance (trueTargetPosition, collisionHit.point) - offsetFromWall;
				isCorrected = true;
			}

			// For smoothing, lerp distance only if either distance wasn't corrected, or correctedDistance is more than currentDistance
			currentDistance = !isCorrected || correctedDistance > currentDistance ? Mathf.Lerp (currentDistance, correctedDistance, Time.deltaTime * zoomDampening) : correctedDistance;

			// Keep distance within limits
			currentDistance = Mathf.Clamp (currentDistance, minDistance, maxDistance);

			// Recalculate position based on the new currentDistance
			position = target.transform.position - (rotation * Vector3.forward * currentDistance + vTargetOffset);

			// Finally Set rotation and position of camera
			playerCam.transform.rotation = rotation;
			playerCam.transform.position = position;
		}
	}

	private void RotateBehindTarget () {
		float targetRotationAngle = target.transform.eulerAngles.y;
		float currentRotationAngle = transform.eulerAngles.y;
		xDeg = Mathf.Lerp (currentRotationAngle, targetRotationAngle, rotationDampening * Time.deltaTime);
	}

	private float ClampAngle (float angle, float min, float max) {
		if (angle < -360f) {
			angle += 360f;
		}
		if (angle > 360f) {
			angle -= 360f;
		}
		return Mathf.Clamp (angle, min, max);
	}
}