using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetProjector : MonoBehaviour {

	private Transform tf;
	private CharacterController cc;

	void Start () {
		tf = GetComponent<Transform> ();
		cc = GetComponentInParent<CharacterController> ();
	}

	void Update () {
		if (!cc.isGrounded)
			tf.position = new Vector3 (tf.position.x, 4, tf.position.z);
	}
}