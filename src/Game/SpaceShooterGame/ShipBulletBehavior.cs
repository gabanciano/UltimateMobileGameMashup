using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipBulletBehavior : MonoBehaviour {

	readonly int maxKillsRequired = 20;
	[Header("Bullet Speed")]
	public float bulletSpeed;
	
	// Update is called once per frame
	void FixedUpdate () {
		MoveBullet ();
	}

	void MoveBullet(){
		transform.Translate (bulletSpeed, 0, 0);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Space_Enemy") {
			Destroy (gameObject);
			col.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 3f;
			GameData.GAME_SCORE++;
			col.transform.gameObject.tag = "Space_DeadEnemy";
			GameData.GAME_REQUIRED_NUMBER_TO_PROCEED += 1;

			CheckLevelProgress ();
		}
	}

	void CheckLevelProgress (){
		if (GameData.GAME_REQUIRED_NUMBER_TO_PROCEED >= maxKillsRequired) {
			GameData.GAME_REQUIRED_NUMBER_TO_PROCEED = 0;
			GameData.GAME_REQUIRED = 0;

			CheckIfHighScore ();
			LoadRandomGame ();
		}
	}

	public void CheckIfHighScore(){
		int highScore = PlayerPrefs.GetInt ("game_high_score", 0);
		if (GameData.GAME_SCORE > highScore) {
			PlayerPrefs.SetInt ("game_high_score", GameData.GAME_SCORE);
		}
	}

	void LoadRandomGame(){
		int game = Random.Range (1, 6);
		switch (game) {
		case 1: 
			SceneManager.LoadScene ("game_flappy");
			break;
		case 2: 
			SceneManager.LoadScene ("game_infi_runner");
			break;
		case 3: 
			SceneManager.LoadScene ("game_dodging_game");
			break;
		case 4: 
			SceneManager.LoadScene ("game_egg_catching");
			break;
		case 5:
			SceneManager.LoadScene ("game_balloon_popping");
			break;
		default:
			SceneManager.LoadScene ("main_menu");
			Debug.Log ("Error: Can't load level");
			break;
		}
	}
}
