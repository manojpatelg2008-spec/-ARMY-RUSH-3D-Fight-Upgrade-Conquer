using UnityEngine;

public class BossController : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;

    public int damage = 20;
    public float moveSpeed = 2.5f;
    public float attackRange = 3f;
    public float attackCooldown = 1f;

    private float nextAttackTime;
    private Transform target;

    void Start()
    {
        currentHealth = maxHealth;
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
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
            target = player.transform;
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
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Boss Defeated!");
        Destroy(gameObject);
    }
}
