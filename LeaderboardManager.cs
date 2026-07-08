using UnityEngine;
using System.Collections.Generic;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance;

    private List<int> highScores = new List<int>();

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

    public void AddScore(int score)
    {
        highScores.Add(score);
        highScores.Sort();
        highScores.Reverse();

        if (highScores.Count > 10)
        {
            highScores.RemoveAt(10);
        }

        SaveScores();
    }

    public int GetHighScore()
    {
        if (highScores.Count == 0)
            return 0;

        return highScores[0];
    }

    void SaveScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetInt("Score" + i, highScores[i]);
        }

        PlayerPrefs.Save();
    }

    public void LoadScores()
    {
        highScores.Clear();

        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey("Score" + i))
            {
                highScores.Add(PlayerPrefs.GetInt("Score" + i));
            }
        }
    }
}
