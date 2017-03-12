using UnityEngine;
using System.Collections;

public class ShootPower : MonoBehaviour {

	public GameObject bullet;

	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.LeftControl)) 
		{
			
			var bullets =(GameObject) Instantiate (bullet,transform.position,transform.rotation);
			if (bullets!=null) {
				
				bullets.GetComponent<Rigidbody>().velocity= bullet.transform.forward*50;
				Debug.Log ("Fired");

			}
				
		
		

		}
	
	}
}
