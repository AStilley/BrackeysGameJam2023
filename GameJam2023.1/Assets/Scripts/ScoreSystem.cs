using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreNumber;

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
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
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

}
