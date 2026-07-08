using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform[] spawnPoints;

    public int enemyCount = 20;

    void Start()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        if (enemyPrefab == null)
            return;

        for (int i = 0; i < enemyCount; i++)
        {
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(
                enemyPrefab,
                point.position,
                point.rotation
            );
        }
    }

    public void SpawnWave(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(
                enemyPrefab,
                point.position,
                point.rotation
            );
        }
    }
}
