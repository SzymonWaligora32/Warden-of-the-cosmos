using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3; 
    [SerializeField] private Image[] hearts; 
    [SerializeField] private Sprite fullHeart; 
    [SerializeField] private Sprite darkHeart; 

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; 
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 

        UpdateHealthUI(); 

        if (currentHealth <= 0)
        {
            TriggerGameOver(); 
        }
    }

    public void Heal()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            UpdateHealthUI(); 
        }
    }

    private void UpdateHealthUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] != null) 
            {
                hearts[i].sprite = i < currentHealth ? fullHeart : darkHeart;
            }
        }
    }

    private void TriggerGameOver()
    {
        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver(); 
        }
        else
        {
            Debug.LogError("GameOverManager not found in the scene!");
        }
    }
}
