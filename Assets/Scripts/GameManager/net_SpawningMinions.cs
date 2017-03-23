using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class net_SpawningMinions : NetworkBehaviour {
	
	[SerializeField] GameObject gnollcasterPrefab;
	[SerializeField] GameObject minionSpawn;

	//Minion Counter
	private int counter;

	public override void OnStartServer () {
		SpawnMinions ();
	}
	
	void SpawnMinions(){
		counter++;
		GameObject go = GameObject.Instantiate (gnollcasterPrefab, minionSpawn.transform.position, Quaternion.identity) as GameObject;
		NetworkServer.Spawn (go);
		go.GetComponent<net_MinionID>().minionID = "Minion " + counter;
	}
}
