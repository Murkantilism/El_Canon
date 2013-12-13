using UnityEngine;
using System.Collections;

public class AddLightPlateau : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.SendMessage("LightPlateau");
			transform.parent = col.gameObject.transform;
			transform.localPosition = Vector3.forward * 3;
		
		}
	}
}
