using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour {

	[Header("Egg Drop Speed")]
	public float dropSpeed;

	void Update () {
		MoveEgg ();
	}

	void MoveEgg(){
		transform.Translate (0, -dropSpeed * Time.deltaTime, 0);
	}
}
