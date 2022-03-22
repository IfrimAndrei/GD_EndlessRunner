using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	public Transform[] spawnPoints;

	public GameObject blockPrefab;
	public GameObject powerUpBlock;

	public float timeBetweenWaves = 1f;

	private float timeToSpawn = 2f;
	private int waveCounter = 0;
	void Update () {

		if (Time.time >= timeToSpawn)
		{
			bool isPowerUpWave = waveCounter % 10 == 0 ? true : false;
			SpawnBlocks(isPowerUpWave);
			timeToSpawn = Time.time + timeBetweenWaves;
			waveCounter++;
		}
	}
	

	void SpawnBlocks (bool isPowerUpWave)
	{
		int randomIndex = Random.Range(0, spawnPoints.Length);

		for (int i = 0; i < spawnPoints.Length; i++)
		{
			if (randomIndex != i)
			{
				Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
			}
		}
		if (isPowerUpWave) {
				Instantiate(powerUpBlock, spawnPoints[randomIndex].position, Quaternion.identity);
			}
	}
}
