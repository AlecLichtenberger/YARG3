using UnityEngine;
using TMPro;

public class ShipSink : MonoBehaviour
{
    public int maxCoins = 10;
    private int currentCoins = 0;
    private bool hasSunk = false;

    public TextMeshProUGUI capacityText; // Assign in inspector or find dynamically
    private int warningThreshold = 2;    // Coins left before danger warning

    void Start()
    {
        ShipManager.instance?.RegisterShip(); 
        UpdateCapacityText();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasSunk) return;

        Destroy(other.gameObject); // Remove coin
        currentCoins++;            // Increase count
        Debug.Log("Coin collected: " + currentCoins); // Debug

        UpdateCapacityText(); // Update text
        CheckIfSunk();
    }

    void UpdateCapacityText()
    {
        int remaining = maxCoins - currentCoins;
        if (remaining <= 0)
        {
            capacityText.text = "⚠️ Overloaded!";
            capacityText.color = Color.red;
        }
        else if (remaining <= warningThreshold)
        {
            capacityText.text = "⚠️ " + remaining + " to sink";
            capacityText.color = Color.yellow;
        }
        else
        {
            capacityText.text = currentCoins  + "/" + maxCoins;
            capacityText.color = Color.white;
        }
    }

    void CheckIfSunk()
    {
        if (currentCoins > maxCoins)
        {
            hasSunk = true;
            Debug.Log("Ship is sinking!");
            SinkShip();
        }
    }

    void SinkShip()
    {
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 2f;
        rb.mass = 10f;

        ShipManager.instance?.ShipSunk(); // Notify manager
        if (capacityText != null)
            capacityText.text = "💀 Sunk!";
    }
}

