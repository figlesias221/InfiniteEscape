using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score = 0;

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            score += Time.deltaTime;
            scoreText.text = "Score: " + Mathf.RoundToInt(score);
        }
        
    }
}
