using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int health = 15;
    public int damage = 2;
    public float attackRange = 1.5f;
    public float attackCooldown = 0.6f;
    public float moveSpeed = 3f;

    private float nextAttackTime;
    private Transform target;

    void Start()
    {
        FindTarget();
    }

    void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > attackRange)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                moveSpeed * Time.deltaTime
            );

            transform.LookAt(target);
        }
    }

    void FindTarget()
    {
        GameObject[] soldiers = GameObject.FindGameObjectsWithTag("Soldier");

        float minDistance = Mathf.Infinity;
        Transform nearest = null;

        foreach (GameObject soldier in soldiers)
        {
            float d = Vector3.Distance(transform.position, soldier.transform.position);

            if (d < minDistance)
            {
                minDistance = d;
                nearest = soldier.transform;
            }
        }

        target = nearest;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Soldier"))
            return;

        SoldierAI soldier = other.GetComponent<SoldierAI>();

        if (soldier == null)
            return;

        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCooldown;
            soldier.TakeDamage(damage);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
