using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // The enemy prefab to spawn
    public int numberOfEnemies = 10; // Number of enemies to spawn
    public float spawnRangeX = 10f;  // Range on the X-axis for spawning
    public float spawnRangeZ = 10f;  // Range on the Z-axis for spawning
    public float spawnHeight = 0.5f; // Height at which enemies will be spawned

    void Start()
    {
        // Spawn the specified number of enemies at random positions
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Generate random positions within the defined spawn range
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            float randomZ = Random.Range(-spawnRangeZ, spawnRangeZ);

            // Set the spawn position
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ);

            // Instantiate the enemy prefab at the spawn position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
