using UnityEngine;
using System.Collections;

//public enum Type{PlusPosition, ForceRigidbody}

public class Plita : MonoBehaviour {
	//public Type TypeOf;
	public Transform myTransform;
	public int speed;
	public int jumpImpulse;
	public bool isJump; //чтобы игрок постоянно не прыгал
	
	void Start(){
		myTransform = transform;
	}
	
	void Update(){
		
		
				myTransform.position += myTransform.forward * speed * Time.deltaTime;
		
	}
	
}