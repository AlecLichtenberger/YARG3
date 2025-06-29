using UnityEngine;

public class TheLauncher : MonoBehaviour
{
    public GameObject itemPrefab;          // The prefab to launch
    public Transform launchPoint;          // Where the item spawns
    public float launchForce = 10f;        // Upward force applied
    public float launchInterval = 2f;      // Time between launches

    private void Start()
    {
        // Start launching periodically
        InvokeRepeating(nameof(LaunchItem), 0f, launchInterval);
    }

    void LaunchItem()
    {
        // Create the item
        GameObject item = Instantiate(itemPrefab, launchPoint.position, Quaternion.identity);

        // Apply upward force (use Rigidbody or Rigidbody2D)
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
        }
        else
        {
            // If it's a 2D game
            Rigidbody2D rb2D = item.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                rb2D.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);
            }
        }
    }
}
