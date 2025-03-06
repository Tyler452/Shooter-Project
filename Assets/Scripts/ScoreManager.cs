using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    private int score = 0;
    private int highScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();

        // Update high score if the current score exceeds it
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = $"Score: {score.ToString("0000")}";
    }

    private void UpdateHighScoreUI()
    {
        highScoreText.text = $"High Score: {highScore.ToString("0000")}";
    }
}