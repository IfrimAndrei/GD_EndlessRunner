using UnityEngine;
using System.Linq;

public class BlockSpawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public Transform[] reverseSpawnPoints;
	public Transform[] cherrySpawnPoints;

	public GameObject cherry;
	public GameObject circlePrefab;

	public GameObject[] shapes;
	public GameObject[] reverseShapes;
	public float timeBetweenWaves = 1f;

	private float timeToSpawn = 2f;
	public static int waveCounter = 0;
	bool isPowerUpWave;
	bool isScoreWave;
	void Start() {
	}

	void Update () {

		if (Time.time >= timeToSpawn)
		{
			isPowerUpWave = waveCounter % 4==0;
			isScoreWave = waveCounter % 5==0;
			SpawnBlocks();	
			timeToSpawn = Time.time + timeBetweenWaves;
			waveCounter++;
			UI.updateScore();

		}
	}
	

	public void SpawnBlocks ()
	{
		int aux;
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

			if (randomIndex.Contains(i) == false)
			{
				float w = Random.Range(-50, 50) / 10;
				Vector3 x = spawnPoints[i].position + Vector3.up * w;
				Instantiate(shapeToSpawn, x, Quaternion.identity);
			}
			else
			{
				if(isScoreWave) {
					Instantiate(circlePrefab, spawnPoints[i].position, Quaternion.identity);
					isScoreWave = false;
				}
				if (isPowerUpWave)
				{
					Instantiate(cherry, spawnPoints[i].position, Quaternion.identity);
					isPowerUpWave = false;
				}
				else if (waveCounter > 2)
					if (Random.Range(1, 4 - waveCounter / 2) == 1 || waveCounter >= 8)
					{
						Instantiate(reverseShapes[randomShapeIndex], reverseSpawnPoints[i].position, Quaternion.identity);
					}
			}
		}
		
	}
}
