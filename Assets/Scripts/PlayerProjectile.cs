using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 3f;

    private void Start()
    {
       
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss")) 
        {
            Debug.Log("Projectile hit the boss!");
            BossHealth bossHealth = collision.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(1); 
            }

            
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy")) 
        {
            Debug.Log("Projectile hit an enemy!");
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1); 
            }

            
            Destroy(gameObject);
        }
    }
}
