using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 30;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Boss Defeated!");
            TriggerLevelCleared();
            Destroy(gameObject); 
        }
    }

    private void TriggerLevelCleared()
    {
        
        LevelClearedManager levelClearedManager = FindObjectOfType<LevelClearedManager>();
        if (levelClearedManager != null)
        {
            levelClearedManager.ShowLevelCleared(); 
        }
        else
        {
            Debug.LogError("LevelClearedManager not found in the scene!");
        }
    }
}
