using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private Transform BallPosition;
    [SerializeField] private GameObject currentBall;

    private GameDataController gameDataController;
    private float ballSpeed;
    private int regularScore;

    private void OnEnable()
    {
        if (GameDataController.instance != null)
        {
            gameDataController = GameDataController.instance;
            ballSpeed = gameDataController.gameConfig.speed;
            regularScore = gameDataController.gameConfig.scorePerGoal;
        }

        EventManager.CallForNewBall += OnCallForNewBall;
    }

    private void OnDisable()
    {
        EventManager.CallForNewBall -= OnCallForNewBall; 
    }

    public void OnCallForNewBall()
    {
        if (currentBall == null)
        {
            currentBall = Instantiate(BallPrefab, BallPosition.position, Quaternion.identity);
        }
        else
        {
            DestroyCurrentBall();
            currentBall = Instantiate(BallPrefab, BallPosition.position, Quaternion.identity);
        }

        currentBall.GetComponent<FootBallBehavior>().SetBallValues(ballSpeed, regularScore);
        
    }

    private void DestroyCurrentBall()
    {
        GameObject ob = currentBall.gameObject;
        currentBall = null;
        Destroy(ob);
    }

}
