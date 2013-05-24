using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
	public float floatingApex = 1f;
	public float speed;
	public bool isForwardMovement = false;
	public MovingAxis movingAxis;
	private float originPoint;
	
	// Use this for initialization
	void Start ()
	{
		switch (movingAxis) {
		case MovingAxis.Horizontal:
			originPoint = transform.position.x;
			break;
		case MovingAxis.Vertical:
			originPoint = transform.position.y;
			break;
		}
	}
	
	void FixedUpdate ()
	{
		switch (movingAxis) {
		case MovingAxis.Horizontal:
			if (transform.position.x > originPoint + floatingApex) {
				rigidbody.MovePosition (new Vector3 (originPoint + floatingApex, transform.position.y, transform.position.z));
				isForwardMovement = !isForwardMovement;
			}
			if (transform.position.x < originPoint - floatingApex) {
				rigidbody.MovePosition (new Vector3 (originPoint - floatingApex, transform.position.y, transform.position.z));
				isForwardMovement = !isForwardMovement;
			}
		
			if (isForwardMovement) {
				rigidbody.velocity = new Vector3 (speed, 0f, 0f);
			} else {
				rigidbody.velocity = new Vector3 (-speed, 0f, 0f);
			}
			break;
		case MovingAxis.Vertical:
			if (transform.position.y > originPoint + floatingApex) {
				rigidbody.MovePosition (new Vector3 (transform.position.x, originPoint + floatingApex, transform.position.z));
				isForwardMovement = !isForwardMovement;
			}
			if (transform.position.y < originPoint - floatingApex) {
				rigidbody.MovePosition (new Vector3 (transform.position.x, originPoint - floatingApex, transform.position.z));
				isForwardMovement = !isForwardMovement;
			}
		
			if (isForwardMovement) {
				rigidbody.velocity = new Vector3 (0f, speed, 0f);
			} else {
				rigidbody.velocity = new Vector3 (0f, -speed, 0f);
			}
			break;
		}
		

	}
}

public enum MovingAxis
{
	Vertical,
	Horizontal
}