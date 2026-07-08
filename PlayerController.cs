using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 6f;
    public float sideSpeed = 5f;

    public GameObject soldierPrefab;
    public Transform spawnPoint;

    private List<GameObject> soldiers = new List<GameObject>();

    void Start()
    {
        SpawnSoldiers(10);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * h * sideSpeed * Time.deltaTime);
    }

    public void SpawnSoldiers(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 pos = spawnPoint.position;

            pos.x += Random.Range(-2f, 2f);
            pos.z += Random.Range(-2f, 2f);

            GameObject soldier = Instantiate(
                soldierPrefab,
                pos,
                Quaternion.identity
            );

            soldiers.Add(soldier);
        }
    }

    public int SoldierCount()
    {
        return soldiers.Count;
    }

    public void RemoveSoldier(GameObject soldier)
    {
        if (soldiers.Contains(soldier))
        {
            soldiers.Remove(soldier);
            Destroy(soldier);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GatePlus"))
        {
            SpawnSoldiers(1);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("GateX2"))
        {
            SpawnSoldiers(SoldierCount());
            Destroy(other.gameObject);
        }
    }
}
