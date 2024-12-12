using UnityEngine;

public class BoundaryHandler : MonoBehaviour
{
    private GameOverManager gameOverManager;

    private void Start()
    {
        
        gameOverManager = FindObjectOfType<GameOverManager>();

        if (gameOverManager == null)
        {
            Debug.LogError("GameOverManager not found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy"))
        {
            if (gameOverManager != null)
            {
                
                gameOverManager.ShowGameOver();
            }
            else
            {
                Debug.LogError("GameOverManager reference is missing!");
            }

            
            Destroy(collision.gameObject);
        }
    }
}
