using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour {

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
		ren.material.shader = outline;
	}

	void OnMouseExit() {
			ren.material.shader = originalShader;
	}
}
