using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	private Text scoreText;
	private Text highScoreText;
	private GameObject newHighScoreText;

	public AudioClip newHighScoreSound;

	int score = 0;
	int highScore = 0;

	private bool blink = false;
	private int blinkCounter = 0;
	private int blinkSpeed = 80;

	void Start () {
		score = PlayerPrefs.GetInt ("Score");
		highScore = PlayerPrefs.GetInt ("HighScore");

		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		highScoreText = GameObject.Find ("HighScoreText").GetComponent<Text> ();
		newHighScoreText = GameObject.Find ("NewHighScoreText");

		scoreText.text = "Score: " + score;
		highScoreText.text = "High Score: " + highScore;

		if (score == highScore) {
			newHighScoreText.SetActive (true);
			SoundManagerScript.instance.RandomisePlayerSfx(1.0f, newHighScoreSound);
		} else {
			newHighScoreText.SetActive (false);
		}
	}
	
	void Update() {
		if (blinkCounter < blinkSpeed / 2) {
			blink = true;
		} else {
			blink = false;
			if (blinkCounter == blinkSpeed) {
				blinkCounter = 0;
			}
		}
		blinkCounter++;
	}

	void OnGUI() {
		if (blink && (score == highScore && score != 0)) {
			newHighScoreText.SetActive (true);
		} else if (!blink && (score == highScore && score != 0)) {
			newHighScoreText.SetActive (false);
		}
	}
}
