using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
	GameObject playerCharacter;
	CharacterController playerController;
	
	// Keep track of impairment stacks
	private int tooManyStacks = 5;
	public int blindStacks = 0;
	public int deafStacks = 0;
	
	// Black texture used to fade out at death
	public GUITexture fadeToBlackTexture;
	// Alpha value used to fade out at death
	float alphaFadeValue = 0;
	
	// Alpha value used to fade away AI
	float AI_alphaFadeValue = 1;
	
	// Use this for initialization
	void Start () {
		playerCharacter = GameObject.Find("Player");
		playerController = playerCharacter.GetComponent<CharacterController>();
		
		// Set fade black texture invisisble at beginning
		fadeToBlackTexture.color = new Color(255, 255, 255, alphaFadeValue);
	}
	
	// Update is called once per frame
	void Update () {
		EndGame();
	}
	
	// If the player collides with an AI agent, add a stack of impairment
	void OnTriggerEnter(Collider col){
		// If the enemy is Blind add a stack of blindess
		if(col.gameObject.tag == "BlindEnemy"){
			Debug.Log("Blind Enemy Hit!!!");
			FadeAwayAI(col.transform.parent.gameObject);
			//Destroy(col.transform.parent.gameObject);
			blindStacks++;
		}
		// If the enemy is Deaf, add a stack of deafness
		if(col.gameObject.tag == "DeafEnemy"){
			FadeAwayAI(col.transform.parent.gameObject);
			//Destroy(col.transform.parent.gameObject);
			deafStacks++;
		}
	}
	
	// If the player has too many stacks of either 
	// impairment, end game
	void EndGame(){
		if (blindStacks >= tooManyStacks || deafStacks >= tooManyStacks){
			FadeOutToBlack();
			// Invoke level restart after 8 seconds
			Invoke("Restart", 8);
		}
	}
	
	// Fade screen out to black
	private void FadeOutToBlack(){
		// Dividing by 7 makes fade last 7 seconds
		alphaFadeValue += Mathf.Clamp01(Time.deltaTime / 7);
		fadeToBlackTexture.color = new Color(0, 0, 0, alphaFadeValue);
	}
	
	private void Restart(){
		Application.LoadLevel(0);
	}
	
	// Fade AI agent away
	private void FadeAwayAI(GameObject agent){
		AI_alphaFadeValue -= Mathf.Clamp01(Time.deltaTime / 5);
		agent.renderer.material.color = new Color(128, 128, 128, AI_alphaFadeValue);
		
		if (AI_alphaFadeValue == 0){
			Destroy(agent.transform.parent.gameObject);
		}
		
		// Reset alpha value
		//AI_alphaFadeValue = 1;
	}
	
}
