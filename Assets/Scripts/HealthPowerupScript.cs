using UnityEngine;
using System.Collections;

public class HealthPowerupScript : MonoBehaviour {

	public GameObject bounceBlockPrefab;
	public AudioClip healthPowerUpSound;
	GameObject bounceBlock;
	

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			if (!GameObject.Find("BounceBlock(Clone)")) {
				SoundManagerScript.instance.RandomisePowerUpSfx(0.8f, healthPowerUpSound);

				//Should optimise to get camera once
				bounceBlock = Instantiate (bounceBlockPrefab, new Vector3(other.transform.position.x - 1.5f, -7.0f, 0f), Quaternion.identity) as GameObject;
				bounceBlock.transform.SetParent(GameObject.Find("Main Camera").transform);

				//Destroy any other existing health power ups
				GameObject[] healthPowerUps = GameObject.FindGameObjectsWithTag("HealthPowerUp");
				foreach(GameObject go in healthPowerUps) {
					Destroy (go);
				}
			}

			Destroy (this.gameObject);
		}
	}
}
