using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sfsconnection : MonoBehaviour {


	public InputField username;
    private string roomName;
    public Camera cam;

    void Start () {
      

	}
	void Update () 
	{
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                roomName = hit.transform.name;
                Debug.Log(roomName);
            }
        }
        

            }

	public void connectPlayer()
	{
		if (username!=null)
		{
            Debug.Log(roomName.ToString());
            sfsChat._SfsCHat.Init (username.text, roomName);
		}
		Debug.Log("Enter Username");

	}
	 

	public void Disconnect()
	{
		sfsChat._SfsCHat.OnApplicationQuit ();
		SceneManager.LoadScene("Login");
	
	}

}
