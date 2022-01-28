using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{

    public TextMeshProUGUI currentScoreText;

    public TextMeshProUGUI highScoreText;
    
    int currentScore;

    int highScore;

    

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore") == true)
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore = 10;
        }
        highScoreText.text = "Highest Score :" + Convert.ToString(highScore);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("b"))
        {
            currentScore++; 
        }
        else
        {
            currentScoreText.text = "Current score :" + Convert.ToString(currentScore);
        }

        if (currentScore >= highScore)
        {
            PlayerPrefs.SetInt("HighScore" , highScore);
            highScore = currentScore;
            highScoreText.text = "Highest score :" + Convert.ToString(highScore);
        }
    }
}
