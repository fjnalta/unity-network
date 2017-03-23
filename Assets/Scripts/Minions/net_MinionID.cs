using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class net_MinionID : NetworkBehaviour {

	[SyncVar] public string minionID;
	private Transform myTransform;

	// Use this for initialization
	void Start () 
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		SetIdentity();
	}

	void SetIdentity()
	{
		if(myTransform.name == "" || myTransform.name == "gnollcaster(Clone)")
		myTransform.name = minionID;
	}
}
