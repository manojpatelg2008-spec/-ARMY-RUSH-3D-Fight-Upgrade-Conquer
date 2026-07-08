using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    public int coinReward = 100;
    public int bonusSoldiers = 5;

    public void GiveWinReward()
    {
        if (CoinSystem.Instance != null)
        {
            CoinSystem.Instance.AddCoins(coinReward);
        }

        Debug.Log("Reward Given");
    }

    public void GiveBonusArmy(PlayerController player)
    {
        if (player != null)
        {
            player.SpawnSoldiers(bonusSoldiers);
        }
    }

    public void DoubleReward()
    {
        coinReward *= 2;
    }

    public void ResetReward()
    {
        coinReward = 100;
        bonusSoldiers = 5;
    }
}
