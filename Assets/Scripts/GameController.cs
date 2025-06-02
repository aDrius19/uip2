using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public TextMeshProUGUI gameOver;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameOver.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);

        Time.timeScale = 0f;

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.SetActive(false);
        }
    }
}


