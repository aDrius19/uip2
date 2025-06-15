using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassicMode : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit!");
    }
}
