using UnityEngine;

public class cow : MonoBehaviour
{
    public GameObject baseballPrefab;
    public float SpawnInterval = 1f;  // time between throws

    private float nextSpawnTime;

    void Start()
    {
        // Set the initial spawn time
        nextSpawnTime = Time.time + SpawnInterval;
    }

    void Update()
    {
        // Check if it's time to spawn a new baseball
        if (Time.time >= nextSpawnTime)
        {
            SpawnBaseball();

            // Set the next spawn time within the specified interval
            nextSpawnTime = Time.time + SpawnInterval;
        }
    }

    void SpawnBaseball()
    {
        // Instantiate the baseball prefab at the spawner's position
        Instantiate(baseballPrefab, transform.position, Quaternion.identity);
    }
}