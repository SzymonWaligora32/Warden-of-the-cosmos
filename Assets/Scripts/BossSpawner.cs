using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab; 
    [SerializeField] private Vector3 spawnPosition = new Vector3(8f, 0f, 0f); 

    private bool bossSpawned = false;

    public void SpawnBoss()
    {
        if (!bossSpawned)
        {
            Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
            bossSpawned = true;
            Debug.Log("Boss Spawned!");
        }
    }
}
