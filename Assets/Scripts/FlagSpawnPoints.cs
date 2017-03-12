using UnityEngine;
using System.Collections;
using Sfs2X;
using Sfs2X.Requests;


public class FlagSpawnPoints : MonoBehaviour {
	private int UserID;
    

	void Start ()
	{
		UserID = sfsChat._SfsCHat.userID;
	}
	void Update () {
	
	}
	void OnTriggerEnter(Collider trigger)
	{
		if (trigger.gameObject.tag == "Player")
		{
			sfsChat._SfsCHat.sfs.Send(new PublicMessageRequest("Captured"));	
		}
	}
}
