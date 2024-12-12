using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float shootingCooldown = 0.3f;

    private Rigidbody2D rb; 
    private Animator anim; 
    private Vector2 movement; 
    private float lastShotTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

       
        movement = new Vector2(moveX, moveY);

        bool isMoving = movement != Vector2.zero; 
        anim.SetBool("Move", isMoving);
        
        
        if (Input.GetKeyDown(KeyCode.G) && Time.time >= lastShotTime + shootingCooldown)
        
        {
            
            Shoot();
        
        }
    
    }
    
    private void Shoot()
    {
        
        if (projectilePrefab == null || shootingPoint == null)
        {
            Debug.LogError("ProjectilePrefab or ShootingPoint is not assigned!");
            return;
        }

        
        Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        
        lastShotTime = Time.time;
    }

    private void FixedUpdate()
    {
        
        rb.velocity = movement * speed;

        
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -8.5f, 8.5f); 
        pos.y = Mathf.Clamp(pos.y, -4.5f, 4.5f);
        transform.position = pos;
    }
}
