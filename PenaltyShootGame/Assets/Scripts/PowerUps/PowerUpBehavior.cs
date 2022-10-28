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
            itemMovement.MoveObject(powerUpManager.endPointForMovingPowerUp.position.x, 1);
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

