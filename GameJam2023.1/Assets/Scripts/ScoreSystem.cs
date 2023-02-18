using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreNumber;
    public TextMeshProUGUI highScoreNumber;
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

    // Start is called before the first frame update
    private void Start()
    {
        
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
    public void setHighScore()
    {
        if (int.Parse(instanceScore.highScoreNumber.text) < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

    }
}
