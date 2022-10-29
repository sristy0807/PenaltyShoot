using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private int scoreValue;
    private int playerScore;

    public int PlayerScore
    {
        get
        {
            return playerScore;
        }
    }

    private void Awake()
    {
        instance = this;
    }


    public void AddNormalGoal()
    {
        playerScore += scoreValue;
        UImanager.instance.UpdateScore();
    }

    public void AddPowerUpScore(int score)
    {
        playerScore += score;
        UImanager.instance.UpdateScore();
    }

    public void DeductPowerUpScore(int score)
    {
        playerScore -= score;
        UImanager.instance.UpdateScore();
    }
}
