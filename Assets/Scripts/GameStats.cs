using UnityEngine;
using TMPro;

// credits to this video - https://www.youtube.com/watch?v=68Qm0K0c0rE&ab_channel=ObsessiveGames
// for the creation of a basic counter/timer
public class GameStats : MonoBehaviour
{
    public static GameStats instance;
    public TextMeshProUGUI scoreTracker;
    public TextMeshProUGUI timerTracker;

    private float timeCounter;
    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        timeCounter += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeCounter / 60);
        int seconds = Mathf.FloorToInt(timeCounter - minutes * 60);
        timerTracker.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddScore(int value)
    {
        score += value;
        scoreTracker.text = score.ToString();
    }
}
