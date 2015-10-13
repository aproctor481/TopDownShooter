using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	NavMeshAgent pathfinder;
	Transform target;
	public int health;

	public int getHealth(){
		return health;
	}

	void Start () {
		pathfinder = GetComponent<NavMeshAgent> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		StartCoroutine (UpdatePath ());
	}

	IEnumerator UpdatePath(){
		float refreshRate = 1f;

		while (target != null) {
			Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
			pathfinder.SetDestination(targetPosition);
			yield return new WaitForSeconds(refreshRate);
		}
	}
}
