using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	
	public static int light = 0;
	
	// Use this for initialization
	void Start () {
		light = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void Light(){
		light++;
	}
}
