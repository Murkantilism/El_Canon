using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	
	public static bool groundLight = false;
	public static bool plateauLight = false;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(groundLight);
	}
	
	void LightGround(){
		groundLight = true;
	}
	
	void LightPlateau(){
		plateauLight = true;	
	}
}
