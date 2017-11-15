using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfiniteRunner : MonoBehaviour {

	[Header("Player Jump Force")]
	public float iRJumpForce;

	bool playerGrounded;
	Vector2 iRPosition;

	Rigidbody2D iRRigid2D;

	void InitializeGame(){
		GameData.GAME_REQUIRED = 16;
		playerGrounded = false;
		iRRigid2D = GetComponent<Rigidbody2D> ();
		iRPosition = new Vector2 (0 , iRJumpForce);
	}

	void Awake () {
		InitializeGame ();
	}

	void Update () {
		CheckLevelProgress ();
        DetectKeyboardInput();
	}

    void DetectKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpPlayer();
        }
    }

    public void JumpPlayer(){
		if (playerGrounded) {
			iRRigid2D.velocity = iRPosition;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Obstacle") {
			SceneManager.LoadScene ("game_over");
		}	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "InfiRunner_BoxScore") {
			GameData.GAME_SCORE += 1;
			GameData.GAME_REQUIRED_NUMBER_TO_PROCEED += 1;
		}

		if (col.gameObject.tag == "InfiRunner_Ground") {
			playerGrounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "InfiRunner_Ground") {
			playerGrounded = false;
		}
	}

	void CheckLevelProgress(){
		if (GameData.GAME_REQUIRED_NUMBER_TO_PROCEED >= GameData.GAME_REQUIRED) {
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
			SceneManager.LoadScene ("game_space_shooter");
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
