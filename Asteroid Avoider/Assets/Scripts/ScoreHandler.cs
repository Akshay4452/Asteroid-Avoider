using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private float score;
    private int scoreMultiplier = 5;
    private bool shouldCount = true;
    

    private void Update() 
    {
        if(scoreText != null)
        {
            if(!shouldCount) { return ;}
            score += Time.deltaTime * scoreMultiplier;
            scoreText.text = Mathf.FloorToInt(score).ToString(); 
        }
        else
        {
            Debug.LogError("Add Text Mesh Pro component");
            return;
        }
    }
    public int EndTimer()
    {
        shouldCount = false;
        scoreText.text = string.Empty;
        return Mathf.FloorToInt(score);
    }
}
