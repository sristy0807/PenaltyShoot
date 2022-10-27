using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    [SerializeField] private Transform BallPosition;

    [SerializeField] private GameObject currentBall;



    private void Start()
    {
        BringNewBall();
    }

    public void BringNewBall()
    {
        if(currentBall == null)
        {
            currentBall = Instantiate(Ball, BallPosition.position, Quaternion.identity);
        }
    }

    public void ClearBall()
    {
        
        currentBall = null;
    }

    public void DestroyCurrentBall()
    {
        GameObject ob = currentBall.gameObject;
        ClearBall();
        Destroy(ob);
    }
}
