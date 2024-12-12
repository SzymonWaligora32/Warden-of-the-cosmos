using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyBase enemyBase;
    private Vector3 startPosition;

    private void Awake()
    {
        
        startPosition = transform.position;
        enemyBase = GetComponent<EnemyBase>();

        if (enemyBase == null)
        {
            Debug.LogError($"EnemyBase component is missing on {gameObject.name}.");
        }
    }

    private void Update()
    {
        
        float offsetX = -enemyBase.Speed * Time.deltaTime;

        
        float waveY = WaveManager.Instance.GetWaveY(transform.position.x);

        
        transform.position = new Vector3(transform.position.x + offsetX, startPosition.y + waveY, transform.position.z);
    }
}
