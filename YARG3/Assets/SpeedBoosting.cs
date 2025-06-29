using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    public Vector2 launchForce = new Vector2(5f, 10f); // X and Y force

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero; // Optional: reset current velocity
                rb.AddForce(launchForce, ForceMode2D.Impulse);
            }
        }
    }
}
