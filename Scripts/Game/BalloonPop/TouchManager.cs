using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchManager : MonoBehaviour {

	public GameObject BalloonPopAnim;

	void Awake(){
		GameData.GAME_REQUIRED = 20;
	}

	void Update(){
		GetPlayerTouches ();
	}

	void GetPlayerTouches(){
		//TOUCH
		for (int i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
				if(hitInfo)
				{
					Debug.Log( hitInfo.transform.gameObject.name );
					PopBalloon (hitInfo.transform.gameObject);
				}
			}
		}

		//MOUSE
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Clicked");
			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
			if(hitInfo)
			{
				Debug.Log( hitInfo.transform.gameObject.name );
				PopBalloon (hitInfo.transform.gameObject);
			}
		}
	}

	void PopBalloon(GameObject balloon){
		GameData.GAME_SCORE += 1;
		GameData.GAME_REQUIRED_NUMBER_TO_PROCEED += 1;

		Destroy (balloon.gameObject);
		Instantiate (BalloonPopAnim, balloon.transform.position, Quaternion.identity);

		CheckLevelProgress ();
	}

	void CheckLevelProgress(){
		if (GameData.GAME_REQUIRED_NUMBER_TO_PROCEED >= GameData.GAME_REQUIRED) {
			GameData.GAME_REQUIRED_NUMBER_TO_PROCEED = 0;
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
			SceneManager.LoadScene ("game_dodging_game");
			break;
		default:
			SceneManager.LoadScene ("main_menu");
			Debug.Log ("Error: Can't load level");
			break;
		}
	}
}
