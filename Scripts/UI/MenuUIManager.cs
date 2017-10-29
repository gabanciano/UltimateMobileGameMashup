using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour {

	[Header("UI Text")]
	public Text HighScoreText;
	[Space]

	[Header("Background Settings")]
	public GameObject MenuBackground;
	public float movementSpeed;
	Vector2 offset;

	int highScore;

	void InitItems(){
		GameData.GAME_STARTED = false;
		GameData.GAME_SCORE = 0;
		GameData.GAME_REQUIRED_NUMBER_TO_PROCEED = 0;
	}

	void Awake(){
		InitItems ();
	}

	void Update(){
		UpdateHighScore ();

        DetectKeyboardInput();
	}

    void DetectKeyboardInput()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            PlayGame();
        }
    }

	void UpdateHighScore(){
		highScore = PlayerPrefs.GetInt ("game_high_score", 0);
		HighScoreText.text = "HIGH SCORE: " + highScore;
	}

	public void PlayGame(){
		LoadRandomGame ();
	}

	void LoadRandomGame(){
		int game = Random.Range (1, 5);
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
			SceneManager.LoadScene ("game_dodging_game");
			break;
		default:
			SceneManager.LoadScene ("main_menu");
			Debug.Log ("Error: Can't load level");
			break;
		}
	}
}
