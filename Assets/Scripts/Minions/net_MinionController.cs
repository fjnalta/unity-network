using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class net_MinionController : NetworkBehaviour {

	[SyncVar] private int syncHealth;
//	private int armor = 0;

	void Start(){
		this.syncHealth = 100;
	}

	public void DoDamage (int dmg)
	{
		syncHealth -= dmg;
		CheckHealth();
	}

	void CheckHealth()
	{
		if(syncHealth <= 0)
		{
			Destroy(gameObject);
		}
	}

	public int Health{
		get{ return this.syncHealth;}
	}
}
