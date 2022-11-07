using System;
using UnityEngine;

public static class EventManager
{
    #region Game Events
    public static event Action GameStart;   //when game starts
    public static event Action UseTurn;     //when one turn is used by swipe
    public static event Action<int> GameEnd;     //when all turns are over, called after last ball dies
    

    public static void StartGame() => GameStart?.Invoke();
    public static void TurnUsed() => UseTurn?.Invoke();
    public static void EndGame(int finalScore) => GameEnd?.Invoke(finalScore);
    #endregion


    #region Ball Controller Events
    public static event Action CallForNewBall;  //when a new ball is required after the start and after death of each ball while remaining ball is not zero

    public static void NewBallCalled() => CallForNewBall?.Invoke();
    #endregion

    #region Ball Events
    public static event Action<Vector3, float> Shot;    //when swipe for shot
    public static event Action<int> BallScored;         //when ball touces goal
    public static event Action ShotComplete;            //when current ball dies

    public static void ShotTaken(Vector3 direction, float duration) => Shot?.Invoke(direction, duration);
    public static void ScoreUpdate(int score) => BallScored?.Invoke(score);
    public static void TakenShotCompleted() => ShotComplete?.Invoke();
    #endregion

    #region Item Events
    public static event Action<int> BonusItemTouched;       //when score incrementer is touched by ball
    public static event Action<int> NegativeItemTouched;    //when score deductor touched by ball

    public static void BonusScore(int bonusAmount) => BonusItemTouched?.Invoke(bonusAmount);
    public static void NegativeScore(int scoreDamage) => NegativeItemTouched?.Invoke(scoreDamage);
    #endregion

}
