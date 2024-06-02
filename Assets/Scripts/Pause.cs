using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    public void StartGame()
    {
        TogglePause();

    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // stop the game
        }
        else
        {
            Time.timeScale = 1f; // resume game 
        }
    }
}
