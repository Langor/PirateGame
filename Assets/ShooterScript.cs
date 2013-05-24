using UnityEngine;
using System.Collections;

public class ShooterScript : MonoBehaviour {
	
	public Transform bullet;
	public int BulletForce = 5000;
	public int BombCount = 5;
	public AudioClip Shoot;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){
			Transform BulletInstance = (Transform)Instantiate(bullet, GameObject.Find("BulletPlace").transform.position, Quaternion.identity); //объект, позиция, поворот
			BulletInstance.rigidbody.AddForce(Vector3.right * BulletForce);
			audio.PlayOneShot(Shoot);
		}
		
		if(Input.GetKeyDown(KeyCode.E)&BombCount>0){
			Transform BulletInstance = (Transform)Instantiate(bullet, GameObject.Find("BulletPlace").transform.position, Quaternion.identity); //объект, позиция, поворот
			BulletInstance.rigidbody.AddForce(Vector3.right * BulletForce);
			BombCount = BombCount-1;
		}
	}
}
