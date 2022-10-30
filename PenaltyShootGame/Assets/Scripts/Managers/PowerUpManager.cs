using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    //power up moving position references
    public Transform endPoint1;
    public Transform endPoint2;
    public Transform endPoint3;

    public void PowerUpScoreIncrement(int scoreValue)
    {
        ScoreManager.instance.AddPowerUpScore(scoreValue);
    }

    public void PowerUpScoreDeduction(int scoreValue)
    {
        ScoreManager.instance.DeductPowerUpScore(scoreValue);
    }
}

public enum PowerUpTypes
{
    scoreIncrementer,
    destroyer
}

public enum EndPoints
{
    endPoint1, endPoint2, endPoint3
}