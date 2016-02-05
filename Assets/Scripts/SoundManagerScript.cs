using UnityEngine;
using System.Collections;

public class SoundManagerScript : MonoBehaviour {

	public AudioSource musicSource;
	public AudioSource playerEfxSource;
	public AudioSource powerUpEfxSource;
	public static SoundManagerScript instance = null;	

	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;

	public static SoundManagerScript Instance {
		get { return instance; }
	}

	public void RandomiseSfx(AudioSource audioSource, params AudioClip[] clips) {
		int randomIndex = Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);

		audioSource.pitch = randomPitch;
		audioSource.clip = clips [randomIndex];
		audioSource.Play();
	}

	public void RandomisePlayerSfx(float volume, params AudioClip[] clips) {
		SetPlayerSfxVolume (volume);
		RandomiseSfx (playerEfxSource, clips);
	}

	public void SetPlayerSfxVolume(float volume) {
		playerEfxSource.volume = volume;
	}

	public void SetPowerUpSfxVolume(float volume) {
		powerUpEfxSource.volume = volume;
	}

	public void RandomisePowerUpSfx(float volume, params AudioClip[] clips) {
		SetPowerUpSfxVolume (volume);
		RandomiseSfx (powerUpEfxSource, clips);
	}
	
	void Awake () {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}

		DontDestroyOnLoad (gameObject);
	}
}
