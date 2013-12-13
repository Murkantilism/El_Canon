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
			if (Inventory.groundLight)
			{
				col.gameObject.SendMessage("Jump");
				Destroy(GameObject.FindWithTag("LightShine1"));
			} else if (Inventory.plateauLight)
			{				
				col.gameObject.SendMessage("Jump");
				Destroy(GameObject.FindWithTag("LightShine2"));
			}
				else hint.SendMessage("ShowHint",
				"This flower looks like it can be jumped on to reach " +
				"the next level, but it needs a light source to activate.");
		}
	}
}
