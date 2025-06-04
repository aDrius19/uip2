using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public TextMeshProUGUI gameOver;

    public GameObject restartButton;
    public GameObject exitGameButton;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameOver.gameObject.SetActive(false);
        restartButton.SetActive(false);
        exitGameButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            restartButton.SetActive(true);
            exitGameButton.SetActive(true);
            Time.timeScale = 0f;
        }

    }

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

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Asteroidz");
    }
}


