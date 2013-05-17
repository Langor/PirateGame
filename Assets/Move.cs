using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	public Transform myTransform;
	public float groundSpeed;
	public float airSpeed;
	public float jumpImpulse;
	public bool isJump; //чтобы игрок постоянно не прыгал
	
	void Start ()
	{
		myTransform = transform;
	}
	
	void Update ()
	{
		Debug.Log (isOnGround ());
		if (isOnGround ()) {
			myTransform.rigidbody.AddForce (Input.GetAxis ("Horizontal") * myTransform.right * groundSpeed * Time.deltaTime, ForceMode.Impulse);
			if (Input.GetKeyDown (KeyCode.Space)) {
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
	
	bool isOnGround ()
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
