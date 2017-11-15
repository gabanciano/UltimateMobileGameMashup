using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemyBehavior : MonoBehaviour {

	public GameObject Explosion;
	[Header("Enemy Movement Speed")]
	public float movementSpeed;

	void Update(){
		MoveEnemy ();
	}

	void MoveEnemy(){
		transform.Translate (-movementSpeed * Time.deltaTime, 0, 0);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Space_Bullet") {
			Instantiate (Explosion, col.transform.position, Quaternion.identity);
		}
	}


}
