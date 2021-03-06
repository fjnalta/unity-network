﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MouseOver : NetworkBehaviour {

	private Renderer ren;
	private Shader originalShader;
	private Shader outline;


	void Awake() {
		outline = Shader.Find ("Custom/Outline");
		originalShader = Shader.Find("Legacy Shaders/Self-Illumin/Bumped Diffuse");
	}

	void Start() {
		if (gameObject.tag == "Minion") {
			ren = GetComponent<MeshRenderer> ();
		}
		if (gameObject.tag == "Player") {
			ren = GetComponentInChildren<SkinnedMeshRenderer> ();
		}

	}

	void OnMouseOver() {
		if (!isLocalPlayer) {
			for(int i = 0; i < ren.materials.Length; i++) {
				ren.materials[i].shader = outline;
			}
		}
	}

	void OnMouseExit() {
		if (!isLocalPlayer) {
			for (int i = 0; i < ren.materials.Length; i++) {
				ren.materials[i].shader = originalShader;
			}
		}
	}
}
