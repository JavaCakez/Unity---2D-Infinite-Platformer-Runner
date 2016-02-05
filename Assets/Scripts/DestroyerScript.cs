using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

	public AudioClip deathSound;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			SoundManagerScript.instance.RandomisePlayerSfx(0.8f, deathSound);
			Application.LoadLevel (2);
			return;
		}

		if (other.gameObject.transform.parent) {
			Destroy (other.gameObject.transform.parent.gameObject);
		} else {
			Destroy (other.gameObject);
		}
	}
}
