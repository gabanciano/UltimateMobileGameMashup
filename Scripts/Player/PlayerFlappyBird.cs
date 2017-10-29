using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFlappyBird : MonoBehaviour {

	public float flappyJumpForce;
	Vector2 FlappyPosition;

	Rigidbody2D FlappyRigid2D;

	void InitializeData(){
		GameData.GAME_REQUIRED = 8;
		FlappyRigid2D = GetComponent<Rigidbody2D> ();
		FlappyRigid2D.gravityScale = 0;
		FlappyPosition = new Vector2 (0 , flappyJumpForce);
	}
	void Awake () {
		InitializeData ();
	}

    void Update()
    {
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
		FlappyRigid2D.gravityScale = 3.5f;
		FlappyRigid2D.velocity = FlappyPosition;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Obstacle") {
			SceneManager.LoadScene ("game_over");
		}	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "PipeScore") {
			GameData.GAME_SCORE += 1;
			GameData.GAME_REQUIRED_NUMBER_TO_PROCEED += 1;

			CheckLevelProgress ();
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
			SceneManager.LoadScene ("game_infi_runner");
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
