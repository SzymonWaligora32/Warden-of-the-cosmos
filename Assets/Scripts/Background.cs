using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f; 
    [SerializeField] private float stopPosition = -20f; 

    private void Update()
    {
        
        if (transform.position.x > stopPosition)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
