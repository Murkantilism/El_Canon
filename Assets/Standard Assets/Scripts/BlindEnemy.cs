using UnityEngine;
using System.Collections;

// Handle basic AI for blind enemies
public class BlindEnemy : MonoBehaviour {
	// Get the player character to access noise level variable
	public GameObject playerCharacter;
	public PlayerNoise playerNoise;
	// The current target for this AI (passed off to AstarAI.cs)
	public Vector3 targetPosition;
	
	// Has this agent detected the player at all?
	public bool detected;
	
	public AstarAI aStarAIObj;
	
	// Use this for initialization
	void Start () {
		playerCharacter = GameObject.Find("Player");
		playerNoise = playerCharacter.GetComponent<PlayerNoise>();
		// Default target position
		targetPosition = playerCharacter.transform.position;
		aStarAIObj = GetComponent<AstarAI>();
		aStarAIObj.SendMessage("SetSeeker", targetPosition);
	}
	
	// Update is called once per frame
	void Update () {
		NoiseDetection();
	}
	
	// Calculate the distance between this enemy and the player
	Vector3 DistToPlayer(){
		return gameObject.transform.position - playerCharacter.transform.position;
		
	}
	
	// Calculate when the enemy should detect player based on noise
	void NoiseDetection(){
		// If the enemy is less than 20 units away from player in any direction
		if (DistToPlayer().x < 100 || DistToPlayer().y < 100 || DistToPlayer().z < 100){
			// If the noise level is over 20 and the agent hasn't already detected
			// anything, trigger basic awareness of enemy
			if (playerNoise.noiseLevel > 20 && detected == false){
				detected = true;
				// Invoke basic pathing in some random direction
				targetPosition = new Vector3(Random.Range(-100, 500), 1.05f, Random.Range(-300, 300));
				aStarAIObj.SendMessage("SetSeeker", targetPosition);
				
			// If the noise level is over 40, trigger seeking for player
			}else if(playerNoise.noiseLevel > 40 && detected == true){
				// Invoke seeking, going towards a direction generally near player
				// In order to "seek" in players general direction, add a random value
				// to the player's current position, and have the AI agent seek there.
				targetPosition =  new Vector3(playerCharacter.transform.position.x + Random.Range(-10, 10),
					                          playerCharacter.transform.position.y,
					                          playerCharacter.transform.position.z + Random.Range(1, 10));
				aStarAIObj.SendMessage("SetSeeker", targetPosition);
			
			// If the noise level is over 70, enemy will know where player is
			}else if(playerNoise.noiseLevel > 70 && detected == true){
				// Head straight for the player
				targetPosition = playerCharacter.transform.position;
				aStarAIObj.SendMessage("SetSeeker", targetPosition);
			}
		}
	}
}
