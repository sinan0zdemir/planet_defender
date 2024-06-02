using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int playerScore = 0;
    public int enemyPasses = 0;  // Number of enemies that have passed

    public int winningScore = 2500;
    public int losingEnemyPasses = 15;
    
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
        Debug.Log("Score: " + playerScore);  // Display the increased score in the console for debugging
    }

    public void EnemyPassed()
    {
        enemyPasses++;
        Debug.Log("Enemies Passed: " + enemyPasses);  // Display the number of passed enemies in the console for debugging
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
        SceneManager.LoadScene("Win"); // Load the Win scene
    }

    void LoseGame()
    {
        SceneManager.LoadScene("Lose"); // Load the Lose scene
    }
}
