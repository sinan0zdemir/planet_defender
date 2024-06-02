using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int playerScore = 0;
    public int enemyPasses = 0;  // Geçen düşman sayısı

    public int winningScore = 50000;
    public int losingEnemyPasses = 2;
    
    public static GameController main;

    void Awake()
    {
        // Singleton pattern
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        CheckGameOver();
    }

    public void AddScore(int points)
    {
        playerScore += points;
        Debug.Log("Score: " + playerScore);  // Skorun arttığını konsolda görmek için
    }

    public void EnemyPassed()
    {
        enemyPasses++;
        Debug.Log("Enemies Passed: " + enemyPasses);  // Geçen düşman sayısını konsolda görmek için
    }

    void CheckGameOver()
    {
        if (playerScore >= winningScore)
        {
            WinGame();
        }
        else if (enemyPasses >= losingEnemyPasses)
        {
            LoseGame();
        }
    }

    void WinGame()
    {
        SceneManager.LoadScene("Win");
    }

    void LoseGame()
    {
        SceneManager.LoadScene("Lose");
    }
}
