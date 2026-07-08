using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;

    public float moveSpeed = 2.0f;
    public float attackRange = 2.5f;
    public int attackDamage = 15;
    public float attackCooldown = 1.2f;

    private float nextAttackTime;
    private Transform target;

    void Start()
    {
        currentHealth = maxHealth;
        FindPlayer();
    }

    void Update()
    {
        if (target == null)
        {
            FindPlayer();
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

    void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            target = player.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        SoldierAI soldier = other.GetComponent<SoldierAI>();

        if (soldier == null)
            return;

        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCooldown;
            soldier.TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
