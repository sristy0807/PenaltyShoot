using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public GameObject NormalScoreAnimation;
    public GameObject BonusScoreAnimation;
    public GameObject ScoreDeductionAnimation;

    private int scoreValue
    {
        get
        {
            return GameManager.instance.scorePerGoal;
        }
    }
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
        NormalScoreAnimation.gameObject.SetActive(true);
    }

    public void AddPowerUpScore(int score)
    {
        playerScore += score;
        UImanager.instance.UpdateScore();
        BonusScoreAnimation.gameObject.SetActive(true);
    }

    public void DeductPowerUpScore(int score)
    {
        playerScore -= score;
        UImanager.instance.UpdateScore();
        ScoreDeductionAnimation.gameObject.SetActive(true);
    }
}
