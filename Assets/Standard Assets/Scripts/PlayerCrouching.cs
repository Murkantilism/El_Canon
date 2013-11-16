using UnityEngine;
using System.Collections;

public class PlayerCrouching : MonoBehaviour {
	public GameObject playerCharacter;
	public CharacterController playerController;
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
	public float crouchDampSpeed = 0.0F;
	
	// Use this for initialization
	void Start () {
		playerCharacter = GameObject.Find("Player");
		playerController = playerCharacter.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		// If the player is holding shift to crouch and moving, increase crouch
		// damping speed to reduce player speed
		if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && (Input.GetKey(KeyCode.W))){
	        crouchDampSpeed = 5.0F;
		// If the player is not holding crouch (or holding crouch but not moving)
		// set crouch damping to zero.
		} else {
			crouchDampSpeed = 0.0F;
		}
		
		transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
		// Move the player, taking into account crouch damping
        playerController.SimpleMove(forward * (curSpeed - crouchDampSpeed));
	}
}
