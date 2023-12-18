using UnityEngine;

public class cow : MonoBehaviour
{
    public GameObject baseballPrefab;
    public float SpawnInterval = 1f;  
    public float throwRange = 10f;  
    public Transform player;         

    private float nextSpawnTime;

    void Start()
    {
        // Set the initial spawn time
        nextSpawnTime = Time.time + SpawnInterval;
    }

    void Update()
    {
        // Check if the player is within throw range
        if (Vector3.Distance(transform.position, player.position) <= throwRange)
        {
            // Check if it's time to spawn a new baseball
            if (Time.time >= nextSpawnTime)
            {
                SpawnBaseball();

                // Set the next spawn time within the specified interval
                nextSpawnTime = Time.time + SpawnInterval;
            }
        }
    }

    void SpawnBaseball()
    {
        // Instantiate the baseball prefab at the spawner's position
        GameObject newBaseball = Instantiate(baseballPrefab, transform.position, Quaternion.identity);

        // Get the rotation of the cow(gun)
        Quaternion cowRotation = transform.rotation;

        // Set the rotation of baseball to match rotation
        newBaseball.transform.rotation = cowRotation;

        // Access the Rigidbody and apply force in the forward direction
        Rigidbody rb = newBaseball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float force = 10f;
            rb.AddForce(newBaseball.transform.forward * force, ForceMode.Impulse);
        }
    }
}