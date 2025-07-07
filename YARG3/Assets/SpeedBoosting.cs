using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    public float launchForce = 10f; // Adjust to control power
    public Vector2 launchDirection = Vector2.up; // Default: straight up

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Clear vertical velocity
            rb.AddForce(launchDirection.normalized * launchForce, ForceMode2D.Impulse);
        }
    }
}
