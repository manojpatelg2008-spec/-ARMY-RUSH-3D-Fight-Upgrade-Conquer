using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public int soldierLevel = 1;
    public int tankLevel = 1;
    public int weaponLevel = 1;

    public int soldierUpgradeCost = 100;
    public int tankUpgradeCost = 300;
    public int weaponUpgradeCost = 200;

    public void UpgradeSoldier()
    {
        if (CoinSystem.Instance.SpendCoins(soldierUpgradeCost))
        {
            soldierLevel++;
            soldierUpgradeCost += 50;
            Debug.Log("Soldier Level : " + soldierLevel);
        }
    }

    public void UpgradeTank()
    {
        if (CoinSystem.Instance.SpendCoins(tankUpgradeCost))
        {
            tankLevel++;
            tankUpgradeCost += 100;
            Debug.Log("Tank Level : " + tankLevel);
        }
    }

    public void UpgradeWeapon()
    {
        if (CoinSystem.Instance.SpendCoins(weaponUpgradeCost))
        {
            weaponLevel++;
            weaponUpgradeCost += 75;
            Debug.Log("Weapon Level : " + weaponLevel);
        }
    }
}
