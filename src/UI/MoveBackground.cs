using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

	[Header("Background Scrolling Speed")]
	public float movementSpeed;
	Vector2 offset;


	void Update () {
		MoveGameBackground ();
	}

	void MoveGameBackground(){
		offset = new Vector2 (Time.time * movementSpeed, 0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
