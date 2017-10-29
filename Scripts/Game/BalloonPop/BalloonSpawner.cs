using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour {

	public GameObject Balloon;

	float spawnDelay = 2f;
	float spawnFrequency = .5f;
	float minSpawnPosX = -7.60f;
	float maxSpawnPosX = 7.60f;

	void Start () {
		InvokeRepeating ("SpawnBalloons", spawnDelay, spawnFrequency);
	}

	void SpawnBalloons(){
		Instantiate (Balloon, new Vector2 (Random.Range (minSpawnPosX, maxSpawnPosX), transform.position.y), Quaternion.identity);
	}
}
