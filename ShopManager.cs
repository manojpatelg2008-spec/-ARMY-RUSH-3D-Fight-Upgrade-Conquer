using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public UpgradeSystem upgradeSystem;

    public int soldierPrice = 100;
    public int tankPrice = 300;
    public int weaponPrice = 200;

    public void BuySoldierUpgrade()
    {
        if (CoinSystem.Instance.SpendCoins(soldierPrice))
        {
            upgradeSystem.UpgradeSoldier();
            Debug.Log("Soldier Upgraded");
        }
        else
        {
            Debug.Log("Not Enough Coins");
        }
    }

    public void BuyTankUpgrade()
    {
        if (CoinSystem.Instance.SpendCoins(tankPrice))
        {
            upgradeSystem.UpgradeTank();
            Debug.Log("Tank Upgraded");
        }
        else
        {
            Debug.Log("Not Enough Coins");
        }
    }

    public void BuyWeaponUpgrade()
    {
        if (CoinSystem.Instance.SpendCoins(weaponPrice))
        {
            upgradeSystem.UpgradeWeapon();
            Debug.Log("Weapon Upgraded");
        }
        else
        {
            Debug.Log("Not Enough Coins");
        }
    }
}
