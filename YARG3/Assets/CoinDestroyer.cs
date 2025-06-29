using UnityEngine;

public class CoinDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        Destroy(other.gameObject);
    
    }
}
