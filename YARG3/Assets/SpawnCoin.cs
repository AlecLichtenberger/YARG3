using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject prefabToSpawn;       // Prefab to spawn
    public Vector3 spawnOffset = Vector3.zero; // Offset from this object's position
    public float spawnInterval = 2f;        // Time (seconds) between spawns

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0f, spawnInterval);
    }

    void Spawn()
    {
        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, transform.position + spawnOffset, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No prefab assigned to spawn!");
        }
    }
}
