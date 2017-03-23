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
		CmdCastSpell (Color.red);
	}

	public override void Spell2() {
		CmdCastSpell (Color.blue);
	}

	public override void Spell3() {
		CmdCastSpell (Color.green);
	}

	public override void Spell4() {
		CmdCastSpell (Color.yellow);
	}

	public override void Spell5() {
		CmdCastSpell (Color.magenta);
	}
}
