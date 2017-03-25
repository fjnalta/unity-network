using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MinionController : NetworkBehaviour {

	[SyncVar] private string minionName; 
	[SyncVar] private int health;
//	private int armor = 0;

	void Start(){
		this.health = 100;
	}

	public void DoDamage (int dmg)
	{
		health -= dmg;
		CheckHealth();
	}

	void CheckHealth()
	{
		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}

	public int Health{
		get{ return this.health;}
	}
}
