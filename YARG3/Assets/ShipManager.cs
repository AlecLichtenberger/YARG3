using UnityEngine;
using UnityEngine.SceneManagement;
public class ShipManager : MonoBehaviour
{
    public static ShipManager instance; // Singleton for global access
    private int totalShips = 0;
    private int sunkShips = 0;

    public string nextSceneName; // Set this in Inspector per level

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void RegisterShip()
    {
        totalShips++;
    }

    public void ShipSunk()
    {
        sunkShips++;
        Debug.Log("Ship sunk. Total: " + sunkShips + "/" + totalShips);

        if (sunkShips >= totalShips)
        {
            Debug.Log("All ships sunk. Loading next level...");
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}

