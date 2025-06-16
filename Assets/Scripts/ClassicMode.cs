/* ClassicMode.cs
 * This file contains the ClassicMode class which handles the classic game mode screen resolution, loading, and quitting the application.
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassicMode : MonoBehaviour
{
    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created.
    /// This method sets the screen resolution to 1920x1080 in windowed mode.
    /// </summary>
    private void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }

    /// <summary>
    /// This method loads a new scence based on the scene name provided.
    /// </summary>
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// This method quits the application and gives a debug message to indicate that the application has quit.
    /// </summary>
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit!");
    }
}
