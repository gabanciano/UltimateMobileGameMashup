using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgerEnemySpawner : MonoBehaviour {

	readonly float minSpawnPosX = -5.30f;
	readonly float maxSpawnPosX = 5.30f;

	[Header("Dodger Enemies")]
	public GameObject[] DodgerEnemies;
	[Space]

	[Header("Spawn Settings")]
	public float spawnDelay;
	public float spawnFrequency;

	int randomEnemy;
	Vector3 EnemyPosX;

	void Awake () {
		InvokeRepeating ("SpawnEnemy", spawnDelay, spawnFrequency);
	}

	void SpawnEnemy () {
		randomEnemy = Random.Range (0, 3);
		EnemyPosX = new Vector3(Random.Range(minSpawnPosX, maxSpawnPosX), transform.position.y, transform.position.z);
		Instantiate (DodgerEnemies [randomEnemy], EnemyPosX, Quaternion.identity);
	}
}
