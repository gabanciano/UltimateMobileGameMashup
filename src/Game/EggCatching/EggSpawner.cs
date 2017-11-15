using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour {

	[Header("Egg Object")]
	public GameObject Egg;
	[Space]

	float startingSpawnDelay;
	float consistentSpawnDelay;

	void Awake(){
		consistentSpawnDelay = Random.Range (1.5f, 3.9f);	
		startingSpawnDelay = Random.Range (1f, 2f);
	}

	void Start(){
		InvokeRepeating ("SpawnEgg", startingSpawnDelay, consistentSpawnDelay);	
	}

	void SpawnEgg(){
		Instantiate (Egg, transform.position, Quaternion.identity);
	}


}
