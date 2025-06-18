/* MainMenu.cs
 * This file contains the MainMeny class which handles the main menu functionality.
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour 
{

    /// <summary>
    /// This method loads the scene based on the provided scene name.
    /// </summary>

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    /// <summary>
    /// This method quits the application.
    /// </summary>
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit!");
    }
}
