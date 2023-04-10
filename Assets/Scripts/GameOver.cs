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

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        gameOverPanel.SetActive(false);
        highScoreHandler.AddHighScoreIfPossible(new HighScoreElement(playerName, scoreManager.Points));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
