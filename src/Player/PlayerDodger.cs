using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDodger : MonoBehaviour {

	readonly float minPlayerClampPosX = -5.60f;
	readonly float maxPlayerClampPosX = 5.60f;

	Rigidbody2D DodgerRigid2D;
	Vector2 DodgerPosition;

	[Header("Player Speed")]
	public float movementSpeed;
	[Space]

	[Header("Position Limit")]
	public float minPlayerPosX;
	public float maxPlayerPosX;

	void InitializeData(){
		GameData.GAME_REQUIRED = 25;
		DodgerRigid2D = GetComponent<Rigidbody2D> ();
	}

	void Awake(){
		InitializeData ();
	}

	void Update(){
		ClampPlayer ();
        DetectKeyboardInput();
	}

    void DetectKeyboardInput()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            MovePlayerLeft();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            MovePlayerRight();
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)){
            StopPlayerMovement();
        }
    }

	void ClampPlayer(){
		DodgerPosition = DodgerRigid2D.position;
		DodgerPosition.x = Mathf.Clamp (DodgerPosition.x, minPlayerClampPosX, maxPlayerClampPosX);
		DodgerRigid2D.position = DodgerPosition;
	}

	public void MovePlayerLeft(){
		DodgerRigid2D.velocity = new Vector2 (-movementSpeed, 0);
	}

	public void MovePlayerRight(){
		DodgerRigid2D.velocity = new Vector2 (movementSpeed, 0);
	}

	public void StopPlayerMovement(){
		DodgerRigid2D.velocity = Vector2.zero;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Dodger_Enemy") {
			SceneManager.LoadScene ("game_over");
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Dodger_Enemy") {
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
			SceneManager.LoadScene ("game_flappy");
			break;
		case 2: 
			SceneManager.LoadScene ("game_infi_runner");
			break;
		case 3:
			SceneManager.LoadScene ("game_space_shooter");
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
