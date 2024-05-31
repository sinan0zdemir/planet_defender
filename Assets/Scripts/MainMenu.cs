using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); // sample scene index to open the sample scene 
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
