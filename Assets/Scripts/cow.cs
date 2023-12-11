using UnityEngine;

public class BaseballSpawner : MonoBehaviour
{
    public GameObject baseballPrefab;
    public float minSpawnInterval = 1f;  // Minimum time between throws
    public float maxSpawnInterval = 3f;  // Maximum time between throw

    private float nextSpawnTime;

    void Start()
    {
        // Set the initial spawn time
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        // Check if it's time to spawn a new baseball
        if (Time.time >= nextSpawnTime)
        {
            SpawnBaseball();

            // Set the next spawn time within the specified interval
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    void SpawnBaseball()
    {
        // Instantiate the baseball prefab at the spawner's position
        Instantiate(baseballPrefab, transform.position, Quaternion.identity);
    }
}