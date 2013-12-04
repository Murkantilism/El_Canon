using UnityEngine;
using System.Collections;

public class PlayerBounce : MonoBehaviour {
	
	
	CharacterMotor playerMotor;
	
	// Use this for initialization
	void Start () {
		playerMotor = gameObject.GetComponent<CharacterMotor>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Jump()
	{
		playerMotor.SetVelocity(new Vector3(0,40,0));	
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "BouncyPlatform")
		{
			gameObject.SendMessage("Jump");
		}
	}
	
	
}
