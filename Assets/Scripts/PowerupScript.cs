using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {

	HUDScript hud;

	public AudioClip coinSound;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			SoundManagerScript.instance.RandomisePowerUpSfx(0.6f, coinSound);
			// inefficient, pull it once, put on spawn object, pass it onto children
			hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
			hud.IncreaseScore (10);
			Destroy (this.gameObject);
		}
	}

}
