using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;

    [SerializeField] private float frequency = 2f; 
    [SerializeField] private float amplitude = 1f; 
    [SerializeField] private float verticalOffset = 0f; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetWaveY(float x)
    {
        
        return Mathf.Sin(x * frequency) * amplitude + verticalOffset;
    }
}
