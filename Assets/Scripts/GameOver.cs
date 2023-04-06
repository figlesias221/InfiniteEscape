using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            Debug.Log("Game Over");
            gameOverPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
