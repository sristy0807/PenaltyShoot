using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int numberOfTurnRemaining;
    private int score;
    private GameStates currentGameState;
    

    #region script references
    [SerializeField] private UIController uIController;
    #endregion

    private void OnEnable()
    {
        EventManager.GameStart += OnGameStart;
        EventManager.BallScored += OnScoreUpdate;
        EventManager.BonusItemTouched += OnScoreUpdate;
    }

    private void OnDisable()
    {
        EventManager.GameStart -= OnGameStart;
        EventManager.BallScored -= OnScoreUpdate;
        EventManager.BonusItemTouched -= OnScoreUpdate;
    }

    private void Start()
    {
        EventManager.StartGame();
    }




    private void InitializeGameData()
    {
        if(GameDataController.instance != null)
        {
            numberOfTurnRemaining = GameDataController.instance.gameData.totalTurn;
        }

        uIController.GameStartUI(numberOfTurnRemaining, score);
    }

    

    #region Subscribed methods

    private void OnGameStart()
    {
        InitializeGameData();
    }

    private void OnScoreUpdate(int _score)
    {
        score += _score;
        uIController.UpdateScoreText(score);
    }

    private void OnScoreDamage(int damagePoint)
    {
        score -= damagePoint;
        uIController.UpdateScoreText(score);
    }

    private void OnTurnUpdate()
    {
        numberOfTurnRemaining--;
        uIController.UpdateRemainingTurnText(numberOfTurnRemaining);
    }

    #endregion



    private void OnShotComplete()
    {
        if (numberOfTurnRemaining == 0)
        {
            EventManager.EndGame();
        }
    }

    private void OnGameOver()
    {

    }
}

enum GameStates
{
    gameRunning,
    gameComplete
}
