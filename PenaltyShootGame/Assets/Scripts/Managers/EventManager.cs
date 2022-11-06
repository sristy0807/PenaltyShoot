using System;

public static class EventManager
{
    #region Game Manager Events
    public static event Action GameStart;
    public static event Action GameEnd;

    public static void StartGame() => GameStart?.Invoke();
    public static void EndGame() => GameEnd?.Invoke();
    #endregion


    #region Ball Events
    public static event Action<int> BallScored;
    public static event Action BallMissed;

    public static void ScoreUpdate(int score) => BallScored?.Invoke(score);
    public static void MissShot() => BallMissed?.Invoke();
    #endregion

    #region ItemEvents
    public static event Action<int> BonusItemTouched;
    public static event Action<int> NegativeItemTouched;

    public static void BonusScore(int bonusAmount) => BonusItemTouched?.Invoke(bonusAmount);
    public static void NegativeScore(int scoreDamage) => NegativeItemTouched?.Invoke(scoreDamage);
    #endregion

}
