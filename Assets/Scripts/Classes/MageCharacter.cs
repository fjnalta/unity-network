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
		CmdCastSpell (Color.red, target.getTarget (), this.gameObject, this.gameObject);
	}

	public override void Spell2() {
		CmdCastSpell (Color.blue, target.getTarget (), this.gameObject, this.gameObject);
	}

	public override void Spell3() {
		CmdCastSpell (Color.green, target.getTarget (), this.gameObject, this.gameObject);
	}

	public override void Spell4() {
		CmdCastSpell (Color.yellow, target.getTarget (), this.gameObject, this.gameObject);
	}

	public override void Spell5() {
		CmdCastSpell (Color.magenta, target.getTarget (), this.gameObject, this.gameObject);
	}
}