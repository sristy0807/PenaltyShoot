using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (ItemMovement))]
public class PowerUpBehavior : MonoBehaviour
{
    public int PowerUpScoreValue;

    private ItemMovement itemMovement;

    [SerializeField] private bool isMovable;
    [SerializeField] private PowerUpTypes powerUpType;
    [SerializeField] private EndPoints endPoint;


    private PowerUpManager powerUpManager;


    private void Start()
    {
        GetPowerUpManagerReference();
        InitiateMovementIfMovable();
    }

    private void GetPowerUpManagerReference()
    {
        powerUpManager = GameObject.FindObjectOfType<PowerUpManager>();
    }

    private void InitiateMovementIfMovable()
    {
        itemMovement = GetComponent<ItemMovement>();

        if (isMovable)
        {
            switch (endPoint)
            {
                case EndPoints.endPoint1:
                    itemMovement.MoveObjectHorizontally(powerUpManager.endPoint1.position.x, 1);
                    break;
                case EndPoints.endPoint2:
                    itemMovement.MoveObjectHorizontally(powerUpManager.endPoint2.position.x, 2);
                    break;
                case EndPoints.endPoint3:
                    itemMovement.MoveObjectHorizontally(powerUpManager.endPoint3.position.x, 3);
                    break;
            }
            
        }
    }

    public void ApplyPowerUpCollisionResult()
    {
        if(powerUpType == PowerUpTypes.scoreIncrementer)
        {
            powerUpManager.PowerUpScoreIncrement(PowerUpScoreValue);
        }
        else if(powerUpType == PowerUpTypes.destroyer)
        {
            powerUpManager.PowerUpScoreDeduction(PowerUpScoreValue);
        }
        else
        {
            return;
        }
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