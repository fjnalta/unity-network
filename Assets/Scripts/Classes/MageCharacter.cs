using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MageCharacter : PlayerCharacter {

	void Start() {
		health = 200;
		resource = 200;
		secondResource = "Mana";
	}

	public override void Spell1() {
		Debug.Log ("I am a Mage");

	}

	public override void Spell2() {
		Debug.Log (curlevel);
	}

	public override void Spell3() {
		Debug.Log (health);
	}

	public override void Spell4() {
		Debug.Log (resource);
	}

	public override void Spell5() {
		Debug.Log (secondResource);
	}
}
