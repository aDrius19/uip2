using UnityEngine;
using UnityEngine.Localization;
using TMPro;

// credits to this video: https://www.youtube.com/watch?v=XLv79XcbYXc&ab_channel=RootGames
// for showing us a simple script to work with using Localization for changing different languages using dynamic text
public class GameScore : MonoBehaviour
{
    public static GameScore instance;
    public TextMeshProUGUI scoreTracker;
    public LocalizedString localStringScore;

    private int score = 0;
    
    void Awake()
    {
        instance = this;
        
    }

    private void OnEnable()
    {
        localStringScore.Arguments = new object[] { score };
        localStringScore.StringChanged += UpdateText;
    }

    private void OnDisable()
    {
        localStringScore.StringChanged -= UpdateText;
    }

    private void UpdateText(string value)
    {
        scoreTracker.text = value;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreTracker.text = score.ToString();

        localStringScore.Arguments[0] = score;
        localStringScore.RefreshString();
    }
}

