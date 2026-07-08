using UnityEngine;

public class MissionSystem : MonoBehaviour
{
    public int enemiesToKill = 20;
    public int enemiesKilled = 0;

    public int coinsReward = 200;
    public bool missionCompleted = false;

    public void EnemyKilled()
    {
        if (missionCompleted)
            return;

        enemiesKilled++;

        if (enemiesKilled >= enemiesToKill)
        {
            CompleteMission();
        }
    }

    void CompleteMission()
    {
        missionCompleted = true;

        if (CoinSystem.Instance != null)
        {
            CoinSystem.Instance.AddCoins(coinsReward);
        }

        Debug.Log("Mission Complete");
    }

    public void ResetMission()
    {
        enemiesKilled = 0;
        missionCompleted = false;
    }
}
