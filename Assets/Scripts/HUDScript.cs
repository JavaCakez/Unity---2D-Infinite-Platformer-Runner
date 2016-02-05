using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	float playerScore = 0f;

	public Font font;
	private GUIStyle style = new GUIStyle();
	
	void Update () {
		playerScore += Time.deltaTime;
	}

	public void IncreaseScore(int amount) {
		playerScore += amount;
	}

	void OnDisable() {
		//better not to use player prefs (which is just text file so can be edited), instead keep a packet with score and persist it with dont destroy on load
		PlayerPrefs.SetInt ("Score", (int)(playerScore * 100));
		if ((int)(playerScore * 100) > PlayerPrefs.GetInt ("HighScore"))
			PlayerPrefs.SetInt ("HighScore", (int)(playerScore * 100));

	}

	void OnGUI() {
		style.fontSize = 36;
		style.normal.textColor = Color.white;
		GUI.Label (new Rect (30, 30, 200, 60), "Score: " + (int)(playerScore * 100), style);
		GUI.skin.font = font;
	}

}
