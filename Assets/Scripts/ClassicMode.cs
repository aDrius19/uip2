using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassicMode : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("ClassicMode");
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit!");
    }
}
