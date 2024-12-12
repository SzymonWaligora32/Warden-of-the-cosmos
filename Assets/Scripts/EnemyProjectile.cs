using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f; 
    [SerializeField] private float lifeTime = 3f; 
    [SerializeField] private int damage = 1; 

    private void Start()
    {
        
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); 
            }

            
            Destroy(gameObject);
        }
    }
}
