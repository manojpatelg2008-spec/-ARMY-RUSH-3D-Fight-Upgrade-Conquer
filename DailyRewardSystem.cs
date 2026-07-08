using UnityEngine;
using System;

public class DailyRewardSystem : MonoBehaviour
{
    public int rewardCoins = 100;

    public bool CanClaimReward()
    {
        string lastDate = PlayerPrefs.GetString("LastRewardDate", "");

        if (string.IsNullOrEmpty(lastDate))
            return true;

        DateTime last = DateTime.Parse(lastDate);

        return (DateTime.Now - last).TotalHours >= 24;
    }

    public void ClaimReward()
    {
        if (!CanClaimReward())
        {
            Debug.Log("Reward Already Claimed");
            return;
        }

        if (CoinSystem.Instance != null)
        {
            CoinSystem.Instance.AddCoins(rewardCoins);
        }

        PlayerPrefs.SetString("LastRewardDate", DateTime.Now.ToString());
        PlayerPrefs.Save();

        Debug.Log("Daily Reward Claimed");
    }

    public float HoursRemaining()
    {
        string lastDate = PlayerPrefs.GetString("LastRewardDate", "");

        if (string.IsNullOrEmpty(lastDate))
            return 0;

        DateTime last = DateTime.Parse(lastDate);

        return Mathf.Max(0,
            24f - (float)(DateTime.Now - last).TotalHours);
    }
}
