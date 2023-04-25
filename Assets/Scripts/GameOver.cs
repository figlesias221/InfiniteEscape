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
                if (PlayerName.Name == "" || PlayerName.Name == null)
                {
                    playerName = "player1";
                }
                else
                {
                    playerName = PlayerName.Name;
                }

                highScoreHandler.AddHighScoreIfPossible(new HighScoreElement(playerName, scoreManager.Points));
                gameOverPanel.SetActive(true);
                gameOver = true;
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
