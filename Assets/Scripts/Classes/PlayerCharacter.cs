using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/* Basic Character Class. Defining Stats and Spells here
 * Fields have to be synced across the network */
public abstract class PlayerCharacter : NetworkBehaviour {

	private Material mat;
	public PlayerTargeting target;

	// Genaral
	[SyncVar] private string playerName;

	// Levels
	private int maxlevel = 20;
	[SyncVar] public int curlevel = 1;

	//Basic Stats
	[SyncVar] public int health;
	[SyncVar] public int resource;
	// Resource Name
	[SyncVar] public string secondResource;

	void Awake () {
		target = gameObject.GetComponent<PlayerTargeting> ();
	}


	void Update () {
		if (Input.GetButtonDown ("Spell1")) {
			Spell1 ();
		}
		if (Input.GetButtonDown ("Spell2")) {
			Spell2 ();
		}
		if (Input.GetButtonDown ("Spell3")) {
			Spell3 ();
		}
		if (Input.GetButtonDown ("Spell4")) {
			Spell4 ();
		}
		if (Input.GetButtonDown ("Spell5")) {
			Spell5 ();
		}
	}

	public virtual void Spell1() {
		Debug.Log ("Spell1");
	}

	public virtual void Spell2() {
		Debug.Log ("Spell2");
	}

	public virtual void Spell3() {
		Debug.Log ("Spell3");
	}

	public virtual void Spell4() {
		Debug.Log ("Spell4");
	}

	public virtual void Spell5() {
		Debug.Log ("Spell5");
	}

	// Network related stuff
	// ---------------------

	// Process only on server
	[Command]
	public void CmdCastSpell(Color color, GameObject target, GameObject origin, GameObject spell) {
		Debug.Log ("To: " + target + "From: " + origin);
		RpcProcessSpellCastEffects (color, spell);
	}

	// Tell all Clients about the Changes
	[ClientRpc]
	public void RpcProcessSpellCastEffects(Color color, GameObject spell) {

		// Instantiate Spell Prefab
//		Instantiate (spell, gameObject.transform.position, Quaternion.identity);
	}
}
