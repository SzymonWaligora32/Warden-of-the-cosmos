using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; 
    [SerializeField] private Transform shootingPoint; 
    [SerializeField] private float shootingCooldown = 1f; 

    private Transform player; 
    private float cooldownTimer;

    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null) return;

        
        if (Mathf.Abs(player.position.y - transform.position.y) < 0.5f)
        {
           
            if (cooldownTimer <= 0f)
            {
                Shoot();
                cooldownTimer = shootingCooldown; 
            }
        }

        
        cooldownTimer -= Time.deltaTime;
    }

    private void Shoot()
    {
        if (shootingPoint == null)
        {
            Debug.LogError("ShootingPoint is not assigned!");
            return;
        }

        
        Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
    }
}
