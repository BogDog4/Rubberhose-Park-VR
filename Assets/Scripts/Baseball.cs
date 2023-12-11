using UnityEngine;

public class Baseball : MonoBehaviour


{
    public float speed = 5f; // Adjust the speed as needed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Move the baseball forward
        rb.velocity = transform.forward * speed;
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
        }
        else
        {
            // Stop the baseball when it hits something else
            rb.velocity = Vector3.zero;
        }
    }
}