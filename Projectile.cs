using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	float speed = 10;
	GameObject inGameEnemy;
	Enemy enemy;
	bool win = false;

	public void Start(){
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length > 0) {
			inGameEnemy = GameObject.FindGameObjectWithTag ("Enemy");
			enemy = inGameEnemy.GetComponent<Enemy> ();
		}
	}

	public void SetSpeed(float newSpeed){
		speed = newSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		float moveDistance = speed * Time.deltaTime;
		transform.Translate (Vector3.forward * moveDistance);
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length <= 0) {
			print ("you win");
		}
	}

	void OnTriggerEnter(Collider col){
		if (GameObject.FindGameObjectWithTag("Enemy")) {
			Destroy (col.gameObject); //Destroy Enemy
			Destroy (gameObject); //Destroy Bullet
		}
	}
}
