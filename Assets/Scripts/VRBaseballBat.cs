using UnityEngine;

public class VRBaseballBat : MonoBehaviour
{
    public float velocityMultiplier = 5f; // Adjust this value to control the launch velocity

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a "Baseball" tag (adjust the tag accordingly)
        if (collision.gameObject.CompareTag("Baseball"))
        {
            HitBaseball(collision.gameObject);
        }
    }

    private void HitBaseball(GameObject baseball)
    {
        Rigidbody baseballRb = baseball.GetComponent<Rigidbody>();

        if (baseballRb != null)
        {
            // Calculate the launch direction based on the bat's forward direction
            Vector3 launchDirection = transform.forward.normalized;

            // Calculate the launch velocity
            Vector3 launchVelocity = velocityMultiplier * launchDirection;

            // Apply the launch velocity to the baseball
            baseballRb.velocity = launchVelocity;

            // You can also add some rotation to make it look more natural
            baseballRb.angularVelocity = new Vector3(Random.Range(-2f, 2f), 0, 0);
        }
    }
}