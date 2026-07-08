using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool gameStarted = false;
    public bool gameOver = false;
    public bool levelCompleted = false;

    public int score = 0;
    public int enemiesKilled = 0;

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

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        gameStarted = true;
        gameOver = false;
        levelCompleted = false;

        score = 0;
        enemiesKilled = 0;

        Debug.Log("Game Started");
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score : " + score);
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        AddScore(10);
    }

    public void WinGame()
    {
        levelCompleted = true;
        Debug.Log("YOU WIN");
    }

    public void LoseGame()
    {
        gameOver = true;
        Debug.Log("GAME OVER");
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}
