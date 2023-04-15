using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject welcomePanel;

    // script to start the game when the player clicks the start button
    public void OnClickStart()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("GameScene");
        welcomePanel.SetActive(false);
    }
}
