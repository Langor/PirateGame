using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	public Transform myTransform;
	public float groundSpeed;
	public float airSpeed;
	public float jumpImpulse;
	public bool isJump; //чтобы игрок постоянно не прыгал
	private bool isOnGround;
	
	void Start ()
	{
		myTransform = transform;
	}
	
	void FixedUpdate ()
	{
		Debug.Log (isOnGround);
		if (isOnGround) {
			myTransform.rigidbody.AddForce (Input.GetAxis ("Horizontal") * myTransform.right * groundSpeed * Time.deltaTime, ForceMode.Impulse);
			if (Input.GetButtonDown ("Jump")) {
				Jump ();
			}
		} else {
			myTransform.rigidbody.AddForce (Input.GetAxis ("Horizontal") * myTransform.right * airSpeed * Time.deltaTime, ForceMode.Impulse);
		}
	}

	void Jump ()
	{
		myTransform.rigidbody.AddForce (Vector3.up * jumpImpulse * Time.deltaTime, ForceMode.Impulse);
	}
	
	void NewLevel ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel ("Scene3");
		}
	}
	
	void OnCollisionStay (Collision info)
	{
		if (info.collider.tag == "Floor") {
			isOnGround = true;
		}
	}
	
	void OnCollisionExit ()
	{
		isOnGround = false;
	}

	bool IsOnGround ()
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit)) {
			if (hit.distance < 1.1f) {
				return true;
			}
		}
		return false;
	}
}
