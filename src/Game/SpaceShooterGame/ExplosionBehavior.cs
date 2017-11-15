using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour {

	public float explosionSpeed;

	void Start () {
		StartCoroutine (DestroyInstance ());
	}

	void Update(){
		MoveExplosion ();
	}

	void MoveExplosion(){
		transform.Translate (explosionSpeed * Time.deltaTime, 0, 0);
	}

	IEnumerator DestroyInstance(){
		yield return new WaitForSeconds (1.1f);
		Destroy (gameObject);
	}
}
