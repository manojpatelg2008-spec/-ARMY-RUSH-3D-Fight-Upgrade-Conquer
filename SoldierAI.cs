using UnityEngine;

public class SoldierAI : MonoBehaviour
{
    public float moveSpeed = 4f;
    public int health = 10;
    public int damage = 1;
    public float attackRange = 1.5f;
    public float attackCooldown = 0.5f;

    private float nextAttackTime;
    private Transform target;

    void Start()
    {
        FindNearestEnemy();
    }

    void Update()
    {
        if (target == null)
        {
            FindNearestEnemy();
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

    void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float minDistance = Mathf.Infinity;
        Transform nearest = null;

        foreach (GameObject enemy in enemies)
        {
            float d = Vector3.Distance(transform.position, enemy.transform.position);

            if (d < minDistance)
            {
                minDistance = d;
                nearest = enemy.transform;
            }
        }

        target = nearest;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Enemy"))
            return;

        EnemyAI enemy = other.GetComponent<EnemyAI>();

        if (enemy == null)
            return;

        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCooldown;
            enemy.TakeDamage(damage);
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
