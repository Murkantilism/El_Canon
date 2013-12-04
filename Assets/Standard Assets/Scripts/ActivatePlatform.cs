using UnityEngine;
using System.Collections;

public class ActivatePlatform : MonoBehaviour {
	
	public GUIText switchHint;
	public static bool shouldMove = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			switchHint.SendMessage("ShowHint", "Press Shift to activate the platform");
		}
	}
}
