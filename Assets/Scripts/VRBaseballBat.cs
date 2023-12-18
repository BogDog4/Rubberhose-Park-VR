using UnityEngine;

public class VRBaseballBat : MonoBehaviour
{
    public float velocityMultiplier = 5f; // Initial velocity

    private void OnCollisionEnter(Collision collision) 
    {
        // Check collided object for "Baseball" tag
        if (collision.gameObject.CompareTag("Baseball"))
        {
            HitBaseball(collision.gameObject);
        }
    }
//please work
    private void HitBaseball(GameObject baseball)
    {
        Rigidbody baseballRb = baseball.GetComponent<Rigidbody>();

        if (baseballRb != null)
        {
            // Calculates hit direction based on the bat's forward direction
            Vector3 launchDirection = transform.forward.normalized;

            // Calculate the hit velocity
            Vector3 launchVelocity = velocityMultiplier * launchDirection;

            // Apply that velocity to the baseball
            baseballRb.velocity = launchVelocity;

            //rotation to make it look natural
            baseballRb.angularVelocity = new Vector3(Random.Range(-2f, 2f), 0, 0);
        }
    }
}