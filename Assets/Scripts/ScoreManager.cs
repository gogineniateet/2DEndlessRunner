using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{ 

    int score;
    public Text scoreText;

    // updating score by player distance
    public void ScoreUpdate(int scoreValue)
    {
        scoreText.text = score.ToString();
        score = scoreValue;
        Debug.Log(score);
    }


    
    // updating score by player escaping the enemy
   

   
}
