using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {

	[Header("Random Height Min/Max")]
	public float pipeHeightMin;
	public float pipeHeightMax;
	public GameObject Pipes;
	[Space]

	[Header("Time")]
	public float spawnDelay;
	public float spawnFrequency;
	[Space]

	float originalSpawnDelay;
	float pipeSpawnHeight;
	Vector2 pipeSpawnPosition;

	void Awake(){
		InvokeRepeating ("SpawnPipes", 0, spawnFrequency);
	}

	void SpawnPipes(){
			pipeSpawnHeight = Random.Range (pipeHeightMin, pipeHeightMax);
			pipeSpawnPosition = new Vector2 (transform.position.x, pipeSpawnHeight);
			Instantiate (Pipes, pipeSpawnPosition, Quaternion.identity);
	}
}
