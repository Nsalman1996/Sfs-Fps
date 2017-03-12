using UnityEngine;
using System.Collections;
public class Ai : MonoBehaviour {

    NavMeshAgent NAgent;
  // public Camera cam;
  public  Transform target;
	// Use this for initialization
	void Start () {
        NAgent = this.GetComponent<NavMeshAgent>();
            }
	
	// Update is called once per frame
	void Update () {        
                NAgent.destination=target.position; 
    }
}
