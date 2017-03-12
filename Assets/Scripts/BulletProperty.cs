using UnityEngine;
using System.Collections;

public class BulletProperty : MonoBehaviour {
	private int delay = 10;
	// Use this for initialization
	void Start () {
		Destroy(this.gameObject,delay);
	}
	
	// Update is called once per frame
	void Update () {
		
		//this.transform.Translate (new Vector3 (0.0f, 0f, 5.0f) * Time.deltaTime);
	}
}
