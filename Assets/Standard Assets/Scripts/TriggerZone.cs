using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

	public GUIText hint;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			if (Inventory.light == 1)
			{
				
				Transform colPos = col.gameObject.transform;
				colPos.position = new Vector3(transform.position.x, 55, transform.position.z);
				colPos = col.gameObject.transform;
				Destroy(GameObject.FindWithTag("LightSource"));
			} else hint.SendMessage("ShowHint", "This looks like it can be jumped on to reach the " +
				"next level, but it needs a light source to open up");
		}
	}
}
