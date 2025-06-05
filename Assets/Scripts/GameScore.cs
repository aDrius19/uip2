using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    public static GameScore instance;
    public int score = 0;
    public TextMeshProUGUI scoreTracker;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreTracker.text = score.ToString();
    }
}

