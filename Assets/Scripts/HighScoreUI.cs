using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject highScoreUIEntryPrefab;
    [SerializeField] Transform elementWrapper;
    [SerializeField] HighScoreHandler highScoreHandler;
    [SerializeField] string playerName;
    [SerializeField] ScoreManager scoreManager;


    List<GameObject> uiElements = new();

    private void OnEnable()
    {
        HighScoreHandler.onHighScoreChange += UpdateUI;
    }

    private void OnDisable()
    {
        HighScoreHandler.onHighScoreChange -= UpdateUI;
    }

    public void ShowPanel()
    {
        highScoreHandler.AddHighScoreIfPossible(new HighScoreElement(playerName, scoreManager.Points));
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateUI (List<HighScoreElement> list)
    {
        int i = 0;
        while(i < list.Count)
        {
            HighScoreElement highScoreElement = list[i];

            if (highScoreElement.score > 0)
            {
                if (i >= uiElements.Count)
                {
                    var inst = Instantiate(highScoreUIEntryPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(elementWrapper);
                    Debug.Log(inst.GetComponentsInChildren<TextMeshProUGUI>());
                    uiElements.Add(inst);
                }

                var texts = uiElements[i].GetComponentsInChildren<TextMeshProUGUI>();
                texts[0].text = highScoreElement.playerName;
                texts[1].text = highScoreElement.score.ToString();
            }
            i++;
        }
    }
}
