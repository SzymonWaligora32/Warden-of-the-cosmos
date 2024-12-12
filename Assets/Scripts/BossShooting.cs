using UnityEngine;

public class BossShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; 
    [SerializeField] private Transform shootingPoint; 
    [SerializeField] private float shootingCooldown = 1f; 

    private float cooldownTimer;

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0f)
        {
            Shoot();
            cooldownTimer = shootingCooldown; 
        }
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
