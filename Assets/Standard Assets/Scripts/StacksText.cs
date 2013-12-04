using UnityEngine;
using System.Collections;

public class StacksText : MonoBehaviour {
	GameObject playerCharacter;
	PlayerDeath playerDeath;
	
	// Use this for initialization
	void Start () {
		playerCharacter = GameObject.Find("Player");
		playerDeath = playerCharacter.GetComponent<PlayerDeath>();
	}
	
	// Update is called once per frame
	void Update () {
		SetPosition();
		StacksString();
	}
	
	void SetPosition(){
		guiText.pixelOffset = new Vector2(Screen.width / 500, (float)Screen.height / 2.5f);
	}
	
	// Gets the amount of stacks from the PlayerDeath script and
	// converts them to a GUI Text object
	void StacksString(){
		guiText.text = ("Blind Stacks: " + playerDeath.blindStacks.ToString() + 
						"    Deaf Stacks: " + playerDeath.deafStacks.ToString());
	}
}
