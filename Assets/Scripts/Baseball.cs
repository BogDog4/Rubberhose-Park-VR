using UnityEngine;

public class Baseball : MonoBehaviour
{
    public float speed = 5f;
    public float despawnTime = 5f;
    public float despawnDistance = 10f;
    private Rigidbody rb;
    private float spawnTime;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnTime = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
        
        // Move the baseball forward
        rb.velocity = transform.forward * speed;
    }

    void Update()
    {
        // Check if the baseball should be despawned based on time
        if (Time.time - spawnTime > despawnTime)
        {
            Destroy(gameObject);
        }

        // should i be despawned based on distance from the player
        if (player != null && Vector3.Distance(transform.position, player.transform.position) > despawnDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the baseball collides with something
        if (collision.gameObject.CompareTag("Bat"))
        {
            // Calculate a new velocity when hit by the bat
            Vector3 newVelocity = (collision.transform.forward + Vector3.up).normalized * speed * 2f;

            // Apply the new velocity to the baseball
            rb.velocity = newVelocity;

            // Enable gravity when the baseball collides with the bat
            rb.useGravity = true;
        }
        else
        {
            // Stop the baseball when it hits something that isnt a bat
            rb.velocity = Vector3.zero;
        }
    }
}