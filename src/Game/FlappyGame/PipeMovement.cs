using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour {

	public float pipeSpeed;
	Vector2 PipeDirection;

	void Awake(){
		PipeDirection = new Vector2 (-pipeSpeed * Time.deltaTime, 0);
	}
	void FixedUpdate(){
		MovePipes ();
	}

	void MovePipes(){
		transform.Translate (PipeDirection);
	}
}
