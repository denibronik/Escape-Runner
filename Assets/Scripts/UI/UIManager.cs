using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;
    

    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject NextLevelScreen;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }

        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        settingsScreen.SetActive(false);
        NextLevelScreen.SetActive(false); // Ensure next level screen starts inactive
    }

    private void OnEnable()
{
    gameOverScreen.SetActive(false);
    pauseScreen.SetActive(false);
    settingsScreen.SetActive(false);
    NextLevelScreen.SetActive(false);
    Time.timeScale = 1; // Reset time scale to normal
}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check if NextLevelScreen is active; if so, do nothing
            if (!NextLevelScreen.activeInHierarchy)
            {
                // If settings screen is active, go back to the pause screen
                if (settingsScreen.activeInHierarchy)
                {
                    BackToPause();
                }
                else
                {
                    // Otherwise, toggle the pause state
                    PauseGame(!pauseScreen.activeInHierarchy);
                }
            }
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    public void Restart()
    {
        // Deactivate the NextLevelScreen if it’s active
        gameOverScreen.SetActive(false);
        NextLevelScreen.SetActive(false);
        Time.timeScale = 1; // Ensure time scale is set back to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    
    public void ShowNextLevelScreen()
    {
        NextLevelScreen.SetActive(true);
        Time.timeScale = 0; // Optionally pause the game when showing the next level screen
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        gameOverScreen.SetActive(false);
    pauseScreen.SetActive(false);
    settingsScreen.SetActive(false);
    NextLevelScreen.SetActive(false);

    }
    public void Quit()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void PauseGame(bool status)
    {
        //If status == true pause | if status == false unpause
        pauseScreen.SetActive(status);

        //When pause status is true change timescale to 0 (time stops)
        //when it's false change it back to 1 (time goes by normally)
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void ShowSettings()
    {
        // Show the settings screen and hide the pause screen
        pauseScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void BackToPause()
    {
        // Return to pause screen from settings
        settingsScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }



    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }
    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }

    public void NextLevel(){
    NextLevelScreen.SetActive(false);
    int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
    {
        SceneManager.LoadScene(nextSceneIndex); // Load the next level
        Time.timeScale = 1;
    }
    else
    {
        Debug.LogWarning("No more levels to load. Returning to main menu or end game.");
        MainMenu(); // Or you could show an "End Game" screen if there are no more levels
    }
}

private void OnLevelWasLoaded(int level)
{
    // Find the new player and update the health reference
    Health playerHealth = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
    Healthbar healthbar = FindObjectOfType<Healthbar>();
    if (healthbar != null)
    {
        healthbar.SetPlayerHealth(playerHealth);
    }
}

}
