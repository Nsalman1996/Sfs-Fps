using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Requests;
using Sfs2X.Entities.Data;
using Sfs2X.Entities;
using Sfs2X.Logging;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class sfsChat : MonoBehaviour
{
    private static sfsChat SfsCHat;
    public static sfsChat _SfsCHat
    {
        get
        {
            if (SfsCHat == null)
            {
                GameObject sfsobject = new GameObject("sfs");
                SfsCHat = sfsobject.AddComponent<sfsChat>();
                DontDestroyOnLoad(sfsobject.gameObject);
           
			}
            return SfsCHat;
        }
    }
	public  SmartFox sfs;
	private SmartFox mSfs = null;
	private ISFSObject sfsobj;
	public string Ip = /*169.254.239.102*/"127.0.0.1";
	public string port = "9933";
    private string ZoneName = "BasicExamples";
    public string username;
	public int userID;
    private List<User> userList;
	private List<Room> roomList;
    private string roomName;
    [HideInInspector]
	public String winningPlayer;


    void Start()
	{
    }

	public void Init(String Username,String _roomName)
	{
		username = Username;
        roomName = _roomName;

        sfsEvents ();
	}
    void Update()
    {
        sfs.ProcessEvents();
    }

    void sfsEvents()
    {
        sfs = new SmartFox();
        sfs.AddEventListener(SFSEvent.CONNECTION, Onconnection);
        sfs.AddEventListener(SFSEvent.CONNECTION_LOST, ConnectionLost);
        sfs.AddEventListener(SFSEvent.CONNECTION_RETRY, Retry);
        sfs.AddEventListener(SFSEvent.LOGIN, OnLogin);
        sfs.AddEventListener(SFSEvent.LOGIN_ERROR, OnLoginError);
		sfs.AddEventListener(SFSEvent.ROOM_JOIN, onJoin);
		sfs.AddEventListener(SFSEvent.ROOM_JOIN_ERROR, onJoinError);
        sfs.AddEventListener(SFSEvent.EXTENSION_RESPONSE, onExtensionResponse);
        sfs.AddEventListener(SFSEvent.PUBLIC_MESSAGE, OnpublicMessage);      
        SfsConnect();
    }
    void SfsConnect()
    {      
       sfs.Connect(Ip, int.Parse(port));   
    }
    void Onconnection(BaseEvent evt)
    {
        if ((bool)evt.Params["success"])
        {
            Debug.Log("Connection established successfully");
            Debug.Log("SFS2X API version: " + sfs.Version);
            Debug.Log("Connection mode is: " + sfs.ConnectionMode);
            sfs.Send(new LoginRequest(username, "", ZoneName));
        }
        else
        {
            ConnectionLost(evt);
        }

    }
    void ConnectionLost(BaseEvent evt)
    {
        Debug.Log("Connection was lost reason is: " + (string)evt.Params["reason"]);
        Debug.Log(sfs.GetReconnectionSeconds());
		Retry (evt);
    }
    void Retry(BaseEvent evt)
    {
        sfs.Connect(Ip, int.Parse(port));
    }
    void OnLogin(BaseEvent evt)
    {
        Debug.Log("Logged In: " + evt.Params["user"]);
        User username_ = (User)evt.Params["user"];
        userID = username_.Id;
        Debug.Log(roomName);
        sfs.Send(new JoinRoomRequest(roomName));
    }
    void OnLoginError(BaseEvent evt)
    {
        Debug.Log("Login error: (" + evt.Params["errorCode"] + "): " + evt.Params["errorMessage"]);
    }
	void onJoin(BaseEvent evt)
    {
        if (roomName== "co-op")
        {
            SceneManager.LoadScene("game");
            Debug.Log(sfs);
            Debug.Log("Joined Room: " + evt.Params["room"]);
        }
        else if (roomName== "Situation")
        {
            SceneManager.LoadScene("Situatiion");
            Debug.Log(sfs);
            Debug.Log("Joined Room: " + evt.Params["room"]);
        }
      
    }
	public void startsending()
	{
		UserUpdate.userupdate.userConfigure(username);   
	}
    public void InformServer()
    {
        sfs.Send(new PublicMessageRequest("useradded"));

    }		

	void onJoinError(BaseEvent evt)
	{
		Debug.Log("Join failed: " + evt.Params["errorMessage"]);
	}
    void OnpublicMessage(BaseEvent evt)
    {
		string cmd = (string)evt.Params["message"];
		User sender = (User)evt.Params["sender"];
		Debug.Log (cmd);
		try
		{
			if (cmd == "useradded" ) 
			{
				UserUpdationControl();	

			}
			if (cmd == "Captured") 
			{
				WinCheck(sender);
			}
			if (cmd== "Fired") 
			{
				FiredProperty();
			}
		}
		catch(Exception e)
		{
			Debug.Log("Exception handling response: " + e.Message + " >>> " + e.StackTrace);
		}
         
    }
	private void FiredProperty()
	{
	}
	private void UserUpdationControl ()
	{
		roomList = sfs.GetRoomListFromGroup("default");
		foreach (Room room in roomList)
		{
			userList = room.UserList;
			Debug.Log(userList.Count);
			foreach (User user in userList)
			{
				Debug.Log (user+"added");
				Debug.Log(user.Id+user.Name);
				if (user.Name != username)
				{                 
					UserUpdate.userupdate.UsersList(user.Name);  
				}
			}
		}
	}
	public void Getflagtarget()
	{
		sfsobj = new SFSObject ();
		sfsobj.PutUtfString("getflag","get");
		sfs.Send(new ExtensionRequest ("flagValue",sfsobj));
        Debug.Log("flag get spawn");
	}
	private void WinCheck (User sender)
	{
		if (sender.Id != userID)
		{
			Debug.Log (sender.Name + "Wins the round");
			winningPlayer=sender.Name ;
		} else
		{
			Debug.Log(username + "Wins");
			winningPlayer = username;
		}
		SceneManager.LoadScene("GameOver");

	}
	public void SendTransform(Transform ntransform)
    {
		Debug.Log (ntransform);
		//JSONtransform.ToJson (ntransform);
		//Debug.Log(ntransform.ToString());
		sfsobj = new SFSObject ();
		//sfsobj.PutUtfString ("transform", ntransform.ToString());
		sfsobj.PutFloat ("X", ntransform.position.x);
		sfsobj.PutFloat ("Y", ntransform.position.y);
		sfsobj.PutFloat ("Z", ntransform.position.z);
		sfsobj.PutFloat ("RX", ntransform.rotation.x);
		sfsobj.PutFloat ("RY", ntransform.rotation.y);
		sfsobj.PutFloat ("RZ", ntransform.rotation.z);
		sfs.Send (new ExtensionRequest("sendTransform",sfsobj));  
		Debug.Log("transform sent");
    }
	/*public void FlagSpqwn(Transform[] spawnPoints)
	{
		JSONtransform.SpawnToJson (spawnPoints);
		Debug.Log (spawnPoints.ToString());
		sfsobj = new SFSObject ();
		sfsobj.PutUtfString ("SpawnPoints", spawnPoints.ToString());
		Debug.Log (sfsobj.ToJson ());
		sfs.Send (new ExtensionRequest ("flagValue", sfsobj));
	}*/
    void onExtensionResponse(BaseEvent evt)
    {
	        Debug.Log("Response incoming");  
		Debug.Log (evt.Params["cmd"]);
        string cmd = (string)evt.Params["cmd"];
		SFSObject dt = (SFSObject)evt.Params["params"];
		Debug.Log (cmd);

        try
		{
            if (cmd == "transform") 
			{
				HandleTransform(dt);	
			}
			if (cmd == "FlagPosition") 
			{
			HandleFlagTransform(dt);
			}
        }
        catch(Exception e)
        {
            Debug.Log("Exception handling response: " + e.Message + " >>> " + e.StackTrace);
        }
	}     
	void HandleTransform(SFSObject data )
    {
        Room room = sfs.LastJoinedRoom;
         userList = room.UserList;
		SFSDataWrapper TData = data.GetData("Position");
		String Ddata="";
		Ddata = TData.Data.ToString();
		int playerID=data.GetInt ("playerID");
		//string Tansform=data.GetUtfString("Position");
		//Debug.Log (Tansform);
		JSONtransform.FromSFSObject (Ddata,playerID);             
    }
	void HandleFlagTransform(SFSObject data)
	{
		Debug.Log (data);
		Room room = sfs.LastJoinedRoom;
		userList = room.UserList;
		SFSDataWrapper STData = data.GetData ("transform");
		String SData="";
		SData = STData.Data.ToString ();
		Debug.Log (SData);
        JSONtransform.flagPosition(SData);




    }

	public void OnApplicationQuit()
    {
        sfs.Disconnect();
    }
}
