using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int playerScore = 0;
    public int enemyPasses = 0;  // Geçen düşman sayısı

    public int winningScore = 50000;
    public int losingEnemyPasses = 20;

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
        SceneManager.LoadScene(3);
    }

    void LoseGame()
    {
        SceneManager.LoadScene(2);
    }
}
