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
	public float timeBetweenWaves;

	private float timeToSpawn = 2f;
	public static int waveCounter = 0;
	private int numberOfFreeShapes = 3;
	private int numberOfFreeReverseShapes = 3;
	bool isPowerUpWave;
	bool isScoreWave;
	bool isResetBoostWave;
	void Start() {
	}

	void Update () {

		if (Time.time >= timeToSpawn)
		{
			isPowerUpWave = waveCounter % 4 == 0;
			isScoreWave = waveCounter % 5 == 0;
			isResetBoostWave = waveCounter % 2 == 0;
			if (waveCounter % 10 == 0 && numberOfFreeShapes > 1)
			{
				numberOfFreeShapes -= 1;
				numberOfFreeReverseShapes -= 1;
			}
			SpawnBlocks(numberOfFreeShapes,numberOfFreeReverseShapes);	
			timeToSpawn = Time.time + timeBetweenWaves;
			waveCounter++;
			UI.updateScore();
			if( waveCounter % 10 == 0 && timeBetweenWaves > 0.5f)
            {
				timeBetweenWaves -= 0.2f;
            }
		}
	}
	

	public void SpawnBlocks (int indexSize, int reverseIndexSize)
	{
		int aux;
		int ok = -1;
		int randomIndexSize = Random.Range(1, spawnPoints.Length);
		int[] randomIndex = new int[indexSize];
		int[] reverseRandomIndex = new int[reverseIndexSize];
		int randomShapeIndex = Random.Range(0, shapes.Length);
		GameObject shapeToSpawn = shapes[randomShapeIndex]; 
		for (int i = 0; i < indexSize; i++) 
		{
			aux = Random.Range(1, spawnPoints.Length);
			while(randomIndex.Contains(aux))
				aux = Random.Range(1, spawnPoints.Length);
			randomIndex[i] = aux;
		}

		for (int i = 0; i < reverseIndexSize; i++)
		{
			aux = Random.Range(1, reverseSpawnPoints.Length);
			while (reverseRandomIndex.Contains(aux))
				aux = Random.Range(1, reverseSpawnPoints.Length);
			reverseRandomIndex[i] = aux;
		}

		int randomVal = 0;
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
					randomVal = Random.Range(0, shapes.Length);
					Instantiate(circlePrefab, spawnPoints[randomVal].position, Quaternion.identity);
					isScoreWave = false;
				}
				if (isPowerUpWave)
				{
					randomVal = Random.Range(0, shapes.Length);
					Instantiate(cherry, spawnPoints[randomVal].position, Quaternion.identity);
					isPowerUpWave = false;
				}
				if (isResetBoostWave)
                {
					randomVal = Random.Range(0, shapes.Length);
					Instantiate(resetBoost, spawnPoints[randomVal].position, Quaternion.identity);
					isResetBoostWave = false;
				}
			}
			else
			{
				if (isResetBoostWave)
				{
					randomVal = Random.Range(0, reverseShapes.Length);
					Instantiate(resetBoost, reverseSpawnPoints[randomVal].position, Quaternion.identity);
					isResetBoostWave = false;
				}
				if (reverseRandomIndex.Contains(i) == false)
				{
					float w2 = Random.Range(-50, 50) / 10;
					Vector3 x2 = reverseSpawnPoints[i].position + Vector3.up * w2;
					randomVal = Random.Range(0, reverseShapes.Length);
					Instantiate(reverseShapes[randomVal], x2, Quaternion.identity);
				}
				
			}
		}
		
	}
}
