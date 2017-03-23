using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

[System.Serializable]
public class ToggleEvent : UnityEvent<bool>{}

public class PlayerController : NetworkBehaviour {

	[SerializeField] ToggleEvent onToggleShared;
	[SerializeField] ToggleEvent onToggleLocal;
	[SerializeField] ToggleEvent onToggleRemote;

	GameObject mainCamera;

	void Start () {
		mainCamera = GameObject.Find ("Main Camera");
		EnablePlayer ();
	}
		
	void EnablePlayer() {
		if (isLocalPlayer) {
			mainCamera.SetActive (false);
		}

		onToggleShared.Invoke (true);

		if (isLocalPlayer) {
			onToggleLocal.Invoke (true);
		} else {
			onToggleRemote.Invoke (true);
		}
	}

	void DisablePlayer() {
		if (isLocalPlayer) {
			mainCamera.SetActive (true);
		}

		onToggleShared.Invoke (false);

		if (isLocalPlayer) {
			onToggleLocal.Invoke (false);
		} else {
			onToggleRemote.Invoke (false);
		}
	}
}
