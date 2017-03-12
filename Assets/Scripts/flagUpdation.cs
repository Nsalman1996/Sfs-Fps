using UnityEngine;
using System.Collections;

public class flagUpdation : MonoBehaviour {

	public GameObject flag;
  
	// Use this for initialization
	void Start () {

		sfsChat._SfsCHat.Getflagtarget ();
        Debug.Log("getflag");
        JSONtransform.flagPosition(flag.transform.localPosition);
        Debug.Log(flag.transform.position);
     

    }

	
	// Update is called once per frame
	void Update () {
     
	}

    void createFlag()
    {
        Debug.Log("flag");
     
           
        
      
    }

}
