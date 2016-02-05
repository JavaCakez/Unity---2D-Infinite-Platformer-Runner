using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighlightButtonScript : MonoBehaviour {

	public void highlightStartButton () {
		Text retryText = GameObject.Find ("StartText").GetComponent<Text> ();
		Text exitText = GameObject.Find ("ExitText").GetComponent<Text> ();

		retryText.color = new Color (1f, 1f, 1f);
		exitText.color = new Color (0.5f, 0.5f, 0.5f);
	}

	public void highlightExitButton () {
		Text retryText = GameObject.Find ("StartText").GetComponent<Text> ();
		Text exitText = GameObject.Find ("ExitText").GetComponent<Text> ();
		
		exitText.color = new Color (1f, 1f, 1f);
		retryText.color = new Color (0.5f, 0.5f, 0.5f);
	}

}
