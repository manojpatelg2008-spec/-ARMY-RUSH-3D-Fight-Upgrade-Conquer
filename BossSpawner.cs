using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform spawnPoint;

    public int bossLevel = 1;
    public bool bossSpawned = false;

    void Start()
    {
        Invoke("SpawnBoss", 5f);
    }

    public void SpawnBoss()
    {
        if (bossSpawned)
            return;

        if (bossPrefab == null || spawnPoint == null)
            return;

        GameObject boss = Instantiate(
            bossPrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );

        BossController bossScript = boss.GetComponent<BossController>();

        if (bossScript != null)
        {
            bossScript.maxHealth += bossLevel * 200;
            bossScript.damage += bossLevel * 5;
        }

        bossSpawned = true;
    }

    public void NextBoss()
    {
        bossLevel++;
        bossSpawned = false;

        SpawnBoss();
    }
}
