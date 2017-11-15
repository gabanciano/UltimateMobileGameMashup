using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SharedGameUIManager : MonoBehaviour {

	[Header("UI Texts")]
	public Text ScoreText;
	public Text RequiredScoreText;

	void Update(){
		UpdateTextData ();
	}

	void UpdateTextData(){
		ScoreText.text = GameData.GAME_SCORE.ToString();
		RequiredScoreText.text = GameData.GAME_REQUIRED_NUMBER_TO_PROCEED + "/" + GameData.GAME_REQUIRED;
	}

}
