using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameRules : MonoBehaviour
{
    private States currentGameState = States.loadNewBall;

    public States CurrentGameState
    {
        get
        {
            return currentGameState;
        }
    }

    
}


public enum States
{
    loadNewBall, shootBall, emptyCurrentBall
}
