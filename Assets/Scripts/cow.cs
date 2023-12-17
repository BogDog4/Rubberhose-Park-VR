using UnityEngine;

public class cow : MonoBehaviour
{
    public GameObject baseballPrefab;
    public float SpawnInterval = 1f;  // time between throws
    public float throwRange = 10f;   // maximum distance to throw baseballs
    public Transform player;         // reference to the player object

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

        // Get the rotation of the cow
        Quaternion cowRotation = transform.rotation;

        // Set the rotation of the new baseball to match the cow's rotation
        newBaseball.transform.rotation = cowRotation;

        // You may need to adjust the above code depending on how your cow model is set up.
        // If your cow model is facing a different direction initially, you might need to modify the rotation.

        // Access the Rigidbody (if your baseball has one) and apply force in the forward direction
        Rigidbody rb = newBaseball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // You can adjust the force value based on your requirements
            float force = 10f;
            rb.AddForce(newBaseball.transform.forward * force, ForceMode.Impulse);
        }
    }
}