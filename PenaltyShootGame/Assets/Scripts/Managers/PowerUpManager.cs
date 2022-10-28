using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform endPointForMovingPowerUp;

    public void PowerUpScoreIncrement(int scoreValue)
    {
        ScoreManager.instance.AddPowerUpScore(scoreValue);
    }

    public void PowerUpScoreDeduction(int scoreValue)
    {
        ScoreManager.instance.DeductPowerUpScore(scoreValue);
    }
}
