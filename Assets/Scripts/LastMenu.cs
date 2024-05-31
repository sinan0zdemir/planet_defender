using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(0); // sample scene index to open the sample scene 
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        // Unity Editor'da Quit çalışmaz, bu yüzden editörde durdurmak için ek bir kod ekliyoruz.
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
