using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] HighScoreHandler highScoreHandler;
    [SerializeField] string playerName;
    private bool gameOver;

    void Start()
    {
        this.gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
            {
                highScoreHandler.AddHighScoreIfPossible(new HighScoreElement(playerName, scoreManager.Points));
                gameOverPanel.SetActive(true);
                gameOver = true;
                Debug.Log(gameOver);
            }
        }
    }

    public void Restart()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("StartScene");
    }
}
