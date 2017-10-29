using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgerEnemyBehavior : MonoBehaviour {

	public float movementSpeed;

	Vector3 EnemyPos;

	void Update(){
		MoveEnemy ();
	}

	void MoveEnemy(){
		transform.Translate (0, -movementSpeed * Time.deltaTime, 0);
	}
}
