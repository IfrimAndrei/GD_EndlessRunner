using UnityEngine;
using System.Linq;

public class BlockSpawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public Transform[] reverseSpawnPoints;
	public Transform[] cherrySpawnPoints;

	public GameObject blockPrefab;
	public GameObject inverseBlockPrefab;
	public GameObject cherry;
	//public GameObject powerUpBlock;
	
	public float timeBetweenWaves = 1f;

	private float timeToSpawn = 2f;
	public static int waveCounter = 0;
	bool isPowerUpWave;
	void Update () {

		if (Time.time >= timeToSpawn)
		{
			isPowerUpWave = waveCounter % 4==0;
			SpawnBlocks();	
			timeToSpawn = Time.time + timeBetweenWaves;
			waveCounter++;
		}
	}
	

	public void SpawnBlocks ()
	{
		int aux;
		int randomIndexSize = Random.Range(1, spawnPoints.Length);
		int[] randomIndex = new int[randomIndexSize];

		for (int i = 0; i < randomIndexSize; i++) 
		{
			aux = Random.Range(1, spawnPoints.Length);
			while(randomIndex.Contains(aux))
				aux = Random.Range(1, spawnPoints.Length);
			randomIndex[i] = aux;
		}

		for (int i = 0; i < spawnPoints.Length; i++)
		{

			if (randomIndex.Contains(i) == false)
			{
				float w = Random.Range(-50, 50) / 10;
				Vector3 x = spawnPoints[i].position + Vector3.up * w;
				Instantiate(blockPrefab, x, Quaternion.identity);
			}
			else
			{
				
				if (isPowerUpWave)
				{
					
					Instantiate(cherry, spawnPoints[i].position, Quaternion.identity);
					isPowerUpWave = false;
				}
				else if (waveCounter > 2)
					if (Random.Range(1, 4 - waveCounter / 2) == 1 || waveCounter >= 8)
					{
						Instantiate(inverseBlockPrefab, reverseSpawnPoints[i].position, Quaternion.identity);
					}
			}
		}
		
	}
}
