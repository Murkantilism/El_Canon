using UnityEngine;
using System.Collections;

public class DeafEnemy : MonoBehaviour {
	public GameObject playerCharacter;
	
	// The field of view for the agent, 68 gives agent 136 degree vision
	float fieldOfView = 68;
	// The distance the player can come from behind the agent without being detected
	float minPlayerDetectDistance;
	// The distance the agent can see in front of him
	float rayRange;
	// The direction of the ray cast ray
	Vector3 rayDirection = Vector3.zero;
	// This transform's position
	Vector3 _transformPos;
	
	// Use this for initialization
	void Start () {
		playerCharacter = GameObject.Find ("Player");
		_transformPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		CanSeePlayer();
	}
	
	// Draws a line in front of and behind the agent, used to visualize 
	// the detection ranges in front and behind the agent.
	public void OnDrawGizmos(){
		Gizmos.color = Color.magenta; // Color used to detect player in front
		Gizmos.DrawRay(_transformPos, transform.forward * rayRange);
		Debug.DrawRay(_transformPos, transform.forward * rayRange);
		Gizmos.color = Color.yellow; // Color used to detect player from behind
		Gizmos.DrawRay(_transformPos, transform.forward * minPlayerDetectDistance);
		Debug.DrawRay(_transformPos,  transform.forward * minPlayerDetectDistance);
	}
	
	bool CanSeePlayer(){
		RaycastHit hit;
		rayDirection = playerCharacter.transform.position - _transformPos;
		
		float distanceToPlayer = Vector3.Distance(_transformPos, playerCharacter.transform.position);
		
		if (Physics.Raycast(transform.position, rayDirection, out hit)){
			// If the player is in view the enemy will detect the player
			if ((hit.transform.tag == "Player") && (distanceToPlayer <= minPlayerDetectDistance)){
				Debug.Log("Caught player sneaking up behind!");
				return true;
			}else{
				return false;
			}
		}
		
		// Detect if player is within field of view
		if (Vector3.Angle(rayDirection, transform.forward) < fieldOfView){
			if (Physics.Raycast(transform.position, rayDirection, out hit, rayRange)){
				if (hit.transform.tag == "Player"){
					Debug.Log("Player spotted");
					return true;
				}else{
					return false;
				}
			}else{
				return false;
			}
		}
		Debug.DrawRay(_transformPos, transform.forward * rayRange, Color.red);
		Debug.DrawRay(_transformPos, transform.forward * minPlayerDetectDistance, Color.red);
		// Otherwise return false
		return false;
	}
}
