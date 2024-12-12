using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1"); 
    }

    public void LoadLevel2()
    {
        Debug.Log("Level 2 is locked in the demo!");
    }

    public void LoadLevel3()
    {
        Debug.Log("Level 3 is locked in the demo!");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}