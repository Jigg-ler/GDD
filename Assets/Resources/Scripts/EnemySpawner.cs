using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] prefabs1;
	public GameObject[] prefabs2;
	public GameObject[] prefabs3;

	private float currentTime = 0f;
	//public static float speed = 10f;

	// Use this for initialization
	void Start () {

		// aysnchronous infinite skyscraper spawning
		StartCoroutine(SpawnEnemies());
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator SpawnEnemies() {
		while (true) {

			if ( (currentTime % 12) >= Random.Range(0f, 10f)){
				Instantiate(prefabs2[Random.Range(0, prefabs2.Length)], new Vector3(Random.Range(0f, 4.5f), 0, -8),
				Quaternion.identity);
			}
			else{
			// create a new skyscraper from prefab selection at right edge of screen
				Instantiate(prefabs1[Random.Range(0, prefabs1.Length)], new Vector3(Random.Range(0f, 4.5f), 0, -8),
				Quaternion.identity);
			}
			// // randomly increase the speed by 1
			// if (Random.Range(1, 4) == 1) {
			// 	speed += 1f;
			// }

			currentTime += Time.deltaTime * 10;
			//Debug.Log(currentTime);

			// wait between 1-5 seconds for a new skyscraper to spawn
			yield return new WaitForSeconds(Random.Range(1, Mathf.Max(3, Mathf.CeilToInt(5 - currentTime/2) ) ));
		}
	}
}
