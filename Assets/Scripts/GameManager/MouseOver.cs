using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MouseOver : NetworkBehaviour {

	private Renderer ren;
	private Shader originalShader;
	private Shader outline;

	void Awake() {
		outline = Shader.Find (("Custom/Outline"));
	}

	void Start() {
		ren = GetComponent<Renderer> ();
		originalShader = ren.material.shader;
	}

	void OnMouseOver() {
		if (!isLocalPlayer) {
			ren.material.shader = outline;
		}
	}

	void OnMouseExit() {
		if (!isLocalPlayer) {
			ren.material.shader = originalShader;
		}
	}
}
