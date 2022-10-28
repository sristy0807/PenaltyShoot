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
    }

    public void AddPowerUpScore(int score)
    {
        playerScore += score;
    }

    public void DeductPowerUpScore(int score)
    {
        playerScore -= score;
    }
}
