using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDelay : MonoBehaviour {

	readonly float gameOverScreenDelay = 4f;

	void Start(){
		StartCoroutine (ChangeScene ());	
	}

	IEnumerator ChangeScene(){
		yield return new WaitForSeconds (gameOverScreenDelay);
		SceneManager.LoadScene ("main_menu");
	}
	 

}
