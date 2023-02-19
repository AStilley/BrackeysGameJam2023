using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TMP_Text scoreNumber;
    public TMP_Text highScoreNumber;
    public int score;

    public static ScoreSystem instanceScore;


    private void Awake()
    {
        score = 0;
        if (instanceScore == null)
        {
            instanceScore = FindObjectOfType<ScoreSystem>();
        }
        instanceScore.AddScore();

        if (instanceScore.highScoreNumber != null)
        {
            instanceScore.highScoreNumber.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
        
    }
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))    
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public static void AddPoints(int addThis)
    {
        instanceScore.score += addThis;
        instanceScore.AddScore();
    }

    public void AddScore()
    {
        instanceScore.scoreNumber.text = instanceScore.score.ToString();
    }
    public static void setHighScore()
    {
        if (int.Parse(instanceScore.highScoreNumber.text) < instanceScore.score)
        {
            Debug.Log("New High Score! " + instanceScore.score);
            PlayerPrefs.SetInt("HighScore", instanceScore.score);
        }

    }
}
