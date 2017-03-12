using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Winningplayer : MonoBehaviour {
	public Text win;
	// Use this for initialization
	void Start () {
		win.text =sfsChat._SfsCHat.winningPlayer;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
