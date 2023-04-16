using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    [SerializeField] float score = 0;

    public int Points
    {
        get
        {
            return Mathf.RoundToInt(score);
        }
    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            score += (Time.deltaTime + SpeedValues.ScoreSpeed);
            scoreText.text = "Score: " + Mathf.RoundToInt(score);
        }
        
    }
}
