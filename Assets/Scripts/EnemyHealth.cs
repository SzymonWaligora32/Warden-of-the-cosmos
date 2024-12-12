using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 2; 

    private int currentHealth;
    private Animator animator; 
    private bool isDead = false; 

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; 

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
{
    if (animator != null)
    {
        animator.SetTrigger("Die"); 
    }

    Destroy(gameObject, 1f); 
}
}
