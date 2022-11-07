using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class is responsible for getting new ball when necessary and destroy when done
/// </summary>
public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject BallPrefab; //the prefab to be instantiated
    [SerializeField] private Transform BallPosition; // fixed position where the ball will be placed initially
    [SerializeField] private GameObject currentBall; //reference of the current active ball

    private GameDataController gameDataController;  //reference of singleton for getting ball data

    // Ball data 
    private float ballSpeed; 
    private int regularScore;


    #region unity callbacks

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
    #endregion

    //instantiate  new ball, set ball speed and per goal score
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

    //Destroy the active ball
    private void DestroyCurrentBall()
    {
        GameObject ob = currentBall.gameObject;
        currentBall = null;
        Destroy(ob);
    }

}
