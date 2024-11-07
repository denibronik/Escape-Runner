using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the first level (assuming it's at build index 1)
        SceneManager.LoadScene(1);
    }

    [SerializeField] private GameObject mainMenuCanvas;

    private void Start()
    {
        // Activate the main menu screen on game start
        mainMenuCanvas.SetActive(true);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
