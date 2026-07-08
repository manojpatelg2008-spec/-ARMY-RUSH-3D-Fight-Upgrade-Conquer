using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int currentLevel = 1;
    public bool levelCompleted = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void CompleteLevel()
    {
        if (levelCompleted)
            return;

        levelCompleted = true;

        Debug.Log("Level Complete");

        Invoke("LoadNextLevel", 2f);
    }

    void LoadNextLevel()
    {
        currentLevel++;

        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.Log("All Levels Completed");
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
