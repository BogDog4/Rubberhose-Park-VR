using UnityEngine;

public class Baseball : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed
    public float despawnTime = 5f; // Adjust the despawn time as needed
    private Rigidbody rb;
    private float spawnTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnTime = Time.time;
        // Move the baseball forward
        rb.velocity = transform.forward * speed;
    }

    void Update()
    {
        // Check if the baseball should be despawned
        if (Time.time - spawnTime > despawnTime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the baseball collides with something
        if (collision.gameObject.CompareTag("Bat"))
        {
            // Calculate the new velocity when hit by the bat
            Vector3 newVelocity = (collision.transform.forward + Vector3.up).normalized * speed * 2f;

            // Apply the new velocity to the baseball
            rb.velocity = newVelocity;

            // Enable gravity when the baseball collides with the bat
            rb.useGravity = true;
        }
        else
        {
            // Stop the baseball when it hits something else
            rb.velocity = Vector3.zero;
        }
    }
}