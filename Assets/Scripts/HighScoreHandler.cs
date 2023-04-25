using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHandler : MonoBehaviour
{
    List<HighScoreElement> highScoreElements = new();
    [SerializeField] int maxCount;
    [SerializeField] string fileName;

    public delegate void OnHighScoreChange(List<HighScoreElement> list);
    public static event OnHighScoreChange onHighScoreChange;

    private void Start()
    {
        LoadHighScores();
    }

    private void LoadHighScores()
    {
        highScoreElements = FileHandler.ReadListFromJSON<HighScoreElement>(fileName);

        while(highScoreElements.Count > maxCount)
        {
            highScoreElements.RemoveAt(maxCount);
        }

        if(onHighScoreChange != null)
        {
            onHighScoreChange.Invoke(highScoreElements);
        }
    }

    private void SaveHighScores()
    {
        FileHandler.SaveToJSON(highScoreElements, fileName);
    }

    public void AddHighScoreIfPossible(HighScoreElement element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if(i >= highScoreElements.Count || element.score > highScoreElements[i].score)
            {
                highScoreElements.Insert(i, element);

                while(highScoreElements.Count > maxCount)
                {
                    highScoreElements.RemoveAt(maxCount);
                }

                SaveHighScores();

                if (onHighScoreChange != null)
                {
                    onHighScoreChange.Invoke(highScoreElements);
                }

                break;
            }
        }

    }
}
