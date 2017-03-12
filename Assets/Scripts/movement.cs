using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    Rigidbody Player;
    public float speed = 10f;
    public bool isGrounded; 
	// Use this for initialization
	void Start () {
        Player = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0));
        this.transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime));
	}
}
