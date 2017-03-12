using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;



public class UserUpdate : MonoBehaviour

{
	public static UserUpdate userupdate;
    public GameObject PlayerPrefab;
    public  float sendingPeriod = 0.5f;
    private float timeLastSending = 0.0f;
	public GameObject otherplayers;
	private bool send;
	private bool recieve;
    void Start()
    {
		userupdate = this;
        sfsChat._SfsCHat.InformServer();    
        sfsChat._SfsCHat.startsending ();         
    }
	public void UsersList(string userId)
    {     
        if (otherplayers.name!=userId.ToString())
        {
            otherplayers = Instantiate(otherplayers);
            otherplayers.name = userId.ToString();
            otherplayers.layer = LayerMask.NameToLayer("RemotePlayer");
     	    Debug.Log(otherplayers.name);
        }
    }
	public void userConfigure(string username)
    {
		if (PlayerPrefab!=null)
		{
			PlayerPrefab.name= username.ToString();
            PlayerPrefab.layer = LayerMask.NameToLayer("LocalPlayer");
		} 
    }
	void startsendingTransform()
	{
		send = true;
		recieve = true;
	}
	void FixedUpdate()
	{
        startsendingTransform();
        if (send) 
		{
		SendTransform ();
		GetTransform ();
		}
	}
	void SendTransform()
    {	
		if (timeLastSending >= sendingPeriod) {
			Debug.Log (PlayerPrefab.transform);
			sfsChat._SfsCHat.SendTransform(PlayerPrefab.transform);
			timeLastSending = 0;
			return;
	}
		timeLastSending += Time.deltaTime;
	}
	void GetTransform()
	{	
		if	(otherplayers!=null)
		{	
			JSONtransform.sendtransform(otherplayers.transform);
		}
	}



}
    

