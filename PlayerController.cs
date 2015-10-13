using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {
	
	Vector3 velocity;
	Rigidbody myRigidBody;
	
	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody> ();
	}
	
	public void Move(Vector3 _velocity){
		velocity = _velocity;
	}

	public void LookAt(Vector3 _point){
		Vector3 heightCorrectedPoint = new Vector3 (_point.x, transform.position.y, _point.z);
		transform.LookAt (heightCorrectedPoint);
	}

	// Update is called once per frame
	void FixedUpdate () {
		myRigidBody.MovePosition (myRigidBody.position + velocity * Time.fixedDeltaTime);
	}
}
