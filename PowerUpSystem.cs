using UnityEngine;

public class PowerUpSystem : MonoBehaviour
{
    public float speedBoost = 2f;
    public float boostTime = 5f;

    public int extraSoldiers = 10;

    public void GiveSpeedBoost(PlayerController player)
    {
        if (player == null)
            return;

        player.forwardSpeed *= speedBoost;

        Invoke(nameof(ResetSpeed), boostTime);
    }

    void ResetSpeed()
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        if (player != null)
        {
            player.forwardSpeed = 6f;
        }
    }

    public void GiveExtraArmy(PlayerController player)
    {
        if (player != null)
        {
            player.SpawnSoldiers(extraSoldiers);
        }
    }

    public void HealBoss(BossController boss)
    {
        if (boss != null)
        {
            boss.currentHealth += 100;

            if (boss.currentHealth > boss.maxHealth)
            {
                boss.currentHealth = boss.maxHealth;
            }
        }
    }
}
