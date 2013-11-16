using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use pathfinding
using Pathfinding;
public class AstarAI : MonoBehaviour {
    //The point to move to
    public Vector3 targetPosition;
    
    public Seeker seeker;
    private CharacterController controller;
 
    //The calculated path
    public Path path;
    
    //The AI's speed per second
    public float speed = 100;
    
    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;
 
    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;
	
	public BlindEnemy blindEnemyAI;
 
    public void Start () {
        seeker = GetComponent<Seeker>();
        controller = GetComponent<CharacterController>();
		blindEnemyAI = GetComponent<BlindEnemy>();
        
        //Start a new path to the targetPosition, return the result to the OnPathComplete function
        seeker.StartPath (transform.position,targetPosition, OnPathComplete);
		
		seeker.pathCallback += OnPathComplete;
		// Invoke seekeing every 3 seconds
		InvokeRepeating("TriggerSeeker", 3, 1);
    }
    
	public void TriggerSeeker(){
		// Get the current target
		targetPosition = blindEnemyAI.targetPosition;
		
		//Start a new path to the targetPosition, return the result to the OnPathComplete function
        seeker.StartPath (transform.position, targetPosition, OnPathComplete);
	}
	
    public void OnPathComplete (Path p) {
		if (p.GetTotalLength() < 10000){
			Debug.Log("Play scury music");
		}
		
        Debug.Log ("Yey, we got a path back. Did it have an error? "+p.error);
        if (!p.error) {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
        }
    }
	
	public void SetSeeker(Vector3 targetPos){
		seeker = GetComponent<Seeker>();
		seeker.StartPath (transform.position, targetPos, OnPathComplete);
	}
 
    public void FixedUpdate () {
        if (path == null) {
            //We have no path to move after yet
            return;
        }
        
        if (currentWaypoint >= path.vectorPath.Count) {
            Debug.Log ("End Of Path Reached");
            return;
        }

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;
        controller.SimpleMove (dir);
        
        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
            currentWaypoint++;
            return;
        }
    }
} 