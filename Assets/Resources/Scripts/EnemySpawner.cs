using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] prefabs1;
	public GameObject[] prefabs2;
	public GameObject[] prefabs3;

	private GameObject prefab;
	private int totalSpawnCount = 0;
	//public static float speed = 10f;

	public bool bossInplay = false;

	// Use this for initialization
	void Start () {

		Score Score = GameObject.Find("scoreDisplay").GetComponent<Score>();
		// aysnchronous infinite skyscraper spawning
		StartCoroutine(SpawnEnemies());
	}

	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator SpawnEnemies() {
		while (true) {
			#region spawning
			if (!bossInplay){

				totalSpawnCount += 1;

				//TIER 2 SPAWN
				if ( (totalSpawnCount % 11) >= Random.Range(0f, 10f)){
					prefab = prefabs2[Random.Range(0, prefabs2.Length)];

					if (prefab.name == "hepa_b"){
						Instantiate(prefab, new Vector3(Random.Range(-5, -.5f), 0, -8),
						Quaternion.identity);
					}
					else if (prefab.name == "condiments"){
						Instantiate(prefab, new Vector3(Random.Range(0.5f, 5), 0, -8),
						Quaternion.identity);
					}
					else if (prefab.name == "bbq"){
						Instantiate(prefab, new Vector3(Random.Range(-2, 2), 0, -8),
						Quaternion.identity);
					}
				//BOSS SPAWN
				}
				else if (totalSpawnCount % 26 == 0 || Score.score >= 4000 + 50 * totalSpawnCount){
					prefab = prefabs3[Random.Range(0, prefabs3.Length)];
					if (prefab.name == "boss_hepa_c"){
						Instantiate(prefab, new Vector3(Random.Range(-5, -.5f), 0, -8),
						Quaternion.identity);
					}
					else if (prefab.name == "boss_donut"){
						Instantiate(prefab, new Vector3(Random.Range(0.5f, 5), 0, -8),
						Quaternion.identity);
					}
					else if (prefab.name == "boss_dirty_icec"){
						Instantiate(prefab, new Vector3(Random.Range(-2, 2), 0, -8),
						Quaternion.identity);
					}

				bossInplay = true;
				}
				//TIER 1 SPAWN
				else{
				// create a new skyscraper from prefab selection at right edge of screen
					prefab = prefabs1[Random.Range(0, prefabs1.Length)];
					if (prefab.name == "hepa_a"){
						Instantiate(prefab, new Vector3(Random.Range(-4.6f, 0), 0, -8),
						Quaternion.identity);
					}
					else if (prefab.name == "bagel"){
						Instantiate(prefab, new Vector3(Random.Range(0, 4.5f), 0, -8),
						Quaternion.identity);
					}
					else if (prefab.name == "cone"){
						Instantiate(prefab, new Vector3(Random.Range(-2.3f, 2.3f), 0, -8),
						Quaternion.identity);
					}
				}

			}
			#endregion
			// // randomly increase the speed by 1
			// if (Random.Range(1, 4) == 1) {
			// 	speed += 1f;
			// }

			//Debug.Log(totalSpawnCount);

			// wait between 1-5 seconds for a new skyscraper to spawn
			yield return new WaitForSeconds(Random.Range(1, Mathf.Max(3, Mathf.CeilToInt(5 - totalSpawnCount/2) ) ));
		}
	}
}
