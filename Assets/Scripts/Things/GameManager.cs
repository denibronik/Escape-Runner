using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public bool screwdriverCollected { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
        }
    }

    public void CollectScrewdriver()
    {
        screwdriverCollected = true;
    }
}
