using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	private Text startText;
	private Text exitText;
	private bool startActive = true;

	public Button startButton;
	public Button exitButton;

	void Start () {
		startButton.onClick.AddListener (() => {
			Application.LoadLevel (0);});
		
		exitButton.onClick.AddListener (() => {
			Application.Quit ();});

		startText = GameObject.Find ("StartText").GetComponent<Text> ();
		exitText = GameObject.Find ("ExitText").GetComponent<Text> ();

		setStartActive ();
	}
	
	private void setExitActive() {
		exitText.color = new Color (1f, 1f, 1f);
		startText.color = new Color (0.5f, 0.5f, 0.5f);
		startActive = false;
	}
	
	private void setStartActive() {
		startText.color = new Color (1f, 1f, 1f);
		exitText.color = new Color (0.5f, 0.5f, 0.5f);
		startActive = true;
	}
	
	void Update() {		
		if (Input.GetKey ("up")) {
			setStartActive();
		}
		if (Input.GetKey ("down")) {
			setExitActive();
		}
		if (Input.GetKey ("escape")) {
			Application.Quit();
		}
		if (Input.GetKey ("space") || Input.GetKey ("return")) {
			if (startActive) {
				Application.LoadLevel(1);
			} else {
				Application.Quit();
			}
		}
	}
}
