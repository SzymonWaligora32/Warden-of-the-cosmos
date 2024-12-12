using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy1Prefab;
    [SerializeField] private GameObject enemy2Prefab;
    [SerializeField] private GameObject enemy3Prefab;
    [SerializeField] private GameObject bossPrefab; 
    [SerializeField] private Transform spawnPoint; 
    [SerializeField] private Transform bossSpawnPoint; 
    [SerializeField] private float spawnInterval = 1f; 
    [SerializeField] private int enemiesPerWave = 10; 
    [SerializeField] private float waveBreakTime = 10f; 

    private int waveCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        Debug.Log("Starting level in 3 seconds...");
        yield return new WaitForSeconds(3f); 

        while (waveCount < 3) 
        {
            Debug.Log($"Starting Wave {waveCount + 1}");

            
            switch (waveCount)
            {
                case 0:
                    yield return SpawnEnemyGroup(enemy1Prefab, enemiesPerWave);
                    break;
                case 1:
                    yield return SpawnEnemyGroup(enemy2Prefab, enemiesPerWave);
                    break;
                case 2:
                    yield return SpawnEnemyGroup(enemy3Prefab, enemiesPerWave);
                    break;
            }

            waveCount++;

            if (waveCount < 3)
            {
                Debug.Log("Wave Complete! Waiting for the next wave...");
                yield return new WaitForSeconds(waveBreakTime); 
            }
        }

        Debug.Log("All waves complete! Spawning Boss...");
        yield return new WaitForSeconds(2f); 
        SpawnBoss();
    }

    private IEnumerator SpawnEnemyGroup(GameObject enemyPrefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnEnemy(enemyPrefab);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        if (spawnPoint == null)
        {
            Debug.LogError("Spawn point not assigned!");
            return;
        }

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    private void SpawnBoss()
{
    if (bossPrefab == null || bossSpawnPoint == null)
    {
        Debug.LogError("Boss prefab or spawn point not assigned!");
        return;
    }

    GameObject boss = Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
    Debug.Log("Boss Spawned!");

    BossHealth bossHealth = boss.GetComponent<BossHealth>();
    if (bossHealth == null)
    {
        Debug.LogError("BossHealth script not found on the boss prefab!");
    }
}

}
