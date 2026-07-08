using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame(int level, int coins)
    {
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();

        Debug.Log("Game Saved");
    }

    public int LoadLevel()
    {
        return PlayerPrefs.GetInt("Level", 1);
    }

    public int LoadCoins()
    {
        return PlayerPrefs.GetInt("Coins", 0);
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Debug.Log("Save Reset");
    }
}
