using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHandler : MonoBehaviour
{
    int highScore;

    private void Start()
    {
        SetLatestHighScore();
    }

    private void SetLatestHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }

    public void SetHighScoreIfGreater(int score)
    {
        if(score > highScore)
        {
            highScore = score;
            SaveHighScore(score);
        }
    }
}
