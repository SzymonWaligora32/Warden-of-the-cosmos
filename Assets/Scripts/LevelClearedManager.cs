using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClearedManager : MonoBehaviour
{
    [SerializeField] private GameObject levelClearedCanvas; 

    private void Start()
    {
        if (levelClearedCanvas != null)
        {
            levelClearedCanvas.SetActive(false); 
        }
        else
        {
            Debug.LogError("Level Cleared Canvas is not assigned in the Inspector!");
        }
    }

    public void ShowLevelCleared()
    {
        if (levelClearedCanvas != null)
        {
            levelClearedCanvas.SetActive(true); 
            Time.timeScale = 0f; 
        }
    }

    public void NextLevel()
    {
        Time.timeScale = 1f; 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.Log("No more levels! Returning to menu.");
            SceneManager.LoadScene("MainMenu"); 
        }
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; 
        Application.Quit();
    }
}
