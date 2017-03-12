using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class test : MonoBehaviour {
	
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space)) 
		{
			rb.velocity =new Vector3(0f, 5f, 0f);
			//(0f,5*Time.fixedDeltaTime,0f);
		}	
	
	}
}
