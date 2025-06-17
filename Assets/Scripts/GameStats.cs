/* GameStats.cs
 * This file contains the GameStats class which manages the game score and timer.
 */
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

    /// <summary>
    /// This method runs before the Start() method and allows other scripts to access GameStats.
    /// </summary>
    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created.
    /// This method controls the game score and timer.
    /// </summary>
    private void Update()
    {
        timeCounter += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeCounter / 60);
        int seconds = Mathf.FloorToInt(timeCounter - minutes * 60);
        timerTracker.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    /// <summary>
    /// This game adds the score to the current score and updates the UI.
    /// </summary>
    public void AddScore(int value)
    {
        score += value;
        scoreTracker.text = score.ToString();
    }
}
