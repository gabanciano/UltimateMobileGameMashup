using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPoppedBehavior : MonoBehaviour {

	readonly float destroyDelay = 0.15f;
	// Use this for initialization
	void Start () {
		StartCoroutine (DestroyObject ());
	}

	IEnumerator DestroyObject(){
		yield return new WaitForSeconds (destroyDelay);
		Destroy (gameObject);
	}
}
