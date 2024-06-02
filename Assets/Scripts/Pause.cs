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
            Time.timeScale = 0f; // Oyunu durdur
        }
        else
        {
            Time.timeScale = 1f; // Oyunu devam ettir
        }
    }
}