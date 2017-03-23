using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class net_WarriorClass : net_CharacterClass {

	public GameObject lvlupPrefab;

	//Constructor
	public net_WarriorClass(){

		//Basic Stats
		CharacterClassName = "Warrior";
		Health = 100;
		Rage = 100;
		SecondResource = "Rage";


		//set Base stats;
		//Attackpower Formula: (Strength x 2) + (Char.Level x 3) - 20
		AttackPower = (Strength * 2) + (CurLevel * 3) - 20;

		//Stamina provides 1 health per stamina for the first 20 points of stamina,
		//and 10 health per point of stamina thereafter.
		Health += (Stamina * 8);

	}

	[Client]
	public override void Spell1(GameObject target){
		if (target != null) {
			CmdApplyDamage (target, 10);
//			Debug.Log ("Spell1 WARRIOR");
		}
	}

	[Client]
	public override void Spell2(){
		Debug.Log (AttackPower);
		Debug.Log (Stamina);
	}

	[Client]
	public override void Spell3(){
		LevelUp ();
	}

	[Client]
	public override void LevelUp(){
		Strength += 3;
		Stamina += 2;

		Health = 100 + (Strength * 8) + Stamina;
		AttackPower = (Strength * 2) + (CurLevel * 3) - 20;
		CurLevel += 1;

		//Instantiate the lvlUpPrefab
		GameObject lvlUp  = Instantiate (lvlupPrefab, transform.position, Quaternion.identity) as GameObject;
		lvlUp.transform.parent = gameObject.transform;
	}
}

