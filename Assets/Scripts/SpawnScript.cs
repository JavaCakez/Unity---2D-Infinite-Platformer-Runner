using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin = 1f;
	public float spawnMax = 2f;

	private bool initialHealthPowerUp = true;
	
	// Use this for initialization
	void Start () {
		Spawn ();
	}

	void Spawn() {
		int random = Random.Range (0, obj.Length);

		if (obj [random].tag != "HealthPowerUp") {
			Instantiate (obj [random], transform.position, Quaternion.identity);
		} else {
			//Dont spawn any more health power ups if the player already has a bounceblock active
			if (initialHealthPowerUp) {
				initialHealthPowerUp = false;
			} else if (GameObject.FindGameObjectsWithTag ("BounceBlock").Length == 0) {
				// Shouldnt spawn health power up instantly
				Instantiate (obj [random], transform.position, Quaternion.identity);
			}
		}
		Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
	}
}
