using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject welcomePanel;
    public string playerName;

    // script to start the game when the player clicks the start button
    public void OnClickStart()
    {
        Debug.Log("Start Game");
        PlayerName.Name = playerName;
        Debug.Log(PlayerName.Name);
        SceneManager.LoadScene("GameScene");
        welcomePanel.SetActive(false);
    }

    public void ReadInput(string input)
    {
        playerName = input;
    }
}
