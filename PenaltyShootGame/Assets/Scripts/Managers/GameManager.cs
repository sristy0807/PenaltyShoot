using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //script references
    public BallManager ballManager;
    public PowerUpManager powerUpManager;

    public int NumberOfTurnRemaining
    {
        get; private set;
    }

    public int totalTurn
    {
        get;
        private set;
    }
    public int scorePerGoal
    {
        get;
        private set;
    }
    public float speed
    {
        get;
        private set;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        InitializeGameData();
    }

    public void InitializeGameData()
    {
        if(GameDataController.instance != null)
        {
            totalTurn = GameDataController.instance.gameData.totalTurn;
            scorePerGoal = GameDataController.instance.gameConfig.scorePerGoal;
            speed = GameDataController.instance.gameConfig.speed;
        }
    }

    public void GameInitialization()
    {
        InitializeTurns();
        UImanager.instance.UpdateNumberOfTurns();
        UImanager.instance.UpdateScore();
        GetNewBall();
    }

    public void InitializeTurns()
    {
        NumberOfTurnRemaining = totalTurn;
    }

    public void DeductTurn()
    {
        NumberOfTurnRemaining--;
        UpdateTurn();
    }

    public void GetNewBall()
    {
        if (NumberOfTurnRemaining > 0)
        {
            ballManager.BringNewBall();
        }
        else
        {
            GameOver();
        }
        
    }

    public void UpdateTurn()
    {
        UImanager.instance.UpdateNumberOfTurns();
    }

    
    public void GameOver()
    {
        UImanager.instance.GameOver();
    }


    // Start is called before the first frame update
    void Start()
    {
        GameInitialization();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
