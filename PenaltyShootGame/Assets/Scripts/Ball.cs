using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private BallManager ballManager;


    private void Start()
    {
		ballManager = GameObject.FindObjectOfType<BallManager>();
	}




    private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Goal")
		{
			ballManager.ClearBall();
			ballManager.BringNewBall();
			ScoreManager.instance.AddNormalGoal();
            Destroy(gameObject);
		}
	}


	private void OnTriggerEnter(Collider other)
	{

        if (other.gameObject.CompareTag("PowerUp"))
        {
			ScoreManager.instance.AddPowerUpScore(other.gameObject.GetComponent<PowerUpBehavior>().PowerUpValue);
		}


		ballManager.ClearBall();
		ballManager.BringNewBall();
		Destroy(gameObject);
	}
}
