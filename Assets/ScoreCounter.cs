using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    int currentScore;

    int highScore = 10000;

    

    // Start is called before the first frame update
    void Start()
    {
        if( PlayerPrefs.HasKey("HighScore") == false )
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            highScore = currentScore;
        
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space"))
        {
            currentScore++;
            scoreText.text = "Current score :" + Convert.ToString(currentScore);
        }




        if (currentScore >= highScore)
        {
            currentScore = highScore;
            PlayerPrefs.SetInt("HighScore" , highScore);
        }
    }
}
