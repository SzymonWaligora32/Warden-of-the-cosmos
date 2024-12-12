using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; 
    [SerializeField] private float moveRange = 3f; 
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position; 
    }

    private void Update()
    {
        
        float offsetY = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector3(startPosition.x, startPosition.y + offsetY, startPosition.z);
    }
}
