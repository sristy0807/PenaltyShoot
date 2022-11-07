using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game controller is responsible for controlling the gameplay by tracing score and turn numbers
/// </summary>

public class GameController : MonoBehaviour
{
    private int numberOfTurnRemaining; 
    private int score;

    #region script references
    [SerializeField] private UIController uIController;
    #endregion

    #region unity callbacks

    private void OnEnable()
    {
        EventManager.GameStart += OnGameStart;
        EventManager.BallScored += OnScoreUpdate;
        EventManager.BonusItemTouched += OnScoreUpdate;
        EventManager.NegativeItemTouched += OnScoreDamage;
        EventManager.UseTurn += OnTurnUpdate;
        EventManager.ShotComplete += OnShotComplete;
    }

    private void OnDisable()
    {
        EventManager.GameStart -= OnGameStart;
        EventManager.BallScored -= OnScoreUpdate;
        EventManager.BonusItemTouched -= OnScoreUpdate;
        EventManager.NegativeItemTouched -= OnScoreDamage;
        EventManager.UseTurn -= OnTurnUpdate;
        EventManager.ShotComplete -= OnShotComplete;
    }

    private void Start()
    {
        EventManager.StartGame();
    }

    #endregion

    //initialize turn, score count and call UI initialization
    private void InitializeGameData()
    {
        if(GameDataController.instance != null)
        {
            numberOfTurnRemaining = GameDataController.instance.gameData.totalTurn;
        }

        uIController.GameStartUI(numberOfTurnRemaining, score);
    }

    

    #region Subscribed methods

    //initialize game data and call for the first ball
    private void OnGameStart()
    {
        InitializeGameData();
        EventManager.NewBallCalled();
    }

    // take the score point and add with the total score
    private void OnScoreUpdate(int _score)
    {
        score += _score;
        uIController.UpdateScoreText(score);
    }

    // take the damage point to deduct from total score
    private void OnScoreDamage(int damagePoint)
    {
        score -= damagePoint;
        uIController.UpdateScoreText(score);
    }

    // deduct turn 
    private void OnTurnUpdate()
    {
        numberOfTurnRemaining--;
        uIController.UpdateRemainingTurnText(numberOfTurnRemaining);
    }

    // check whether any turn remaining or not after each shot completed
    private void OnShotComplete()
    {
        if (numberOfTurnRemaining == 0)
        {
            EventManager.EndGame(score);
        }
        else
        {
            EventManager.NewBallCalled();
        }
    }

    #endregion




}

