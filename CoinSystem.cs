using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    public static CoinSystem Instance;

    public int totalCoins = 0;

    private void Awake()
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

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        Debug.Log("Coins : " + totalCoins);
    }

    public bool SpendCoins(int amount)
    {
        if (totalCoins >= amount)
        {
            totalCoins -= amount;
            return true;
        }

        return false;
    }

    public int GetCoins()
    {
        return totalCoins;
    }
}
