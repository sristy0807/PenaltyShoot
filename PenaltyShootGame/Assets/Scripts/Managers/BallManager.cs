using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    [SerializeField] private Transform BallPosition;

    [SerializeField] private GameObject currentBall;

    //deduct turn after each shoot
    public void DeductBallTurn()
    {
        GameManager.instance.DeductTurn();
    }

    //call new ball when previous turn is over
    public void BringNewBall()
    {
        if(currentBall == null)
        {
            currentBall = Instantiate(Ball, BallPosition.position, Quaternion.identity);
        }
        else
        {
            DestroyCurrentBall();
            currentBall = Instantiate(Ball, BallPosition.position, Quaternion.identity);
        }
    }

    
    private void DestroyCurrentBall()
    {
        GameObject ob = currentBall.gameObject;
        currentBall = null;
        Destroy(ob);
    }
}
