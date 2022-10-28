using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (ItemMovement))]
public class PowerUpBehavior : MonoBehaviour
{
    public int PowerUpValue;

    private ItemMovement itemMovement;

    [SerializeField] private bool isMovable;
    [SerializeField] private PowerUpTypes powerUpType;
    [SerializeField] private Transform endPointTransform;




    private void Start()
    {
        InitiateMovementIfMovable();
    }

    private void InitiateMovementIfMovable()
    {
        itemMovement = GetComponent<ItemMovement>();

        if (isMovable)
        {
            itemMovement.MoveObject(endPointTransform.position.x, 1);
        }
    }

   

}


public enum PowerUpTypes
{
    scoreIncrementer,
    destroyer
}

