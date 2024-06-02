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
        // Quit does not work in the Unity Editor, so we need additional code to stop play mode in the editor.
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
