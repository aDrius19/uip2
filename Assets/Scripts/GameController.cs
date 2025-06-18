/* GameController.cs
 * This file contains the GameController class which manages the game state and UI for game over/restarts.
 */
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public TextMeshProUGUI gameOver;

    public GameObject restartButton;
    public GameObject exitGameButton;

    /// <summary>
    /// This method runs before the Start() method and allows other scripts to access GameController.
    /// </summary>
    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created.
    /// This method initializes the game state and hides the restart and exit buttons.
    /// </summary>
    void Start()
    {
        gameOver.gameObject.SetActive(false);
        restartButton.SetActive(false);
        exitGameButton.SetActive(false);
    }

    /// <summary>
    /// Update is called once per frame.
    /// This method checks for user input to either restart the game or exit the game.
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) // Pop-up a basic in-game restart menu
        {
            restartButton.SetActive(true);
            exitGameButton.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKey(KeyCode.BackQuote)) // Resume the game session at the current time state
        {
            restartButton.SetActive(false);
            exitGameButton.SetActive(false);
            Time.timeScale = 1f;
        }

    }

    /// <summary>
    /// This method handles the game over state.
    /// It shows the Game Over menu, while also disabling the player's movement.
    /// </summary>
    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        restartButton.SetActive(true);
        exitGameButton.SetActive(true);
        Time.timeScale = 0f;

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.SetActive(false);
        }
    }

    /// <summary>
    /// This method restarts the scene and time to restart the game for the player.
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    /// <summary>
    /// This method exits the game and returns to the main meny.
    /// </summary>
    public void ExitGame(string name1)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name1);
    }
}


