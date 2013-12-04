using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	
	public Transform origin;
	public Transform destination;
	bool back = false;
	public float speed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(ActivatePlatform.shouldMove)
		{
			if(transform.position == destination.position)
			{
				
				back = true;
				
			}
			if(transform.position == origin.position)
				back = false;
			if(back)
				transform.position = Vector3.MoveTowards(transform.position,
					origin.position, speed);
			else 
				transform.position = Vector3.MoveTowards(transform.position,
					destination.position, speed);
		}
	}
}
