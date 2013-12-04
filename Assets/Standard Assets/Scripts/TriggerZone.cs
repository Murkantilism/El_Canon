using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

	public GUIText hint;
	
	float count = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			if (Inventory.light == 1)
			{
				col.gameObject.SendMessage("Jump");
				Destroy(GameObject.FindWithTag("LightSource"));
			} else hint.SendMessage("ShowHint", "This flower looks like it can be jumped on to reach the next level, but it needs a light source to activate.");
		}
	}
}
