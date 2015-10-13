using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PlayerController))]
public class Player : MonoBehaviour {
	
	PlayerController controller;
	GunController gunController;
	public float playerSpeed = 5;

	Camera viewCamera;
	Vector3 point;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController> ();
		gunController = GetComponent<GunController> ();
		viewCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		Vector3 playerVelocity = playerPos.normalized * playerSpeed;
		controller.Move (playerVelocity);

		Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayDistance;

		if (groundPlane.Raycast (ray, out rayDistance)) {
			point = ray.GetPoint(rayDistance);
			Debug.DrawLine(ray.origin, point, Color.red);
			controller.LookAt(point);
		}

		if (Input.GetMouseButton (0)) {
			gunController.Shoot();
		}
	}
}
