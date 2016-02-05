using UnityEngine;
using System.Collections;

public class BounceBlockScript : MonoBehaviour {

	public AudioClip bounceBlockSound;

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			SoundManagerScript.instance.RandomisePowerUpSfx(0.8f, bounceBlockSound);
		}
	}
}
