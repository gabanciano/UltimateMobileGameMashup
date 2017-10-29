using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemySpawner : MonoBehaviour {

	[Header("Space Enemy")]
	public GameObject SpaceEnemy;

	Vector2 RandomizedSpawnPos;

	void Start () {
		InvokeRepeating ("SpawnEnemies", 2f, 0.8f);
	}

	void SpawnEnemies(){
		RandomizedSpawnPos = new Vector2 (transform.position.x, Random.Range (3.2f, -4.2f));
		Instantiate (SpaceEnemy, RandomizedSpawnPos, Quaternion.identity);
	}
}
