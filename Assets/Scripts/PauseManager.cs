using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas; 
    private bool isPaused = false; 

    private void Start()
    {
        
        pauseMenuCanvas.SetActive(false);
    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
    }

    public void ResumeGame()
    {
        
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }

    public void RestartLevel()
    {
       
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        
        Application.Quit();
        Debug.Log("Game Quit"); 
    }
}
