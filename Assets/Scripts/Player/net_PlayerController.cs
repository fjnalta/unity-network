using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class net_PlayerController : NetworkBehaviour {

	//this script gets the common player settings like name, class, team, talents

	//it also provides basic interactions like transmiting dmg
	//respawning
	private net_CharacterClass playerClass;


	public void DoDamage (int dmg) {
		playerClass = GetComponent<net_CharacterClass> ();
		playerClass.Health -= dmg;
		CheckHealth();
	}

	void CheckHealth() {
		if(playerClass.GetComponent<net_CharacterClass>().Health <= 0)
		{
			Destroy(gameObject);
		}
	}
}