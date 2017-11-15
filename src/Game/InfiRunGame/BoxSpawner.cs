using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {

	public GameObject BoxObstacle;
	[Header("Random Height Min/Max")]
	public float boxHeightMin;
	public float boxHeightMax;
	[Space]

	[Header("Spawn Delay")]
	public float spawnStartDelay;
	public float spawnMinDelay;
	public float spawnMaxDelay;
	[Space]

	float spawnDelay;
	float pipeSpawnHeight;
	Vector2 pipeSpawnPosition;

	void Awake(){
		spawnDelay = spawnStartDelay;
	}

	void Update () {
		SpawnPipes ();
	}

	void SpawnPipes(){
		spawnDelay -= Time.deltaTime;
		if (spawnDelay <= 0) {
			pipeSpawnHeight = Random.Range (boxHeightMin, boxHeightMax);
			pipeSpawnPosition = new Vector2 (transform.position.x, pipeSpawnHeight);
			Instantiate (BoxObstacle, pipeSpawnPosition, Quaternion.identity);
			spawnDelay = Random.Range(spawnMinDelay, spawnMaxDelay);
		}
	}
}
