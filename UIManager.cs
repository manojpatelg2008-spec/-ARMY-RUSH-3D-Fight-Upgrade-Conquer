using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text coinText;
    public Text levelText;
    public Text healthText;

    public GameObject winPanel;
    public GameObject gameOverPanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateCoins(int coins)
    {
        if (coinText != null)
            coinText.text = "Coins : " + coins;
    }

    public void UpdateLevel(int level)
    {
        if (levelText != null)
            levelText.text = "Level : " + level;
    }

    public void UpdateHealth(int health)
    {
        if (healthText != null)
            healthText.text = "Health : " + health;
    }

    public void ShowWin()
    {
        if (winPanel != null)
            winPanel.SetActive(true);
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }
}
