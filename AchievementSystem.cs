using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    public static AchievementSystem Instance;

    public bool firstWin;
    public bool bossKiller;
    public bool richPlayer;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockFirstWin()
    {
        if (!firstWin)
        {
            firstWin = true;
            Debug.Log("Achievement Unlocked : First Victory");
        }
    }

    public void UnlockBossKiller()
    {
        if (!bossKiller)
        {
            bossKiller = true;
            Debug.Log("Achievement Unlocked : Boss Killer");
        }
    }

    public void CheckCoins(int coins)
    {
        if (coins >= 10000 && !richPlayer)
        {
            richPlayer = true;
            Debug.Log("Achievement Unlocked : Rich Player");
        }
    }
}
