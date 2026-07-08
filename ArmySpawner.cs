using UnityEngine;

public class ArmySpawner : MonoBehaviour
{
    public GameObject soldierPrefab;
    public Transform[] spawnPoints;

    public int startArmy = 10;

    void Start()
    {
        SpawnArmy(startArmy);
    }

    public void SpawnArmy(int amount)
    {
        if (soldierPrefab == null)
            return;

        for (int i = 0; i < amount; i++)
        {
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(
                soldierPrefab,
                point.position,
                point.rotation
            );
        }
    }

    public void AddArmy(int amount)
    {
        SpawnArmy(amount);
    }

    public void DoubleArmy()
    {
        SpawnArmy(startArmy);
    }
}
