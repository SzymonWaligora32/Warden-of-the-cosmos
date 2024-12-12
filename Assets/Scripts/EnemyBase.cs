using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Vector3 direction;
    public float Speed => speed;


    private void Start()
    {
        
        direction = Vector3.left;
    
    }

    private void Update()
    {
        
        transform.Translate(direction * speed * Time.deltaTime);
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(1);
        }
    }
}


    private void OnDestroy()
{
    if (Random.value < 0.5f) 
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null) 
        {
            playerHealth.Heal();
        }
    }
}


}
