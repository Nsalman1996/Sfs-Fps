using System;
using System.Collections;
using UnityEngine;
using Sfs2X.Entities.Data;
using SimpleJSON;
using System.Collections.Generic;
public class JSONtransform
{
	private JSONtransform()
	{
	}
	private static JSONtransform trans = new JSONtransform();
	public  Vector3 position;
	public   Vector3 recievingposition;
	public Vector3 recievingrotation;
    public Vector3 FlagPosition;
	public int UserID;
	public static Transform getposition(Transform _position)
    {
        trans.position = _position.position;    
		return _position;
    }
  /*  public void ToSFSObject(ISFSObject data)
    {
        ISFSObject tr = new SFSObject();

        tr.PutDouble("x", Convert.ToDouble(trans.position.x));
        tr.PutDouble("y", Convert.ToDouble(trans.position.y));
        tr.PutDouble("z", Convert.ToDouble(trans.position.z));
        if (tr != null)
        {
            data.PutSFSObject("transform", tr);
        }
    }*/
	public static String ToJson(Transform data)
	{
		var Pos = JSONNode.Parse ("{}");
		//  Pos.Add ("POS", transformData);
		//	var PosX = JSONNode.Parse ("{}");
		Pos.Add ("x", data.position.x.ToString());
		//	var PosY = JSONNode.Parse ("{}");
		Pos.Add ("y", data.position.y.ToString());
		//	var PosZ = JSONNode.Parse ("{}");
		Pos.Add ("z", data.position.z.ToString());
		Debug.Log (Pos);
		return Pos;
	}
	/*public static String SpawnToJson(Transform[] data)
	{
		Debug.Log (data [0]);
		Transform spawn1 = data [0];
		ToJson(spawn1);
		Debug.Log (spawn1.position.ToString());
		Debug.Log (data [1].ToString());
		Transform spawn2 = data [1];
		ToJson (spawn2);
		Debug.Log (spawn2.position.ToString());
		Debug.Log (data [2].ToString());
		Transform spawn3 = data [2];
		ToJson (spawn3);
		Debug.Log (spawn3.position.ToString());
		var flag = JSONNode.Parse ("{}");
		flag.Add("Spawn1",spawn1.position.ToString());
		flag.Add("Spawn2",spawn2.position.ToString());
		flag.Add("Spawn3",spawn3.position.ToString());
		Debug.Log (flag.ToString ());
			return flag;
	}*/
	public static void FromSFSObject(String Data, int PlayerID)
	{
		trans.UserID = PlayerID;
		Debug.Log (Data);
		Debug.Log (trans.UserID);
		Debug.Log(sfsChat._SfsCHat.userID);
		if (trans.UserID !=sfsChat._SfsCHat.userID)
		{
			var parseddata = JSONNode.Parse (Data);
			Debug.Log (parseddata);
		//	string parseddata_ = parseddata ["Position"].Value;
		//	Debug.Log (parseddata_);
		//	var data_ = JSONNode.Parse (parseddata_);
			//Debug.Log (data_);
			float PosX = parseddata ["X"].AsFloat;
			float PosY = parseddata ["Y"].AsFloat;
			float PosZ = parseddata ["Z"].AsFloat;
			float Rotrx = parseddata ["RX"].AsFloat;
			float Rotry = parseddata ["RY"].AsFloat;
			float Rotrz = parseddata ["RZ"].AsFloat;
			Debug.Log (PosX + PosY + PosZ);
			trans.recievingposition = new Vector3 (PosX, PosY, PosZ);
			trans.recievingrotation = new Vector3 (Rotrx,Rotry,Rotrz);
			Debug.Log (trans.recievingposition);
			Debug.Log("othertransformgot");
		}
	}
    public static void flagPosition(String data)
    {
        var parseddata = JSONNode.Parse(data);
        Debug.Log(parseddata);
        float PosX = parseddata["X"].AsFloat;
        float PosY = parseddata["Y"].AsFloat;
        float PosZ = parseddata["Z"].AsFloat;
        trans.FlagPosition = new Vector3(PosX, PosY, PosZ);
        Debug.Log(PosX);
    }
    public static Transform sendtransform(Transform transform)
    {
        transform.position = trans.recievingposition;
		transform.localEulerAngles = trans.recievingrotation;
		return transform;
    }
    public static Vector3 flagPosition(Vector3 trasform)
    {
        trasform = trans.FlagPosition;
        Debug.Log(trasform);
        return trasform;
        
    }

}
