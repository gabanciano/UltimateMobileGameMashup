using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour {

	public float boxSpeed;
	Vector2 BoxDirection;

	void Awake(){
		BoxDirection = new Vector2 (-boxSpeed * Time.deltaTime, 0);
	}
	void Update(){
		transform.Translate (BoxDirection);
	}
}
