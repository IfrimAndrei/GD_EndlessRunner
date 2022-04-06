using UnityEngine;
using System.Linq;

public class BlockSpawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public Transform[] reverseSpawnPoints;
	public Transform[] cherrySpawnPoints;

	public GameObject cherry;
	public GameObject circlePrefab;
	public GameObject resetBoost;

	public GameObject[] shapes;
	public GameObject[] reverseShapes;
	public float timeBetweenWaves = 1.5f;

	private float timeToSpawn = 2f;
	public static int waveCounter = 0;
	bool isPowerUpWave;
	bool isScoreWave;
	bool isResetBoostWave;
	void Start() {
	}

	void Update () {

		if (Time.time >= timeToSpawn)
		{
			isPowerUpWave = waveCounter % 4==0;
			isScoreWave = waveCounter % 5==0;
			isResetBoostWave = waveCounter % 2 == 0;
			SpawnBlocks();	
			timeToSpawn = Time.time + timeBetweenWaves;
			waveCounter++;
			UI.updateScore();
			if( waveCounter % 10 == 0 && timeBetweenWaves > 0.5f)
            {
				timeBetweenWaves -= 0.1f;
            }				
		}
	}
	

	public void SpawnBlocks ()
	{
		int aux;
		int ok = -1;
		int randomIndexSize = Random.Range(1, spawnPoints.Length);
		int[] randomIndex = new int[randomIndexSize];
		int randomShapeIndex = Random.Range(0, shapes.Length);
		GameObject shapeToSpawn = shapes[randomShapeIndex]; 
		for (int i = 0; i < randomIndexSize; i++) 
		{
			aux = Random.Range(1, spawnPoints.Length);
			while(randomIndex.Contains(aux))
				aux = Random.Range(1, spawnPoints.Length);
			randomIndex[i] = aux;
		}

		for (int i = 0; i < spawnPoints.Length; i++)
		{
			ok = Random.Range(1, 3);
			if (ok == 1)
			{
				if (randomIndex.Contains(i) == false)
				{
					float w = Random.Range(-50, 50) / 10;
					Vector3 x = spawnPoints[i].position + Vector3.up * w;
					int shapeVal = Random.Range(0, shapes.Length);
					Instantiate(shapes[shapeVal], x, Quaternion.identity);
				}
				if (isScoreWave)
				{
					Instantiate(circlePrefab, spawnPoints[i].position, Quaternion.identity);
					isScoreWave = false;
				}
				if (isPowerUpWave)
				{
					Instantiate(cherry, spawnPoints[i].position, Quaternion.identity);
					isPowerUpWave = false;
				}
				if (isResetBoostWave)
                {
					Instantiate(resetBoost, spawnPoints[i].position, Quaternion.identity);
					isResetBoostWave = false;
				}
			}
			else
			{
				if (isScoreWave)
				{
					Instantiate(circlePrefab, reverseSpawnPoints[i].position, Quaternion.identity);
					isScoreWave = false;
				}
				if (isPowerUpWave)
				{
					Instantiate(cherry, reverseSpawnPoints[i].position, Quaternion.identity);
					isPowerUpWave = false;
				}
				if (isResetBoostWave)
				{
					Instantiate(resetBoost, reverseSpawnPoints[i].position, Quaternion.identity);
					isResetBoostWave = false;
				}
				float w2 = Random.Range(-50, 50) / 10;
				Vector3 x2 = reverseSpawnPoints[i].position + Vector3.up * w2;
				int randomVal = Random.Range(0, reverseShapes.Length);
				Instantiate(reverseShapes[randomVal], x2, Quaternion.identity);
			}
		}
		
	}
}
